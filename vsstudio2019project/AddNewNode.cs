using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMD_Graph_Studio
{
  public partial class AddNewNode : Form
  {

    private String newName;
    public AddNewNode()
    {
      InitializeComponent();
    }

    public String getNewName()
    {
      return this.newName;
    }

    private void button_add_Click(object sender, EventArgs e)
    {
      if (this.textBox_name.Text.Trim().Length > 0)
      {
        this.newName = this.textBox_name.Text.Trim();
        this.Close();
      }
      else
      {
        MessageBox.Show("Name needs to be entered", "No valid name given", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void button_cancel_Click(object sender, EventArgs e)
    {
      this.newName = null;
      this.Close();
    }

    private void textBox_name_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        button_add_Click(sender, e);
      }
      if(e.KeyCode  == Keys.Escape)
      {
        this.newName = null;
        this.Close();
      }
    }
  }
}
