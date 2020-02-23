using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections;
using System.IO;
using System.Threading;

namespace MMD_Graph_Studio
{
  public partial class MainForm : Form
  {
    private Graph loadedGraph;
    private GraphView actualView;
    private GraphPainter graphPainter;

    private UInt64 draggedNode = 0;
    private Point nodeDragStart = new Point(0, 0);
    private bool mouseDragMotion = false;
    private static int nodeDragMinDistance = 15;
    private static int nodeDragMinDistanceSq = nodeDragMinDistance * nodeDragMinDistance;

    private UInt64 newLinkNode = 0;
    private UInt64 newLinkNodeTarget = 0;
    private bool newLinkMode = false;
    private Point lastMouseLinkPosition = new Point(0, 0);

    private Task layoutTask;
    private CancellationToken layoutTaskCancellation = new CancellationToken();

    private MMDToolStripMenuItem newNodeContextItem = new MMDToolStripMenuItem();
    private MMDToolStripMenuItem newLinkContextItem = new MMDToolStripMenuItem();
    private MMDToolStripMenuItem deleteNodeContextItem = new MMDToolStripMenuItem();

    private bool formdragging = false;
    private Point lastMouseFormDragPosition = new Point(0, 0);

    private const int WMessageRightClickTaskbar = 0x313;

    protected override void WndProc(ref Message m)
    {
      if (m.Msg == WMessageRightClickTaskbar)
      {
        contextMenuStrip_MainApp.Show(Cursor.Position.X, Cursor.Position.Y);
        return;
      }
      base.WndProc(ref m);
    }

    public MainForm()
    {
      InitializeComponent();
      this.initCustomGuiElements();
      this.initData();
      this.updateSplitterDistanceAndPanels();
      layoutTask = Task.Run((Action)this.layoutTaskMethod);
    }

    private void initCustomGuiElements()
    {
      this.panel3.MouseLeave += new EventHandler(this.MainForm_MouseLeave);
      this.panel3.MouseUp += new MouseEventHandler(this.MainForm_MouseUp);
      this.panel3.MouseDown += new MouseEventHandler(this.MainForm_MouseDown);
      this.panel3.MouseMove += new MouseEventHandler(this.MainForm_MouseMove);
      this.panel3.MouseDoubleClick += new MouseEventHandler(this.MainForm_MouseDoubleClick);
      this.label1.MouseLeave += new EventHandler(this.MainForm_MouseLeave);
      this.label1.MouseUp += new MouseEventHandler(this.MainForm_MouseUp);
      this.label1.MouseDown += new MouseEventHandler(this.MainForm_MouseDown);
      this.label1.MouseMove += new MouseEventHandler(this.MainForm_MouseMove);
      this.label1.MouseDoubleClick += new MouseEventHandler(this.MainForm_MouseDoubleClick);
      this.Text = String.Empty;
      this.splitContainer.IsSplitterFixed = true;
      this.splitContainer.SplitterWidth = 1;
      initContextMenu();
      this.panelGraphPaint.MouseWheel += new MouseEventHandler(panelMouseWheel);
    }

    private void initData()
    {
      this.loadedGraph = new Graph();
      this.actualView = new GraphView();
      this.actualView.LoadGraphData(this.loadedGraph);
      this.actualView.CalculateBounds();
      this.graphPainter = new GraphPainter();
    }

    private void initContextMenu()
    {
      newNodeContextItem.Text = Resources.new_item;
      newLinkContextItem.Text = Resources.new_edge;
      deleteNodeContextItem.Text = Resources.delete_item;
      newNodeContextItem.Click += new EventHandler(newNodeToolStripMenuItem_Click);
      newLinkContextItem.Click += new EventHandler(newLinkToolStripMenuItem_Click);
      deleteNodeContextItem.Click += new EventHandler(deleteNodeToolStripMenuItem_Click);
      this.graphContextMenuStrip.Padding = new Padding(0);
      this.graphContextMenuStrip.Items.Add(this.newNodeContextItem);
      this.graphContextMenuStrip.Items.Add(this.newLinkContextItem);
      this.graphContextMenuStrip.Items.Add(this.deleteNodeContextItem);
      int elementWidth = this.graphContextMenuStrip.Width - this.graphContextMenuStrip.Padding.Left - this.graphContextMenuStrip.Padding.Right;
      this.newNodeContextItem.Width = elementWidth;
      this.newLinkContextItem.Width = elementWidth;
      this.deleteNodeContextItem.Width = elementWidth;
    }

