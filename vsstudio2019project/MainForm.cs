using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Collections;
using System.IO;

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

    private MMDToolStripMenuItem newNodeContextItem = new MMDToolStripMenuItem();
    private MMDToolStripMenuItem newLinkContextItem = new MMDToolStripMenuItem();

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
      this.Text = String.Empty;
      initContextMenu();
      this.panelGraphPaint.MouseWheel += new MouseEventHandler(panelMouseWheel);
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
      newNodeContextItem.Click += new EventHandler(newNodeToolStripMenuItem_Click);
      newLinkContextItem.Click += new EventHandler(newLinkToolStripMenuItem_Click);
      this.graphContextMenuStrip.Padding = new Padding(0);
      this.graphContextMenuStrip.Items.Add(this.newNodeContextItem);
      this.graphContextMenuStrip.Items.Add(this.newLinkContextItem);
      int elementWidth = this.graphContextMenuStrip.Width - this.graphContextMenuStrip.Padding.Left - this.graphContextMenuStrip.Padding.Right;
      this.newNodeContextItem.Width = elementWidth;
      this.newLinkContextItem.Width = elementWidth;
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

    private void button_force_Click(object sender, EventArgs e)
    {
      const double desiredFps = 500.0;
      long ticks1 = 0;
      int steps = 0;
      var interval = Stopwatch.Frequency / desiredFps;
      while (true)
      {
        Application.DoEvents();
        var ticks2 = Stopwatch.GetTimestamp();
        if (ticks2 >= ticks1 + interval)
        {
          steps++;
          ticks1 = Stopwatch.GetTimestamp();
          this.actualView.forcePositioningIteration(this.loadedGraph);
          this.actualView.validatePositions();
          this.actualView.CalculateBounds();
          this.panelGraphPaint.Invalidate();
        }
        if (steps > 300)
        {
          this.actualView.validatePositions();
          break;
        }
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
        this.actualView.zoom(e.Delta);
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
        bool newLink = false;
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
            newLink = true;
          }
        }
        if (newNode || newLink)
        {
          this.newLinkContextItem.Enabled = newLink;
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
          statusLabel.Text = "Saved. Ready.";
        }
        else
        {
          statusLabel.Text = "Error while saving data. Ready.";
        }
      }
      else
      {
        statusLabel.Text = "Filesave was canceled. Ready.";
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
          statusLabel.Text = "Loading File...";
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


          statusLabel.Text = "File is loaded. Ready.";
        }
        else
        {
          statusLabel.Text = "File does not exist. Ready.";
        }
      }
      else
      {
        statusLabel.Text = "File loading cancelled. Ready.";
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
      this.statusLabel.Text = "New Graph. Ready.";
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

    private void label1_MouseDown(object sender, MouseEventArgs e)
    {
      this.MainForm_MouseDown(sender, e);
    }

    private void label1_MouseMove(object sender, MouseEventArgs e)
    {
      this.MainForm_MouseMove(sender, e);
    }

    private void label1_MouseUp(object sender, MouseEventArgs e)
    {
      this.MainForm_MouseUp(sender, e);
    }

    private void toolStripMenuItem1_Click(object sender, EventArgs e)
    {

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

    private void button_newfilter_Click(object sender, EventArgs e)
    {

    }
  }
}
