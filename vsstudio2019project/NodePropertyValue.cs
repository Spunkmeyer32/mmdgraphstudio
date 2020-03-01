using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_Graph_Studio
{

  /// <summary>
  /// This stores the specific values of a property (See <see cref="MMD_Graph_Studio.NodeProperty"/>) of a node. The graph contains a list of properties and each node
  /// stores only the values with the help of this class.
  /// </summary>
  class NodePropertyValue
  {
    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

    private NodeProperty property;
    private String text;
    private String enumValue;
    private double number;

    public NodePropertyValue(ref NodeProperty property)
    {
      this.property = property;
    }

    public void setText(String text)
    {
      if (this.property.getPropertyType() != NodePropertyType.text)
      {
        Logger.Error("Can not set a text to a non-text node-property");
        return;
      }
      this.text = text;
    }

    public void setNumber(double num)
    {
      if(this.property.getPropertyType() != NodePropertyType.number)
      {
        Logger.Error("Can not set a numeric value to a non-numeric property.");
        return;
      }
      this.number = num;
    }

    public void setEnumValue(String enumValue)
    {
      IReadOnlyCollection<String> enumvalues = this.property.getEnumElements();
      if(enumvalues != null)
      {
        if(enumvalues.Contains(enumValue))
        {
          this.enumValue = enumValue;
        }
        else
        {
          Logger.Error("Can not set this enum-value ("+enumValue+"), its not part of the enum-list of this property ("+this.property.getPropertyName() +")");
          return;
        }
      }
    }

  }
}
