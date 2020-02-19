using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Collections;
using MathNet.Spatial.Euclidean;
using System.Collections.ObjectModel;

namespace MMD_Graph_Studio
{
  class GraphView
  {
    private Dictionary<UInt64, GraphPointData> nodePositions = new Dictionary<UInt64, GraphPointData>();
    private int leftBound = 0;
    private int topBound = 0;
    private int widthBound = 1000;
    private int heightBound = 1000;

    private NodeFilter currentNodeFilter = null;

    public GraphView()
    {

    }

    public IReadOnlyDictionary<UInt64, GraphPointData> GetPositionsReadOnly()
    {
      if(this.currentNodeFilter != null)
      {
        return new ReadOnlyDictionary<UInt64, GraphPointData>(this.nodePositions);
      }
      else
      {
        return new ReadOnlyDictionary<UInt64, GraphPointData>(this.nodePositions);
      }      
    }

    public void applyNodeFilter(NodeFilter filter)
    {
      this.currentNodeFilter = filter;
    }

    public void updatePosition(UInt64 nodeID, GraphPointData position)
    {
      if (this.nodePositions.ContainsKey(nodeID))
      {
        this.nodePositions[nodeID] = position;
      }
      else
      {
        this.nodePositions.Add(nodeID, position);
      }
    }

    public void LoadGraphData(Graph graph)
    {
      IReadOnlyCollection<Node> nodesReadOnly = graph.GetNodesReadOnly();
      if (nodesReadOnly.Count > 0)
      {
        int gridsize = (int)(Math.Ceiling(Math.Sqrt((double)nodesReadOnly.Count)));

        int gridspacingWidth = widthBound / (int)(Math.Ceiling(Math.Sqrt((double)nodesReadOnly.Count)));
        int gridspacingHeight = heightBound / (int)(Math.Ceiling(Math.Sqrt((double)nodesReadOnly.Count)));

        int offset = gridsize / 2;
        int counter = 0;
        this.nodePositions.Clear();
        foreach (Node n in nodesReadOnly)
        {
          this.nodePositions.Add(n.GetID(), new GraphPointData((counter % gridsize) * gridspacingWidth + offset, (counter / gridsize) * gridspacingHeight + offset));
          counter++;
        }
      }
    }

    public void UpdateGraphData(Graph newGraph)
    {
      IReadOnlyCollection<Node> nodesReadOnly = newGraph.GetNodesReadOnly();
      int gridsize = (int)(Math.Ceiling(Math.Sqrt((double)nodesReadOnly.Count)));

      int gridspacingWidth = widthBound / (int)(Math.Ceiling(Math.Sqrt((double)nodesReadOnly.Count)));
      int gridspacingHeight = heightBound / (int)(Math.Ceiling(Math.Sqrt((double)nodesReadOnly.Count)));

      int offset = gridsize / 2;
      int counter = 0;

      foreach (Node n in nodesReadOnly)
      {
        if (!this.nodePositions.ContainsKey(n.GetID()))
        {
          this.nodePositions.Add(n.GetID(), new GraphPointData((counter % gridsize) * gridspacingWidth + offset, (counter / gridsize) * gridspacingHeight + offset));
        }
        counter++;
      }
      foreach (KeyValuePair<UInt64, GraphPointData> pair in this.nodePositions)
      {
        bool found = false;
        foreach (Node n in nodesReadOnly)
        {
          if (n.GetID() == pair.Key)
          {
            found = true;
            break;
          }
        }
        if (!found)
        {
          this.nodePositions.Remove(pair.Key);
        }
      }
    }

    internal NodeFilter getCurrentNodeFilter()
    {
      return this.currentNodeFilter;
    }

    public void CalculateBounds()
    {
      int maxX = int.MinValue;
      int maxY = int.MinValue;
      int minX = int.MaxValue;
      int minY = int.MaxValue;
      foreach (KeyValuePair<UInt64, GraphPointData> pair in this.nodePositions)
      {
        if (pair.Value.X > maxX)
        {
          maxX = pair.Value.X;
        }
        if (pair.Value.Y > maxY)
        {
          maxY = pair.Value.Y;
        }
        if (pair.Value.X < minX)
        {
          minX = pair.Value.X;
        }
        if (pair.Value.Y < minY)
        {
          minY = pair.Value.Y;
        }
      }
      if (minX == int.MaxValue)
      {
        minX = 0;
      }
      if (minY == int.MaxValue)
      {
        minY = 0;
      }
      if (maxX == int.MinValue)
      {
        maxX = 0;
      }
      if (maxY == int.MinValue)
      {
        maxY = 0;
      }
      this.leftBound = minX - 150;
      this.topBound = minY - 150;
      this.widthBound = (maxX - this.leftBound) + 150;
      this.heightBound = (maxY - this.topBound) + 150;
    }


