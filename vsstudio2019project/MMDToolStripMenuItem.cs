using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMD_Graph_Studio
{
  class MMDToolStripMenuItem : ToolStripMenuItem
  {
    public MMDToolStripMenuItem()
    {
      this.AutoSize = false;
      this.Overflow = ToolStripItemOverflow.Always;
      this.Height = 40;
      this.Padding = new Padding(0);
      this.Width = 150;
    }


  }
}
