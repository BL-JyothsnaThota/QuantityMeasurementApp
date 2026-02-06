using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantityMeasurementApp
{
    public class Yard : Quantity
    {
        public Yard(double value)
            : base(value, Unit.Yard, QuantityType.Length)
        {
        }
    }
}
