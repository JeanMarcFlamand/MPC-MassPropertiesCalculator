using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPC_MassPropertiesCalculator;
class ConsolePrintaTable
{
    private const int _tableWidth = 100;
    static public void PrintRowSeperator()
  {
      Console.WriteLine(new string ('_',_tableWidth) );
  }
}
