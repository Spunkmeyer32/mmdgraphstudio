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
  public partial class NewPropertyForm : Form
  {
    private String[] existingNames;
    public NewPropertyForm(String[] existingNames)
    {
      this.existingNames = existingNames;
      InitializeComponent();
    }

    private void button_propertycancel_Click(object sender, EventArgs e)
    {
      this.textBox_Propertyname.Text = "";
      this.Close();
    }

    private bool isNameValid()
    {
      if (this.textBox_Propertyname.Text.Trim().Length == 0)
      {
        MessageBox.Show("Name can not be empty", "Property name error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }
      foreach (String name in this.existingNames)
      {
        if (this.textBox_Propertyname.Text.Trim().Equals(name))
        {
          MessageBox.Show("This name is already used", "Property name error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return false;
        }
      }
      return true;
    }

    private void button_propertysave_Click(object sender, EventArgs e)
    {
      if (this.isNameValid())
      {
        this.Close();
      }
    }

    public NodeProperty getNodeProperty()
    {
      if(!this.isNameValid())
      {
        return null;
      }
      NodePropertyType newPropertyType = NodePropertyType.text;
      switch(this.comboBox_proptype.Text.Trim())
      {
        case "Text":
          newPropertyType = NodePropertyType.text;
          break;
        case "Number":
          newPropertyType = NodePropertyType.number;
          break;
        case "Selectionlist":
          newPropertyType = NodePropertyType.enumeration;
          break;
        default:
          MessageBox.Show("Property-Type " + this.comboBox_proptype.Text.Trim() + " not valid", "Property type error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return null;
      }
      return new NodeProperty(newPropertyType, this.textBox_Propertyname.Text.Trim());
    }
  }
}
