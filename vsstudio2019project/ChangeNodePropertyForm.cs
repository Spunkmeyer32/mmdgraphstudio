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
  partial class ChangeNodePropertyForm : Form
  {
    private Graph loadedGraph;
    private Node nodeToEdit;

    public ChangeNodePropertyForm(ref Graph loadedGraph, UInt64 nodeToEdit)
    {
      InitializeComponent();
      this.loadedGraph = loadedGraph;
      this.nodeToEdit = this.loadedGraph.getNode(nodeToEdit);
      this.listBox_graphNodeProperties.Items.Clear();
      IReadOnlyCollection<NodeProperty> propertyList = this.loadedGraph.getProperties();
      foreach (NodeProperty property in propertyList)
      {
        this.listBox_graphNodeProperties.Items.Add(property.getPropertyName());
      }
      IReadOnlyCollection<NodePropertyValue> propertyValueList = this.nodeToEdit.getNodeProperties();
      foreach (NodePropertyValue propertyValue in propertyValueList)
      {
        this.listBox_graphNodeProperties.Items.Remove(propertyValue.getName());
        this.listBox_usedNodeProperties.Items.Add(propertyValue.getName());
      }
    }

    private string[] getPropertyNames()
    {
      IReadOnlyCollection<NodeProperty> nodeProperties = this.loadedGraph.getProperties();
      string[] result = new string[nodeProperties.Count];
      int i = 0;
      foreach (NodeProperty property in nodeProperties)
      {
        result[i++] = property.getPropertyName();
      }
      return result;
    }

    private void button_propertynew_Click(object sender, EventArgs e)
    {
      using (NewPropertyForm newPropertyForm = new NewPropertyForm(this.getPropertyNames()))
      {
        newPropertyForm.ShowDialog();
        NodeProperty newNodeProperty = newPropertyForm.getNodeProperty();
        if (newNodeProperty != null)
        {
          this.loadedGraph.addNewNodeProperty(newNodeProperty);
          this.listBox_graphNodeProperties.Items.Add(newNodeProperty.getPropertyName());
        }
      }
    }

    private void button_propertyCloseWindow_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void button_useproperty_Click(object sender, EventArgs e)
    {
      if (this.listBox_graphNodeProperties.SelectedItem == null)
      {
        MessageBox.Show("No property to use selected", "node property value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      String propertyName = this.listBox_graphNodeProperties.SelectedItem.ToString();
      NodeProperty property = this.loadedGraph.getProperty(propertyName);
      if (property == null)
      {
        MessageBox.Show("Property with name " + propertyName + " is invalid!", "node property value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      NodePropertyValue npv = new NodePropertyValue(ref property);
      NewPropertyValue newPropertyValueForm = new NewPropertyValue(ref npv);
      newPropertyValueForm.ShowDialog();
      if (!npv.isPropertyValid())
      {
        MessageBox.Show("The property-value is invalid", "node property value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      this.nodeToEdit.addNodeProperty(npv);
      this.listBox_usedNodeProperties.Items.Add(npv.getName());
      this.listBox_graphNodeProperties.Items.Remove(npv.getName());
    }

    private void button_propertyedit_Click(object sender, EventArgs e)
    {
      if(this.listBox_usedNodeProperties.SelectedItem == null)
      {
        MessageBox.Show("No property to edit selected", "node property value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      NodePropertyValue propertyValue = this.nodeToEdit.getProperty(this.listBox_usedNodeProperties.SelectedItem.ToString());
      if(propertyValue == null)
      {
        MessageBox.Show("This property could not get loaded from element", "node property value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      NewPropertyValue newPropertyValueForm = new NewPropertyValue( ref propertyValue);
      newPropertyValueForm.ShowDialog();
    }
  }
}
