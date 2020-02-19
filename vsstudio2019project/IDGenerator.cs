using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_Graph_Studio
{
  class IDGenerator
  {
    private static UInt64 nextID = 1;
    public static UInt64 GetNextID()
    {
      return nextID++;
    }

    public static UInt64 PeekID()
    {
      return nextID;
    }

    public static void StartAt(UInt64 id)
    {
      nextID = id;
    }
  }
}
