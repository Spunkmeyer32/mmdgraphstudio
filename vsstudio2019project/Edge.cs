using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_Graph_Studio
{
  class Edge
  {
    private readonly UInt64 nodeleft;
    private readonly UInt64 noderight;

    public Edge(UInt64 left, UInt64 right)
    {
      this.nodeleft = left;
      this.noderight = right;
    }

    public Edge(byte[] raw, int index, int length)
    {
      this.nodeleft = BitConverter.ToUInt64(raw, index);
      this.noderight = BitConverter.ToUInt64(raw, index + 8);
    }

    public byte[] GetAsBytes()
    {
      byte[] result = new byte[16];
      byte[] leftbytes = BitConverter.GetBytes(this.nodeleft);
      byte[] rightbytes = BitConverter.GetBytes(this.noderight);
      for (int i = 0; i < 8; i++)
      {
        result[i] = leftbytes[i];
        result[8 + i] = rightbytes[i];
      }
      return result;
    }


    public UInt64 GetLeftNode()
    {
      return this.nodeleft;
    }

    public UInt64 GetRightNode()
    {
      return this.noderight;
    }

    internal bool connectsNodes(ulong firstNode, ulong secondNode)
    {
      if (this.nodeleft == firstNode && this.noderight == secondNode || this.noderight == firstNode && this.nodeleft == secondNode)
      {
        return true;
      }
      return false;
    }
  }
}
