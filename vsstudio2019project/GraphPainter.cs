using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMD_Graph_Studio
{
  class GraphPainter
  {
    private float lastDrawnScaleWidth;
    private float lastDrawnScaleHeight;

    public GraphPainter()
    {

    }

    public Point getGraphCoordinate(Point clientPoint, GraphView view)
    {
      return new Point(
          (int)(clientPoint.X / this.lastDrawnScaleWidth + view.GetLeftBound()),
          (int)(clientPoint.Y / this.lastDrawnScaleHeight + view.GetTopBound())
          );
    }

    internal void drawNewLink(Graphics g, UInt64 newLinkNode, Point mousePosition, GraphView view)
    {
      this.lastDrawnScaleWidth = g.VisibleClipBounds.Width / view.GetWidthBound();
      this.lastDrawnScaleHeight = g.VisibleClipBounds.Height / view.GetHeightBound();
      Brush pn = Brushes.Blue;
      Pen edgePen = Pens.Orange;
      float leftBound = view.GetLeftBound();
      float topBound = view.GetTopBound();
      float nodeWidth = 40.0f * ((this.lastDrawnScaleWidth + this.lastDrawnScaleHeight) / 2);
      float nodeHeight = 40.0f * ((this.lastDrawnScaleWidth + this.lastDrawnScaleHeight) / 2);
      RectangleF rect = new RectangleF();

      Point leftNodePosition = view.GetNodePosition(newLinkNode);
      rect.X = (leftNodePosition.X - leftBound) * this.lastDrawnScaleWidth - nodeWidth / 2.0f;
      rect.Y = (leftNodePosition.Y - topBound) * this.lastDrawnScaleHeight - nodeHeight / 2.0f;
      leftNodePosition.X = (int)((leftNodePosition.X - leftBound) * this.lastDrawnScaleWidth);
      leftNodePosition.Y = (int)((leftNodePosition.Y - topBound) * this.lastDrawnScaleHeight);
      rect.Width = nodeWidth;
      rect.Height = nodeHeight;
      GraphicsPath nodePath = new GraphicsPath();
      nodePath.AddEllipse(rect);

      g.DrawLine(edgePen, leftNodePosition, mousePosition);
      g.FillPath(pn, nodePath);

    }

    public void PaintGraph(Graphics g, Graph graph, GraphView view)
    {
      this.lastDrawnScaleWidth = g.VisibleClipBounds.Width / view.GetWidthBound();
      this.lastDrawnScaleHeight = g.VisibleClipBounds.Height / view.GetHeightBound();
      Brush pn = new SolidBrush(Color.FromArgb(100, 100, 100));
      Brush tb = new SolidBrush(Color.FromArgb(180, 180, 255));
      Pen edgePen = Pens.LightBlue;
      float leftBound = view.GetLeftBound();
      float topBound = view.GetTopBound();
      float nodeWidth = 40.0f * ((this.lastDrawnScaleWidth + this.lastDrawnScaleHeight) / 2);
      float nodeHeight = 40.0f * ((this.lastDrawnScaleWidth + this.lastDrawnScaleHeight) / 2);
      if(nodeWidth < 5.0f)
      {
        nodeWidth = 5.0f;
      }
      if(nodeHeight < 5.0f)
      {
        nodeHeight = 5.0f;
      }
      if(nodeWidth > 300.0f)
      {
        nodeWidth = 300.0f;
      }
      if(nodeHeight > 300.0f)
      {
        nodeHeight = 300.0f;
      }
      RectangleF rect = new RectangleF();
      IReadOnlyDictionary<UInt64, GraphPointData> visibleNodes = view.getVisibleNodes(graph);
      ArrayList drawnEdges = new ArrayList();
      foreach (KeyValuePair<UInt64, GraphPointData> pair in visibleNodes)
      {
        ArrayList readOnlyEdgeList = graph.GetConnectedEdges(pair.Key, view.getCurrentNodeFilter());
        foreach (Edge edge in readOnlyEdgeList)
        {
          if (!drawnEdges.Contains(edge))
          {
            Point leftNodePosition = view.GetNodePosition(edge.GetLeftNode());
            Point rightNodePosition = view.GetNodePosition(edge.GetRightNode());
            leftNodePosition.X = (int)((leftNodePosition.X - leftBound) * this.lastDrawnScaleWidth);
            leftNodePosition.Y = (int)((leftNodePosition.Y - topBound) * this.lastDrawnScaleHeight);
            rightNodePosition.X = (int)((rightNodePosition.X - leftBound) * this.lastDrawnScaleWidth);
            rightNodePosition.Y = (int)((rightNodePosition.Y - topBound) * this.lastDrawnScaleHeight);
            g.DrawLine(edgePen, leftNodePosition, rightNodePosition);
            drawnEdges.Add(edge);
          }
        }
      }
      TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;
      Font nodeFont = new Font(FontFamily.GenericSansSerif, nodeWidth/3, FontStyle.Regular);
      foreach (KeyValuePair<UInt64, GraphPointData> pair in visibleNodes)
      {
        rect.X = (pair.Value.X - leftBound) * this.lastDrawnScaleWidth - nodeWidth / 2.0f;
        rect.Y = (pair.Value.Y - topBound) * this.lastDrawnScaleHeight - nodeHeight / 2.0f;
        rect.Width = nodeWidth;
        rect.Height = nodeHeight;
        GraphicsPath nodePath = new GraphicsPath();
        nodePath.AddEllipse(rect);
        GraphicsPath shadowPath = new GraphicsPath();
        rect.Offset(2.0f, 2.0f);

        shadowPath.AddEllipse(rect);
        using (PathGradientBrush shadowBrush = new PathGradientBrush(shadowPath))
        {
          shadowBrush.WrapMode = WrapMode.Clamp;
          ColorBlend ShadowColorBlend = new ColorBlend(3)
          {
            Colors = new Color[] { Color.Transparent, Color.FromArgb(180, Color.Black), Color.FromArgb(180, Color.Black) },
            Positions = new float[] { 0f, .2f, 1f }
          };
          shadowBrush.InterpolationColors = ShadowColorBlend;
          g.FillPath(shadowBrush, shadowPath);
        }
        g.FillPath(pn, nodePath);
        g.DrawString(graph.getNodeName(pair.Key), nodeFont, tb, new Point((int)rect.X, (int)rect.Y - nodeFont.Height/2+  (int)(rect.Height / 2.0)));
        //TextRenderer.DrawText(g, graph.getNodeName(pair.Key), nodeFont, new Rectangle((int)rect.X, (int)rect.Y-10, (int)rect.Width+200, (int)rect.Height+20), Color.FromArgb(180,180, 255), flags);
      }
    }

    
  }
}