    private enum VisibleSidePanel
    {
      filterPanel,
      viewPanel
    }

    private bool panelIsOut = false;
    private VisibleSidePanel visibleSidePanel = VisibleSidePanel.filterPanel;

    private void moveFilterViewPanelOut()
    {
      panelIsOut = true;
      updateSplitterDistanceAndPanels();
    }

    private void moveFilterViewPanelIn()
    {
      panelIsOut = false;
      updateSplitterDistanceAndPanels();
    }

    private void updateSplitterDistanceAndPanels ()
    {
      if(panelIsOut)
      {
        this.splitContainer.SplitterDistance = this.splitContainer.Width - 333;
      }
      else
      {
        this.splitContainer.SplitterDistance = this.splitContainer.Width - 33;
      }
      switch (this.visibleSidePanel)
      {
        case VisibleSidePanel.filterPanel:
          this.panel_views.Dock = DockStyle.None;
          this.panel_views.Visible = false;
          this.panel_filters.Dock = DockStyle.Fill;
          this.panel_filters.Visible = true;
          break;
        case VisibleSidePanel.viewPanel:
          this.panel_views.Dock = DockStyle.Fill;
          this.panel_views.Visible = true;
          this.panel_filters.Dock = DockStyle.None;
          this.panel_filters.Visible = false;
          break;
      }
      this.panelGraphPaint.Invalidate();
    }


    private void panel_Paint(object sender, PaintEventArgs e)
    {
      Graphics g = e.Graphics;
      g.SmoothingMode = SmoothingMode.AntiAlias;
      g.PixelOffsetMode = PixelOffsetMode.HighQuality;
      this.graphPainter.PaintGraph(g, this.loadedGraph, this.actualView);
      if (this.newLinkMode)
      {
        this.graphPainter.drawNewLink(g, this.newLinkNode, this.lastMouseLinkPosition, this.actualView);
      }
    }

    private void layoutTaskMethod()
    {
      Thread.CurrentThread.Priority = ThreadPriority.Lowest;
      int waitms = 10;
      int lastMaxForce = 0;
      while (!layoutTaskCancellation.IsCancellationRequested)
      {
        if (this.actualView != null && this.loadedGraph != null)
        {
          lastMaxForce = this.actualView.forcePositioningIteration(this.loadedGraph);
          if (lastMaxForce>0)
          {
            Console.WriteLine(lastMaxForce);
            this.panelGraphPaint.Invalidate();
            if(lastMaxForce > 100)
            {
              waitms = 20;
            }
            else
            {
              waitms = 35;
            }            
          }
          else
          {
            waitms = 100;
          }
        }
        else
        {
          waitms = 250;
        }
        Thread.Sleep(waitms);
      }
    }

    private void panel_MouseDown(object sender, MouseEventArgs e)
    {
      this.mouseDragMotion = false;
      Point graphPoint = this.graphPainter.getGraphCoordinate(e.Location, this.actualView);
      UInt64 hitNode = this.actualView.getNodeAtPosition(graphPoint);
      if (this.newLinkMode)
      {
        if (hitNode != 0)
        {
          this.newLinkNodeTarget = hitNode;
        }
        else
        {
          this.newLinkMode = false;
          this.newLinkNode = 0;
          this.newLinkNodeTarget = 0;
        }
      }
      else
      {
        this.nodeDragStart = e.Location;
        if (hitNode != 0)
        {
          this.draggedNode = hitNode;

        }
        else
        {
          this.draggedNode = 0;
        }
      }
    }

    private void panel_MouseMove(object sender, MouseEventArgs e)
    {
      if (this.newLinkMode)
      {
        lastMouseLinkPosition = e.Location;
        this.panelGraphPaint.Invalidate();
      }
      else
      {
        if (this.draggedNode != 0)
        {
          if (mouseDragMotion)
          {
            //animate
            Point graphPoint = this.graphPainter.getGraphCoordinate(e.Location, this.actualView);
            this.actualView.setNodeFixedStatus(this.draggedNode, true);
            this.actualView.setNodePosition(draggedNode, graphPoint);
            this.panelGraphPaint.Invalidate();
          }
        }
        Point distanceVector = e.Location;
        distanceVector.X -= this.nodeDragStart.X;
        distanceVector.Y -= this.nodeDragStart.Y;
        if (distanceVector.X * distanceVector.X + distanceVector.Y * distanceVector.Y > nodeDragMinDistanceSq)
        {
          this.mouseDragMotion = true;
        }
      }
    }

