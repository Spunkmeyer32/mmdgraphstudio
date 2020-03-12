using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMDGraphStudio
{
  partial class NewPropertyValue : Form
  {
    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

    private NodePropertyValue propertyValue;
    private NodePropertyType propertyType;

    public NewPropertyValue(ref NodePropertyValue nodePropertyValue)
    {
      this.propertyValue = nodePropertyValue;
      InitializeComponent();
      this.textBox_Propertyname.Text = this.propertyValue.getName();
      this.propertyType = this.propertyValue.getPropertyType(); 
      switch(this.propertyType)
      {
        case NodePropertyType.enumeration:
          this.textBox_PropertyText.BackColor = Color.FromArgb(90, 90, 90);
          this.comboBox_PropertySelection.BackColor = Color.White;
          this.textBox_numbervalue.BackColor = Color.FromArgb(90, 90, 90);
          this.textBox_PropertyText.Enabled = false;
          this.comboBox_PropertySelection.Enabled = true;
          this.textBox_numbervalue.Enabled = false;
          IReadOnlyCollection<String> enumlist = this.propertyValue.getPropertyEnumList();
          this.comboBox_PropertySelection.Items.Clear();
          foreach(String enumValue in enumlist)
          {
            this.comboBox_PropertySelection.Items.Add(enumValue);
          }
          if(this.propertyValue.isPropertyValid())
          {
            this.comboBox_PropertySelection.Text = this.propertyValue.getEnumValue();
          }
          break;
        case NodePropertyType.number:
          this.textBox_PropertyText.BackColor = Color.FromArgb(90, 90, 90);
          this.comboBox_PropertySelection.BackColor = Color.FromArgb(90, 90, 90);
          this.textBox_numbervalue.BackColor = Color.White;  
          this.textBox_PropertyText.Enabled = false;
          this.comboBox_PropertySelection.Enabled = false;
          this.textBox_numbervalue.Enabled = true;
          if(this.propertyValue.isPropertyValid())
          {
            this.textBox_numbervalue.Text = this.propertyValue.getNumber().ToString();
          }
          break;
        case NodePropertyType.text:
          this.textBox_PropertyText.BackColor = Color.White;  
          this.comboBox_PropertySelection.BackColor = Color.FromArgb(90, 90, 90);
          this.textBox_numbervalue.BackColor = Color.FromArgb(90, 90, 90);
          this.textBox_PropertyText.Enabled = true;
          this.comboBox_PropertySelection.Enabled = false;
          this.textBox_numbervalue.Enabled = false;
          if(this.propertyValue.isPropertyValid())
          {
            this.textBox_PropertyText.Text = this.propertyValue.getText();
          }
          break;
        default:
          this.textBox_PropertyText.BackColor = Color.FromArgb(90, 90, 90);
          this.comboBox_PropertySelection.BackColor = Color.FromArgb(90, 90, 90);
          this.textBox_numbervalue.BackColor = Color.FromArgb(90, 90, 90);
          this.textBox_PropertyText.Enabled = false;
          this.comboBox_PropertySelection.Enabled = false;
          this.textBox_numbervalue.Enabled = false;
          break;
      }
    }

    private void button_propertysave_Click(object sender, EventArgs e)
    {
      switch(this.propertyType)
      {
        case NodePropertyType.enumeration:
          this.propertyValue.setEnumValue(this.comboBox_PropertySelection.Text);
          break;
        case NodePropertyType.number:
          try
          {
            this.propertyValue.setNumber(Convert.ToDouble(this.textBox_numbervalue.Text.Trim()));
          }
          catch(FormatException fe)
          {
            Logger.Error("Wrong number format for property");
            MessageBox.Show("Not a valid number-format", "node property error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
          }
          catch(OverflowException oe)
          {
            Logger.Error("Number overflow in property");
            MessageBox.Show("Not a valid number-format", "node property error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
          }
          break;
        case NodePropertyType.text:
          this.propertyValue.setText(this.textBox_PropertyText.Text.Trim());
          break;
        default:
          this.propertyValue.invalidate();
          break;
      }
      this.Close();
    }

    private void button_propertycancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
