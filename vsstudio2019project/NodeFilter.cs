using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MMD_Graph_Studio
{

  public enum filterOperator
  {
    equals,
    greater,
    less,
    greaterequal,
    lessequal,
    unequal
  }

  class NodeFilter
  {
    private string filterName = "unknown";
    private string filterattribute = "name";
    private filterOperator filteroperator = filterOperator.equals;
    private string filterstring = "Emma.*";
    private int filternumber = 0;
    private string filterenumstring = "";

    public bool matchNode(Node node)
    {
      if(node == null)
      {
        return false;
      }
      bool result = false;
      if(string.Equals(filterattribute,"name",StringComparison.InvariantCultureIgnoreCase))
      {
        if(filteroperator.Equals(filterOperator.equals))
        {
          Regex expression = new Regex(filterstring);
          if( expression.IsMatch( node.GetName()) )
          {
            result = true;
          }
        }
      }
      return result;
    }

  }
}
