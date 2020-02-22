using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using MathNet.Spatial.Euclidean;
using System.Collections.ObjectModel;
using System.Threading;

namespace MMD_Graph_Studio
{
  class GraphView : IDisposable
  {
    private bool disposed = false;

    private Dictionary<UInt64, GraphPointData> nodePositions = new Dictionary<UInt64, GraphPointData>();
    private Mutex positionMutex = new Mutex(false, "positionMutex");

    private int leftBound = 0;
    private int topBound = 0;
    private int widthBound = 1000;
    private int heightBound = 1000;

    private NodeFilter currentNodeFilter = null;

    private static float desiredDistanceEdge = 90.0f;
    private static float desiredDistanceUnconnected = 120.0f;
    private static float desiredDistance = 60.0f;

    public GraphView()
    {

    }

    public IReadOnlyDictionary<UInt64, GraphPointData> GetPositionsReadOnly()
    {
      this.positionMutex.WaitOne();
      try
      {
        if (this.currentNodeFilter != null)
        {
          return new ReadOnlyDictionary<UInt64, GraphPointData>(this.nodePositions);
        }
        else
        {
          return new ReadOnlyDictionary<UInt64, GraphPointData>(this.nodePositions);
        }
      }
      finally
      {
        this.positionMutex.ReleaseMutex();
      }
    }

    public void applyNodeFilter(NodeFilter filter)
    {
      this.currentNodeFilter = filter;
    }

    public void updatePosition(UInt64 nodeID, GraphPointData position)
    {
      this.positionMutex.WaitOne();
      try
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
      finally
      {
        this.positionMutex.ReleaseMutex();
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
        this.positionMutex.WaitOne();
        try
        {
          this.nodePositions.Clear();
          foreach (Node n in nodesReadOnly)
          {
            this.nodePositions.Add(n.GetID(), new GraphPointData((counter % gridsize) * gridspacingWidth + offset, (counter / gridsize) * gridspacingHeight + offset));
            counter++;
          }
        }
        finally
        {
          this.positionMutex.ReleaseMutex();
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

      this.positionMutex.WaitOne();
      try
      {
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
      finally
      {
        this.positionMutex.ReleaseMutex();
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
      this.positionMutex.WaitOne();
      try
      {
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
      }
      finally
      {
        this.positionMutex.ReleaseMutex();
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

    internal void setNodeFixedStatus(ulong draggedNode, bool v)
    {
      this.positionMutex.WaitOne();
      try
      {
        if (this.nodePositions.ContainsKey(draggedNode))
        {
          this.nodePositions[draggedNode].fixedPosition = v;
        }
      }
      finally
      {
        this.positionMutex.ReleaseMutex();
      }
    }

    private ArrayList lastTouchedPositionsInLayouting = new ArrayList();
    private Vector2D layoutNodeDirection = new Vector2D(0.0, 0.0);


    public void validatePositions()
    {
      lastTouchedPositionsInLayouting.Clear();
      this.positionMutex.WaitOne();
      try
      {
        foreach (KeyValuePair<UInt64, GraphPointData> pair in this.nodePositions)
        {
          foreach (KeyValuePair<UInt64, GraphPointData> innerPair in this.nodePositions)
          {
            if (pair.Key != innerPair.Key)
            {
              layoutNodeDirection = new Vector2D(innerPair.Value.X - pair.Value.X, innerPair.Value.Y - pair.Value.Y);
              if (layoutNodeDirection.Length < desiredDistance)
              {
                layoutNodeDirection = layoutNodeDirection.ScaleBy(((desiredDistance / layoutNodeDirection.Length) - 1.0) * 0.2 + 1.0);
                if (pair.Value.fixedPosition)
                {
                  if (innerPair.Value.fixedPosition)
                  {
                    continue;
                  }
                  else
                  {
                    // move inner
                    innerPair.Value.setPosition(new Point((int)(pair.Value.X + layoutNodeDirection.X), (int)(pair.Value.Y + layoutNodeDirection.Y)));
                    innerPair.Value.fixedPosition = true;
                    lastTouchedPositionsInLayouting.Add(innerPair.Value);
                  }
                }
                else
                {
                  // move outer
                  pair.Value.setPosition(new Point((int)(innerPair.Value.X - layoutNodeDirection.X), (int)(innerPair.Value.Y - layoutNodeDirection.Y)));
                  pair.Value.fixedPosition = true;
                  lastTouchedPositionsInLayouting.Add(pair.Value);
                }
              }
            }
          }
        }
      }
      finally
      {
        this.positionMutex.ReleaseMutex();
      }
      foreach (GraphPointData position in lastTouchedPositionsInLayouting)
      {
        position.fixedPosition = false;
      }
    }

    

    public bool forcePositioningIteration(Graph graph)
    {
      bool movement = false;
      this.positionMutex.WaitOne();
      try
      {
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
                  direction = direction.ScaleBy(scale * 0.2);
                }
                else
                {
                  direction = direction.ScaleBy(scale * 0.007);
                }
              }
              else
              {
                double scale = len - desiredDistanceUnconnected;
                if (scale < 0)
                {
                  direction = direction.ScaleBy(scale * 0.2);
                }
                else
                {
                  direction = direction.ScaleBy(scale * 0.000005);
                }
              }
              nodeForce = nodeForce.Add(direction);
            }
          }
          if (nodeForce.Length > 42.0f)
          {
            Console.WriteLine(nodeForce.Length);
            movement = true;
            pair.Value.MovementVector = nodeForce;
          }
          else
          {
            pair.Value.MovementVector = new Vector2D(0.0, 0.0);
          }
        }
        foreach (KeyValuePair<UInt64, GraphPointData> pair in this.nodePositions)
        {
          pair.Value.IteratePosition();
        }
      }
      finally
      {
        this.positionMutex.ReleaseMutex();
      }
      return movement;
    }

    internal void setNodePosition(ulong draggedNode, Point graphPoint)
    {
      this.positionMutex.WaitOne();
      try
      {
        if (this.nodePositions.ContainsKey(draggedNode))
        {
          this.nodePositions[draggedNode].setPosition(graphPoint);
        }
      }
      finally
      {
        this.positionMutex.ReleaseMutex();
      }
    }

    internal UInt64 getNodeAtPosition(Point graphPoint)
    {
      this.positionMutex.WaitOne();
      try
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
      }
      finally
      {
        this.positionMutex.ReleaseMutex();
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
      this.positionMutex.WaitOne();
      try
      {
        foreach (KeyValuePair<UInt64, GraphPointData> pair in this.nodePositions)
        {
          if (pair.Value.X >= this.leftBound &&
              pair.Value.Y >= this.topBound &&
              pair.Value.X <= this.leftBound + this.widthBound &&
              pair.Value.Y <= this.topBound + this.heightBound)
          {
            if (this.currentNodeFilter != null)
            {
              if (this.currentNodeFilter.matchNode(graph.getNode(pair.Key)))
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
      }
      finally
      {
        this.positionMutex.ReleaseMutex();
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
      this.positionMutex.WaitOne();
      try
      {
        if (this.nodePositions.ContainsKey(id))
        {
          return this.nodePositions[id].Position;
        }
      }
      finally
      {
        this.positionMutex.ReleaseMutex();
      }
      return new Point(0, 0);
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (disposed)
      {
        return;
      }
      if (disposing)
      {
        this.positionMutex.Dispose();
      }
      // free native stuff
      disposed = true;
    }

    ~GraphView()
    {
      Dispose(false);
    }


  }
}
