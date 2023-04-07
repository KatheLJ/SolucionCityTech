using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generales
{
    public class ToolGenerales
    {

        public static decimal CalcularCostoProd (decimal Costo)
        {
            return Costo * Convert.ToDecimal(1.14);
        }
    }
}
