using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_Graph_Studio
{
  class Graph
  {
    private Dictionary<UInt64, Node> nodes;
    private ArrayList edges;

    public Graph()
    {
      IDGenerator.StartAt(1);
      this.nodes = new Dictionary<ulong, Node>();
      this.edges = new ArrayList();
    }

    public void Clear()
    {
      this.nodes.Clear();
      this.edges.Clear();
    }

    public UInt64 AddNewNode(String name)
    {
      Node nodeToAdd = new Node(name);
      this.nodes.Add(nodeToAdd.GetID(), nodeToAdd);
      return nodeToAdd.GetID();
    }

    public void AddNode(Node node)
    {
      if (this.nodes.ContainsKey(node.GetID()))
      {
        this.nodes[node.GetID()] = node;
      }
      else
      {
        this.nodes.Add(node.GetID(), node);
      }
    }

    public void AddEdge(Edge edge)
    {
      this.edges.Add(edge);
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
      foreach (Edge edge in this.edges)
      {
        if (edge.GetLeftNode() == nodeID)
        {
          if (filter != null)
          {
            if (filter.matchNode(this.nodes[edge.GetRightNode()]))
            {
              connected.Add(edge);
            }
          }
          else
          {
            connected.Add(edge);
          }
        }
        if (edge.GetRightNode() == nodeID)
        {
          if (filter != null)
          {
            if (filter.matchNode(this.nodes[edge.GetLeftNode()]))
            {
              connected.Add(edge);
            }
          }
          else
          {
            connected.Add(edge);
          }
        }
      }
      return ArrayList.ReadOnly(connected);
    }

    public Edge GetNodeConnection(UInt64 leftNode, UInt64 rightNode)
    {
      foreach (Edge edge in this.edges)
      {
        if ((edge.GetLeftNode() == leftNode && edge.GetRightNode() == rightNode) || (edge.GetLeftNode() == rightNode && edge.GetRightNode() == leftNode))
        {
          return edge;
        }
      }
      return null;
    }

    public IReadOnlyCollection<Node> GetNodesReadOnly()
    {
      return Array.AsReadOnly<Node>(this.nodes.Values.ToArray<Node>());
    }

    public ArrayList GetEdgesReadOnly()
    {
      return ArrayList.ReadOnly(this.edges);
    }

    internal Node getNode(ulong key)
    {
      if(this.nodes.ContainsKey(key))
      {
        return this.nodes[key];
      }
      return null;
    }
  }
}
