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
  partial class ChangeNodePropertyForm : Form
  {
    private Graph loadedGraph;
    private Node nodeToEdit;

    public ChangeNodePropertyForm(ref Graph loadedGraph, UInt64 nodeToEdit)
    {
      InitializeComponent();
      this.loadedGraph = loadedGraph;
      this.nodeToEdit = this.loadedGraph.getNode(nodeToEdit);
    }

    private string[] getPropertyNames()
    {
      IReadOnlyCollection<NodeProperty> nodeProperties = this.loadedGraph.getProperties();
      string[] result = new string[nodeProperties.Count];
      int i = 0;
      foreach(NodeProperty property in nodeProperties)
      {
        result[i++] = property.getPropertyName();
      }
      return result;
    }

    private void button_propertynew_Click(object sender, EventArgs e)
    {
      
      NewPropertyForm newPropertyForm = new NewPropertyForm(this.getPropertyNames());
      newPropertyForm.ShowDialog();
    }
  }
}
