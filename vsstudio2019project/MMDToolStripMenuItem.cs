using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMDGraphStudio
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
      this.ForeColor = Color.FromArgb(160, 160, 230);
    }


  }
}
