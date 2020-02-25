using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MMD_Graph_Studio
{
  class MGSPersist
  {

    private byte currentVersion = 1;

    public static void LoadFromDisk(String path, ref Graph graphData, ref ArrayList graphViews)
    {
      FileInfo fi = new FileInfo(path);
      if (fi.Exists)
      {
        FileStream fs = fi.OpenRead();
        byte[] fileHeader = new byte[8];
        int read = fs.Read(fileHeader, 0, 8);
        if (read != 8)
        {
          return;
        }
        byte[] counterBytes = new byte[8];
        read = fs.Read(counterBytes, 0, 8);
        if (read != 8)
        {
          return;
        }
        UInt64 counter = BitConverter.ToUInt64(counterBytes, 0);
        byte[] elementSizeBytes = new byte[8];
        UInt64 elementSize;
        UInt64 maxID = 1;
        for (UInt64 i = 0; i < counter; i++)
        {
          fs.Read(elementSizeBytes, 0, 8);
          elementSize = BitConverter.ToUInt64(elementSizeBytes, 0);
          byte[] elementData = new byte[elementSize];
          fs.Read(elementData, 0, (int)elementSize);
          Node loadedNode = new Node(elementData, (int)elementSize, 0);
          graphData.AddNode(loadedNode);
          if (loadedNode.GetID() > maxID)
          {
            maxID = loadedNode.GetID();
          }
        }
        IDGenerator.StartAt(maxID + 1);
        read = fs.Read(counterBytes, 0, 8);
        if (read != 8)
        {
          return;
        }
        counter = BitConverter.ToUInt64(counterBytes, 0);
        for (UInt64 i = 0; i < counter; i++)
        {
          fs.Read(elementSizeBytes, 0, 8);
          elementSize = BitConverter.ToUInt64(elementSizeBytes, 0);
          byte[] elementData = new byte[elementSize];
          fs.Read(elementData, 0, (int)elementSize);
          graphData.AddEdge(new Edge(elementData, 0, (int)elementSize));
        }
        fs.Read(counterBytes, 0, 8);
        counter = BitConverter.ToUInt64(counterBytes, 0);
        byte[] positionData = new byte[28];
        byte[] positionIDData = new byte[8];
        for (UInt64 viewIndex = 0; viewIndex < counter; viewIndex++)
        {
          GraphView newView = new GraphView();
          fs.Read(elementSizeBytes, 0, 8);
          UInt64 positionCounter = BitConverter.ToUInt64(elementSizeBytes, 0);
          for (UInt64 i = 0; i < positionCounter; i++)
          {
            fs.Read(positionIDData, 0, 8);
            fs.Read(positionData, 0, 28);
            UInt64 positionID = BitConverter.ToUInt64(positionIDData, 0);
            GraphPointData newPosition = new GraphPointData(positionData, 0);
            newView.updatePosition(positionID, newPosition);
          }
          graphViews.Add(newView);
        }
        fs.Close();
      }
    }

    public static int SaveToDisk(String path, Graph graphData, ArrayList graphViews)
    {
      int result = 0;
      try
      {
        FileInfo fi = new FileInfo(path);
        if (fi.Exists)
        {
          FileInfo fibak = new FileInfo(path + ".bak");
          if (fibak.Exists)
          {
            FileInfo fibak2 = new FileInfo(path + ".bak2");
            if (fibak2.Exists)
            {
              fibak2.Delete();
            }
            fibak.CopyTo(fibak2.FullName);
            fibak.Delete();
          }
          fi.CopyTo(fibak.FullName);
          fi.Delete();
        }

        using (FileStream fs = fi.OpenWrite())
        {
          // (to identify the filetype)
          fs.WriteByte(137);
          fs.WriteByte((byte)'M');
          fs.WriteByte((byte)'G');
          fs.WriteByte((byte)'S');
          fs.WriteByte((byte)'\r');
          fs.WriteByte((byte)'\n');
          fs.WriteByte(26);
          fs.WriteByte((byte)'\n');
          // Save Graph Nodes
          IReadOnlyCollection<Node> nodes = graphData.GetNodesReadOnly();
          byte[] nodecountbytes = BitConverter.GetBytes((UInt64)nodes.Count);
          fs.Write(nodecountbytes, 0, 8);
          foreach (Node node in nodes)
          {
            byte[] nodeRepresentation = node.getAsBytes();
            byte[] nodeSize = BitConverter.GetBytes((UInt64)nodeRepresentation.Length);
            fs.Write(nodeSize, 0, 8);
            fs.Write(nodeRepresentation, 0, nodeRepresentation.Length);
          }
          // Save Graph Edges
          ArrayList edges = graphData.GetEdgesReadOnly();
          byte[] edgecountbytes = BitConverter.GetBytes((UInt64)edges.Count);
          fs.Write(edgecountbytes, 0, 8);
          foreach (Edge edge in edges)
          {
            byte[] edgeRepresentation = edge.GetAsBytes();
            byte[] edgeSize = BitConverter.GetBytes((UInt64)edgeRepresentation.Length);
            fs.Write(edgeSize, 0, 8);
            fs.Write(edgeRepresentation, 0, edgeRepresentation.Length);
          }
          // Save Grap-Views
          byte[] viewCountBytes = BitConverter.GetBytes((UInt64)graphViews.Count);
          fs.Write(viewCountBytes, 0, 8);
          byte[] positionDataIDBytes = new byte[8];
          foreach (GraphView view in graphViews)
          {
            IReadOnlyDictionary<UInt64, GraphPointData> viewPositions = view.GetPositionsReadOnly();
            byte[] positionCountBytes = BitConverter.GetBytes((UInt64)viewPositions.Count);
            fs.Write(positionCountBytes, 0, 8);
            foreach (KeyValuePair<UInt64, GraphPointData> pair in viewPositions)
            {
              positionDataIDBytes = BitConverter.GetBytes(pair.Key);
              fs.Write(positionDataIDBytes, 0, 8);
              byte[] positionData = pair.Value.GetAsBytes();
              fs.Write(positionData, 0, 28);
            }
          }
        }
      }
      catch(Exception e)
      {
        result = -1;
        Console.WriteLine(e.Message);
      }
      return result;
    }

  }
}