    private void panelMouseWheel(object sender, MouseEventArgs e)
    {
      if (e.Delta != 0)
      {
        Point graphPoint = this.graphPainter.getGraphCoordinate(e.Location, this.actualView);
        this.actualView.zoom(-e.Delta, graphPoint);
        this.panelGraphPaint.Invalidate();
      }
    }

    private void panel_MouseUp(object sender, MouseEventArgs e)
    {
      if (this.newLinkMode)
      {
        if (this.newLinkNodeTarget != 0)
        {
          this.loadedGraph.AddEdge(new Edge(newLinkNode, newLinkNodeTarget));
          this.newLinkMode = false;
          this.newLinkNode = 0;
          this.panelGraphPaint.Invalidate();
        }
      }
      else
      {
        bool newNode = false;
        bool nodeHit = false;
        if (this.draggedNode == 0 && !this.mouseDragMotion)
        {
          newNode = true;
        }
        else
        {
          if (!this.mouseDragMotion)
          {
            this.newLinkNode = this.draggedNode;
            this.newLinkNodeTarget = 0;
            nodeHit = true;
          }
          else
          {
            this.actualView.setNodeFixedStatus(this.draggedNode, false);
          }
        }
        if (newNode || nodeHit)
        {
          this.newLinkContextItem.Enabled = nodeHit;
          this.deleteNodeContextItem.Enabled = nodeHit;
          this.newNodeContextItem.Enabled = newNode;
          Point startPoint = e.Location;
          startPoint.Offset(-20, -20);
          this.graphContextMenuStrip.Show((Control)sender, startPoint);
        }
        this.draggedNode = 0;
        this.mouseDragMotion = false;
      }
    }

    private void button_save_Click(object sender, EventArgs e)
    {
      string targetfile = null;
      using (SaveFileDialog fd = new SaveFileDialog())
      {
        fd.Filter = "MMD Graph Studio File (*.mgs)|*.mgs";
        fd.ShowDialog();
        targetfile = fd.FileName;
      }
      if (targetfile != null && targetfile.Length > 4)
      {
        ArrayList graphViews = new ArrayList();
        graphViews.Add(this.actualView);
        int result = MGSPersist.SaveToDisk(targetfile, this.loadedGraph, graphViews);
        if (result == 0)
        {
          statusLabel.Text = Resources.status_success_graph_saved;
        }
        else
        {
          statusLabel.Text = Resources.status_failed_graph_saved;
        }
      }
      else
      {
        statusLabel.Text = Resources.status_cancelled_graph_saved;
      }
    }

    private void button_load_Click(object sender, EventArgs e)
    {
      string targetfile = null;
      using (OpenFileDialog fd = new OpenFileDialog())
      {
        fd.Filter = "MMD Graph Studio File (*.mgs)|*.mgs";
        fd.ShowDialog();
        targetfile = fd.FileName;
      }
      if (targetfile != null && targetfile.Length > 4)
      {
        FileInfo fi = new FileInfo(targetfile);
        if (fi.Exists)
        {
          statusLabel.Text = Resources.status_loading_graph;
          this.loadedGraph = new Graph();
          this.loadedGraph.Clear();
          ArrayList graphViews = new ArrayList();
          MGSPersist.LoadFromDisk(targetfile, ref this.loadedGraph, ref graphViews);
          if (graphViews.Count > 0)
          {
            this.actualView = (GraphView)graphViews[0];
          }
          this.actualView.CalculateBounds();
          this.panelGraphPaint.Invalidate();
          statusLabel.Text = Resources.status_loaded_graph;
        }
        else
        {
          statusLabel.Text = Resources.status_loading_file_not_exist;
        }
      }
      else
      {
        statusLabel.Text = Resources.status_loading_graph_cancelled;
      }
    }

