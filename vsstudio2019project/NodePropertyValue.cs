using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDGraphStudio
{

  /// <summary>
  /// This stores the specific values of a property (See <see cref="MMDGraphStudio.NodeProperty"/>) of a node. The graph contains a list of properties and each node
  /// stores only the values with the help of this class.
  /// </summary>
  class NodePropertyValue
  {
    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

    private NodeProperty property;
    private bool isValid = false;

    internal string getName()
    {
      return this.property.getPropertyName();
    }

    internal NodePropertyType getPropertyType()
    {
      return this.property.getPropertyType();
    }

    private String text;
    private String enumValue;
    private double number;

    public bool isPropertyValid()
    {
      return this.isValid;
    }

    public NodePropertyValue(ref NodeProperty property)
    {
      this.property = property;
      this.isValid = false;
    }

    internal IReadOnlyCollection<string> getPropertyEnumList()
    {
      return this.property.getEnumElements();
    }

    public void setText(String text)
    {
      if (this.property.getPropertyType() != NodePropertyType.text)
      {
        Logger.Error("Can not set a text to a non-text node-property");
        this.isValid = false;
        return;
      }
      if(text.Trim().Length == 0)
      {
        Logger.Error("Can not set an empty text");
        this.isValid = false;
        return;
      }
      this.text = text;
      this.isValid = true;
    }

    internal string getText()
    {
      return this.text;
    }

    internal double getNumber()
    {
      return this.number;
    }

    internal string getEnumValue()
    {
      return this.enumValue;
    }

    public void setNumber(double num)
    {
      if(this.property.getPropertyType() != NodePropertyType.number)
      {
        Logger.Error("Can not set a numeric value to a non-numeric property.");
        this.isValid = false;
        return;
      }
      this.number = num;
      this.isValid = true;
    }

    public void setEnumValue(String enumValue)
    {
      IReadOnlyCollection<String> enumvalues = this.property.getEnumElements();
      if(enumvalues == null)
      {
        Logger.Error("The property-enum list of this property value is empty");
        this.isValid = false;
        return;       
      }
      if (!enumvalues.Contains(enumValue))
      {
        Logger.Error("Can not set this enum-value (" + enumValue + "), its not part of the enum-list of this property (" + this.property.getPropertyName() + ")");
        this.isValid = false;
        return;
      }
      this.enumValue = enumValue;
      this.isValid = true;
    }

    internal void invalidate()
    {
      this.isValid = false;
    }
  }
}
