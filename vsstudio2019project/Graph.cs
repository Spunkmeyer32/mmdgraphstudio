using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MMD_Graph_Studio
{
  class Graph : IDisposable
  {
    private bool disposed = false;
    private Dictionary<UInt64, Node> nodes;
    private ArrayList edges;
    private Dictionary<UInt64, ArrayList> nodeEdges;
    private ArrayList nodeProperties = new ArrayList();

    private Mutex edgeDataMutex = new Mutex(false, "edgeData");
    private Mutex nodeDataMutex = new Mutex(false, "nodeData");
    private Mutex nodeEdgesDataMutex = new Mutex(false, "nodeEdgesData");
    private Mutex nodePropertiesDataMutex = new Mutex(false, "nodePropertyData");

    public Graph()
    {
      IDGenerator.StartAt(1);
      this.nodes = new Dictionary<ulong, Node>();
      this.edges = new ArrayList();
      this.nodeEdges = new Dictionary<ulong, ArrayList>();
    }

    public void Clear()
    {
      this.nodeDataMutex.WaitOne();
      try
      {
        this.nodes.Clear();
      }
      finally
      {
        this.nodeDataMutex.ReleaseMutex();
      }

      this.edgeDataMutex.WaitOne();
      try
      {
        this.edges.Clear();
      }
      finally
      {
        this.edgeDataMutex.ReleaseMutex();
      }

      this.nodeEdgesDataMutex.WaitOne();
      try
      {
        foreach (KeyValuePair<UInt64, ArrayList> pair in this.nodeEdges)
        {
          pair.Value.Clear();
        }
        this.nodeEdges.Clear();
      }
      finally
      {
        this.nodeEdgesDataMutex.ReleaseMutex();
      }
      this.nodePropertiesDataMutex.WaitOne();
      try
      {
        this.nodeProperties.Clear();
      }
      finally
      {
        this.nodePropertiesDataMutex.ReleaseMutex();
      }
    }

    public UInt64 AddNewNode(String name)
    {
      Node nodeToAdd = new Node(name);
      this.nodeDataMutex.WaitOne();
      try
      {
        this.nodes.Add(nodeToAdd.GetID(), nodeToAdd);
      }
      finally
      {
        this.nodeDataMutex.ReleaseMutex();
      }
      this.nodeEdgesDataMutex.WaitOne();
      try
      {
        this.nodeEdges.Add(nodeToAdd.GetID(), new ArrayList());
      }
      finally
      {
        this.nodeEdgesDataMutex.ReleaseMutex();
      }
      return nodeToAdd.GetID();
    }

    public void addNewNodeProperty(NodeProperty property)
    {
      this.nodePropertiesDataMutex.WaitOne();
      try
      {
        this.nodeProperties.Add(property);
      }
      finally
      {
        this.nodePropertiesDataMutex.ReleaseMutex();
      }
    }

    internal void removeNode(UInt64 nodeToRemove)
    {
      this.nodeDataMutex.WaitOne();
      try
      {
        if (this.nodes.ContainsKey(nodeToRemove))
        {
          this.nodes.Remove(nodeToRemove);
          this.nodeEdgesDataMutex.WaitOne();
          try
          {
            if(this.nodeEdges.ContainsKey(nodeToRemove))
            {
              ArrayList edgesToRemove = this.nodeEdges[nodeToRemove];
              this.edgeDataMutex.WaitOne();
              try
              {
                foreach (Edge edge in edgesToRemove)
                {
                  UInt64 otherID = 0;
                  this.edges.Remove(edge);
                  if(edge.GetLeftNode() == nodeToRemove)
                  {
                    otherID = edge.GetRightNode();
                  }
                  else
                  {
                    otherID = edge.GetLeftNode();
                  }
                  ArrayList edgesToCheck = this.nodeEdges[otherID];
                  foreach (Edge checkEdge in edgesToCheck)
                  {
                    if (checkEdge == edge)
                    {
                      edgesToCheck.Remove(edge);
                      break;
                    }
                  }
                }
              }
              finally
              {
                this.edgeDataMutex.ReleaseMutex();
              }
              this.nodeEdges.Remove(nodeToRemove);
            }
          }
          finally
          {
            this.nodeEdgesDataMutex.ReleaseMutex();
          }
        }
      }
      finally
      {
        this.nodeDataMutex.ReleaseMutex();
      }
    }


    public void AddNode(Node node)
    {
      this.nodeDataMutex.WaitOne();
      try
      {
        if (this.nodes.ContainsKey(node.GetID()))
        {
          this.nodes[node.GetID()] = node;
        }
        else
        {
          this.nodes.Add(node.GetID(), node);
          this.nodeEdgesDataMutex.WaitOne();
          try
          {
            this.nodeEdges.Add(node.GetID(), new ArrayList());
          }
          finally
          {
            this.nodeEdgesDataMutex.ReleaseMutex();
          }
        }
      }
      finally
      {
        this.nodeDataMutex.ReleaseMutex();
      }
    }

    public void AddEdge(Edge edge)
    {
      this.edgeDataMutex.WaitOne();
      try
      {
        this.edges.Add(edge);
      }
      finally
      {
        this.edgeDataMutex.ReleaseMutex();
      }
      this.nodeEdgesDataMutex.WaitOne();
      try
      {
        if (!this.nodeEdges.ContainsKey(edge.GetLeftNode()))
        {
          this.nodeEdges.Add(edge.GetLeftNode(), new ArrayList());
        }
        this.nodeEdges[edge.GetLeftNode()].Add(edge);
        if (!this.nodeEdges.ContainsKey(edge.GetRightNode()))
        {
          this.nodeEdges.Add(edge.GetRightNode(), new ArrayList());
        }
        this.nodeEdges[edge.GetRightNode()].Add(edge);
      }
      finally
      {
        this.nodeEdgesDataMutex.ReleaseMutex();
      }
    }

    public String getNodeName(UInt64 nodeID)
    {
      if (this.nodes.ContainsKey(nodeID))
      {
        return this.nodes[nodeID].GetName();
      }
      return "";
    }

    public ArrayList GetConnectedEdges(UInt64 nodeID, NodeFilter filter = null)
    {
      ArrayList connected = new System.Collections.ArrayList();
      this.nodeEdgesDataMutex.WaitOne();
      try
      {
        if (this.nodeEdges.ContainsKey(nodeID))
        {
          if (filter != null)
          {
            ArrayList edgelist = this.nodeEdges[nodeID];
            foreach (Edge edge in edgelist)
            {
              if (edge.GetLeftNode() == nodeID)
              {
                if (filter.matchNode(this.nodes[edge.GetRightNode()]))
                {
                  connected.Add(edge);
                }
              }
              else
              {
                if (filter.matchNode(this.nodes[edge.GetLeftNode()]))
                {
                  connected.Add(edge);
                }
              }
            }
          }
          else
          {
            connected.AddRange(this.nodeEdges[nodeID]);
          }
        }
      }
      finally
      {
        this.nodeEdgesDataMutex.ReleaseMutex();
      }
      return ArrayList.ReadOnly(connected);
    }

    public Edge GetNodeConnection(UInt64 leftNode, UInt64 rightNode)
    {
      this.nodeEdgesDataMutex.WaitOne();
      try
      {
        if (this.nodeEdges.ContainsKey(leftNode))
        {
          ArrayList edgelist = this.nodeEdges[leftNode];
          foreach (Edge edge in edgelist)
          {
            if (edge.connectsNodes(leftNode, rightNode))
            {
              return edge;
            }
          }
        }
      }
      finally
      {
        this.nodeEdgesDataMutex.ReleaseMutex();
      }
      return null;
    }

    public IReadOnlyCollection<Node> GetNodesReadOnly()
    {
      this.nodeDataMutex.WaitOne();
      try
      {
        return Array.AsReadOnly<Node>(this.nodes.Values.ToArray<Node>());
      }
      finally
      {
        this.nodeDataMutex.ReleaseMutex();
      }
    }

    public ArrayList GetEdgesReadOnly()
    {
      this.edgeDataMutex.WaitOne();
      try
      {
        return ArrayList.ReadOnly(this.edges);
      }
      finally
      {
        this.edgeDataMutex.ReleaseMutex();
      }
    }

    internal Node getNode(ulong key)
    {
      this.nodeDataMutex.WaitOne();
      try
      {
        if (this.nodes.ContainsKey(key))
        {
          return this.nodes[key];
        }
      }
      finally
      {
        this.nodeDataMutex.ReleaseMutex();
      }
      return null;
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
        this.Clear();
        this.nodeDataMutex.Dispose();
        this.edgeDataMutex.Dispose();
        this.nodeEdgesDataMutex.Dispose();
      }
      // free native stuff
      disposed = true;
    }

    ~Graph()
    {
      Dispose(false);
    }

    
  }

}
