using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MMDGraphStudio
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
    private bool useRegex = false;

    public NodeFilter(string name, string filterAttrib, filterOperator foperator, string filterstring, int filternumber, string filterenumstring, bool useRegex = false)
    {
      this.filterName = name;
      this.filterattribute = filterAttrib;
      this.filteroperator = foperator;
      this.filternumber = filternumber;
      this.filterenumstring = filterenumstring;
      this.useRegex = useRegex;
      if(this.useRegex)
      {
        this.filterstring = filterstring;
      }
      else
      {
        this.filterstring = ".*" + filterstring + ".*";
      }
    }

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
