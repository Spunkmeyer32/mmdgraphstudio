using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Spatial.Euclidean;

namespace MMD_Graph_Studio
{
  class GraphPointData
  {
    private Point position;
    public ref Point Position { get { return ref this.position; } }
    public int X { get { return this.position.X; } set { this.position.X = value; } }
    public int Y { get { return this.position.Y; } set { this.position.Y = value; } }
    public Vector2D MovementVector { get; set; }
    public float MovementVelocity { get; set; }

    public bool fixedPosition { get; set; }

    public GraphPointData(Point position)
    {
      this.position = position;
      this.MovementVector = new Vector2D(0, 0);
      this.MovementVelocity = 0.0f;
    }

    public GraphPointData(byte[] raw, int index)
    {
      int x = BitConverter.ToInt32(raw, index);
      int y = BitConverter.ToInt32(raw, index + 4);
      this.position = new Point(x, y);
      double xd = BitConverter.ToDouble(raw, index + 8);
      double yd = BitConverter.ToDouble(raw, index + 16);
      this.MovementVector = new Vector2D(xd, yd);
      this.MovementVelocity = BitConverter.ToSingle(raw, index + 24);
    }

    public byte[] GetAsBytes()
    {
      // 2 int, 2 double, 1 float = 8 + 16 + 4 = 28 bytes
      byte[] result = new byte[28];
      byte[] fourbyte = BitConverter.GetBytes(X);
      int index = 0;
      for (int i = 0; i < 4; i++)
      {
        result[index++] = fourbyte[i];
      }
      fourbyte = BitConverter.GetBytes(Y);
      for (int i = 0; i < 4; i++)
      {
        result[index++] = fourbyte[i];
      }
      byte[] eightbyte = BitConverter.GetBytes(MovementVector.X);
      for (int i = 0; i < 8; i++)
      {
        result[index++] = eightbyte[i];
      }
      eightbyte = BitConverter.GetBytes(MovementVector.Y);
      for (int i = 0; i < 8; i++)
      {
        result[index++] = eightbyte[i];
      }
      fourbyte = BitConverter.GetBytes(MovementVelocity);
      for (int i = 0; i < 4; i++)
      {
        result[index++] = fourbyte[i];
      }
      return result;
    }

    public GraphPointData(int x, int y) : this(new Point(x, y)) { }

    internal void IteratePosition()
    {
      if(this.fixedPosition)
      {
        return;
      }
      this.position.X += (int)(Math.Round(this.MovementVector.X * 0.02));
      this.position.Y += (int)(Math.Round(this.MovementVector.Y * 0.02));
    }

    internal void setPosition(Point graphPoint)
    {
      this.position.X = graphPoint.X;
      this.position.Y = graphPoint.Y;
    }
  }
}
