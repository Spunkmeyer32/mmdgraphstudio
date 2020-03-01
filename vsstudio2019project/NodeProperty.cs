using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_Graph_Studio
{

  public enum NodePropertyType
  {
    text,
    enumeration,
    number
  }

  /// <summary>
  /// Defines a property which can be used in the current graph. This class describes the property but the data is stored in <see cref="MMD_Graph_Studio.NodePropertyValue"/>.
  /// </summary>
  public class NodeProperty
  {
    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

    private NodePropertyType propertyType;
    private String[] enumtypeElements;
    private String propertyName;

    public NodeProperty(NodePropertyType propertyType, String propertyName)
    {
      this.propertyType = propertyType;
      this.propertyName = propertyName;
    }

    public IReadOnlyCollection<String> getEnumElements()
    {
      if(this.propertyType != NodePropertyType.enumeration)
      {
        Logger.Error("Can not access an enum-type-list of a non-enum-type property");
        return null;
      }
      return this.enumtypeElements;
    }

    public NodePropertyType getPropertyType()
    {
      return this.propertyType;
    }

    public String getPropertyName()
    {
      return this.propertyName;
    }




    public void addEnumType(String newEnumtype)
    {
      if(this.propertyType != NodePropertyType.enumeration)
      {
        Logger.Error("EnumType can not be added, property is not of type 'enum'");
        return;
      }
      String[] oldvalues = this.enumtypeElements;
      this.enumtypeElements = new String[oldvalues.Length + 1];
      int i = 0;
      foreach(String elem in oldvalues)
      {
        this.enumtypeElements[i++] = elem;
      }
      this.enumtypeElements[i] = newEnumtype;
    }

    public void setEnumTypes(IReadOnlyCollection<String> enumtypes)
    {
      if (this.propertyType != NodePropertyType.enumeration)
      {
        Logger.Error("EnumTypes can not be set, property is not of type 'enum'");
        return;
      }
      this.enumtypeElements = new String[enumtypes.Count];
      int i = 0;
      foreach(String elem in enumtypes)
      {
        this.enumtypeElements[i++] = elem;
      }
    }

   

  }
}