    private void newNodeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      String newName = null;
      using (AddNewNode newNodeDialog = new AddNewNode())
      {
        newNodeDialog.StartPosition = FormStartPosition.Manual;
        newNodeDialog.Location = panelGraphPaint.PointToScreen(this.nodeDragStart);
        newNodeDialog.ShowDialog();
        newName = newNodeDialog.getNewName();
      }
      if (newName != null)
      {
        UInt64 newNodeId = this.loadedGraph.AddNewNode(newName);
        this.actualView.UpdateGraphData(this.loadedGraph);
        Point graphPoint = this.graphPainter.getGraphCoordinate(this.nodeDragStart, this.actualView);
        this.actualView.setNodePosition(newNodeId, graphPoint);
        this.panelGraphPaint.Invalidate();
      }
      this.panelGraphPaint.Invalidate();
    }

    private void newLinkToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.newLinkNode != 0)
      {
        this.newLinkMode = true;
        this.newLinkNodeTarget = 0;
      }
    }

    private void deleteNodeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.loadedGraph.removeNode(this.newLinkNode);
      this.actualView.UpdateGraphData(this.loadedGraph);
      this.panelGraphPaint.Invalidate();
    }


    private void graphContextMenuStrip_MouseLeave(object sender, EventArgs e)
    {
      this.graphContextMenuStrip.Hide();
    }

    private void button_newgraph_Click(object sender, EventArgs e)
    {
      this.loadedGraph = new Graph();
      this.actualView = new GraphView();
      this.actualView.LoadGraphData(this.loadedGraph);
      this.actualView.CalculateBounds();
      this.panelGraphPaint.Invalidate();
      this.statusLabel.Text = Resources.status_new_graph_success;
    }

    private void button_app_close_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void button_app_maxmize_Click(object sender, EventArgs e)
    {
      if (this.WindowState == FormWindowState.Maximized)
      {
        this.WindowState = FormWindowState.Normal;
      }
      else
      {
        this.WindowState = FormWindowState.Maximized;
      }
    }

    private void button_app_minimize_Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
    }

    private void MainForm_MouseDown(object sender, MouseEventArgs e)
    {
      if (!this.formdragging)
      {
        this.formdragging = true;
        this.lastMouseFormDragPosition = e.Location;
      }
    }

    private void MainForm_MouseMove(object sender, MouseEventArgs e)
    {
      if (this.formdragging)
      {
        this.Location = new Point(this.Location.X + (e.Location.X - this.lastMouseFormDragPosition.X), this.Location.Y + (e.Location.Y - this.lastMouseFormDragPosition.Y));
      }
    }

    private void MainForm_MouseLeave(object sender, EventArgs e)
    {
      this.formdragging = false;
    }

    private void MainForm_MouseUp(object sender, MouseEventArgs e)
    {
      this.formdragging = false;
    }

    private void toolStripMenuItem_max_Click(object sender, EventArgs e)
    {
      if (this.WindowState == FormWindowState.Maximized)
      {
        this.WindowState = FormWindowState.Normal;
      }
      else
      {
        this.WindowState = FormWindowState.Maximized;
      }
    }

    private void toolStripMenuItem_min_Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
    }

    private void toolStripMenuItem_close_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void MainForm_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      this.toolStripMenuItem_max_Click(sender, e);
    }

    private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
    {
      this.panelGraphPaint.Invalidate();
    }

    private void panel_filterview_out_MouseClick(object sender, MouseEventArgs e)
    {
      moveFilterViewPanelOut();
    }

    

    private void panel_filterview_in_MouseClick(object sender, MouseEventArgs e)
    {
      moveFilterViewPanelIn();
    }

    private void MainForm_Resize(object sender, EventArgs e)
    {
      this.updateSplitterDistanceAndPanels();
    }

    private void panel_showfilter_MouseClick(object sender, MouseEventArgs e)
    {
      this.visibleSidePanel = VisibleSidePanel.filterPanel;
      this.panelIsOut = true;
      this.updateSplitterDistanceAndPanels();
    }

    private void panel_showview_MouseClick(object sender, MouseEventArgs e)
    {
      this.visibleSidePanel = VisibleSidePanel.viewPanel;
      this.panelIsOut = true;
      this.updateSplitterDistanceAndPanels();
    }
  }
}