    public void validatePositions()
    {
      const float desiredDistance = 65.0f;
      
      foreach (KeyValuePair<UInt64, GraphPointData> pair in this.nodePositions)
      {
        foreach (KeyValuePair<UInt64, GraphPointData> innerPair in this.nodePositions)
        {
          if (pair.Key != innerPair.Key)
          {
            Vector2D direction = new Vector2D(innerPair.Value.X - pair.Value.X, innerPair.Value.Y - pair.Value.Y);
            double len = Math.Abs(direction.Length);  
            if(len < desiredDistance)
            {
              double scalefactor = desiredDistance / len;
              if(scalefactor > 20.0)
              {
                scalefactor = 20.0;
              }
              direction = direction.ScaleBy(scalefactor);
              double len2 = Math.Abs(direction.Length);
              

              if (pair.Value.fixedPosition)
              {
                if(innerPair.Value.fixedPosition)
                {
                  Console.WriteLine("Both nodes fixed already!");
                  continue;
                }
                else
                {
                  // move inner
                  innerPair.Value.setPosition(new Point((int)(pair.Value.X-direction.X), (int)(pair.Value.Y-direction.Y)));
                  innerPair.Value.fixedPosition = true;
                }
              }
              else
              {
                // move outer
                direction = direction.ScaleBy(desiredDistance / len);
                pair.Value.setPosition(new Point((int)(innerPair.Value.X - direction.X), (int)(innerPair.Value.Y - direction.Y)));
                pair.Value.fixedPosition = true;
              }
            }
          }
        }
      }
      foreach (KeyValuePair<UInt64, GraphPointData> pair in this.nodePositions)
      {
        pair.Value.fixedPosition = false;
      }
    }

    public void forcePositioningIteration(Graph graph)
    {
      const float desiredDistanceEdge = 100.0f;
      const float desiredDistanceUnconnected = 150.0f;
      foreach (KeyValuePair<UInt64, GraphPointData> pair in this.nodePositions)
      {
        Vector2D nodeForce = new Vector2D(0, 0);
        foreach (KeyValuePair<UInt64, GraphPointData> innerPair in this.nodePositions)
        {
          if (pair.Key != innerPair.Key)
          {
            Vector2D direction = new Vector2D(innerPair.Value.X - pair.Value.X, innerPair.Value.Y - pair.Value.Y);
            double len = direction.Length;
            Edge nodesEdge = graph.GetNodeConnection(pair.Key, innerPair.Key);
            if (nodesEdge != null)
            {
              double scale = len - desiredDistanceEdge;
              if (scale < 0)
              {
                direction = direction.ScaleBy(scale * 0.01);
              }
              else
              {
                direction = direction.ScaleBy(scale * 0.004);
              }
            }
            else
            {
              double scale = len - desiredDistanceUnconnected;
              if (scale < 0)
              {
                direction = direction.ScaleBy(scale * 0.005);
              }
              else
              {
                direction = direction.ScaleBy(scale * 0.0000001);
              }
            }
            nodeForce = nodeForce.Add(direction);
          }
        }
        pair.Value.MovementVector = nodeForce;
      }
      foreach (KeyValuePair<UInt64, GraphPointData> pair in this.nodePositions)
      {
        pair.Value.IteratePosition();
      }
    }

    internal void setNodePosition(ulong draggedNode, Point graphPoint)
    {
      if (this.nodePositions.ContainsKey(draggedNode))
      {
        this.nodePositions[draggedNode].setPosition(graphPoint);
      }
    }

    internal UInt64 getNodeAtPosition(Point graphPoint)
    {
      foreach (KeyValuePair<UInt64, GraphPointData> pair in this.nodePositions)
      {
        if (Math.Abs(pair.Value.X - graphPoint.X) < 25)
        {
          if (Math.Abs(pair.Value.Y - graphPoint.Y) < 25)
          {
            return pair.Key;
          }
        }
      }
      return 0;
    }

    public void zoom(int amount)
    {
      if (amount != 0)
      {
        int newWidth = 0;
        int newHeight = 0;
        if (amount > 0)
        {
          newWidth = (int)((float)this.widthBound * (1.1));
          newHeight = (int)((float)this.heightBound * (1.1));
          this.leftBound -= (newWidth - this.widthBound) / 2;
          this.topBound -= (newHeight - this.heightBound) / 2;
        }
        else
        {
          newWidth = (int)((float)this.widthBound * (0.9));
          newHeight = (int)((float)this.heightBound * (0.9));
          this.leftBound -= (newWidth - this.widthBound) / 2;
          this.topBound -= (newHeight - this.heightBound) / 2;
        }
        this.widthBound = newWidth;
        this.heightBound = newHeight;
      }
    }


    public IReadOnlyDictionary<UInt64, GraphPointData> getVisibleNodes(Graph graph)
    {
      Dictionary<UInt64, GraphPointData> visibleNodes = new Dictionary<ulong, GraphPointData>();
      foreach (KeyValuePair<UInt64, GraphPointData> pair in this.nodePositions)
      {
        if (pair.Value.X >= this.leftBound &&
            pair.Value.Y >= this.topBound &&
            pair.Value.X <= this.leftBound + this.widthBound &&
            pair.Value.Y <= this.topBound + this.heightBound)
        {
          if(this.currentNodeFilter != null)
          {
            if(this.currentNodeFilter.matchNode(graph.getNode(pair.Key)))
            {
              visibleNodes.Add(pair.Key, pair.Value);
            }
          }
          else
          {
            visibleNodes.Add(pair.Key, pair.Value);
          }
          
        }
      }
      return visibleNodes;
    }

    public int GetLeftBound()
    {
      return this.leftBound;
    }

    public int GetTopBound()
    {
      return this.topBound;
    }

    public int GetWidthBound()
    {
      return this.widthBound;
    }

    public int GetHeightBound()
    {
      return this.heightBound;
    }

    internal Point GetNodePosition(UInt64 id)
    {
      if (this.nodePositions.ContainsKey(id))
      {
        return this.nodePositions[id].Position;
      }
      return new Point(0, 0);
    }
  }
}
