using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantityMeasurementApp
{
    public class Centimeter : Quantity
    {
        public Centimeter(double value)
            : base(value, Unit.Centimeter, QuantityType.Length)
        {
        }
    }
}
