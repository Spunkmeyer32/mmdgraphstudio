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
  public partial class NewFilterForm : Form
  {

    private NodeFilter newNodeFilter;
    public NewFilterForm()
    {
      InitializeComponent();
    }

    private void button_filtersave_Click(object sender, EventArgs e)
    {
      filterOperator usedOperator = filterOperator.equals;
      switch (comboBox_filtercomperator.Text.Trim())
      {
        case "=":
          usedOperator = filterOperator.equals;
          break;
        case "<":
          usedOperator = filterOperator.less;
          break;
        case ">":
          usedOperator = filterOperator.greater;
          break;
        case "<=":
          usedOperator = filterOperator.lessequal;
          break;
        case ">=":
          usedOperator = filterOperator.greaterequal;
          break;
        case "!=":
          usedOperator = filterOperator.unequal;
          break;
        default:
          usedOperator = filterOperator.equals;
          break;
      }
      this.newNodeFilter = new NodeFilter(this.textBox_filtername.Text.Trim(),
        this.comboBox_filterelement.Text.Trim(), usedOperator,
        this.textBox_filtertext.Text.Trim(), (int)this.numericUpDown_filternumber.Value,
        this.comboBox_filterenum.Text.Trim(), this.checkBox_useRegex.Checked);
    }
  }
}
