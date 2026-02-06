using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantityMeasurementApp
{
    public abstract class Quantity
    {
        protected readonly double Value;
        protected readonly Unit Unit;

        protected Quantity(double value, Unit unit)
        {
            Value = value;
            Unit = unit;
        }

        private double ConvertToBaseUnit()
        {
            return Unit switch
            {
                Unit.Feet => Value * 12,
                Unit.Inch => Value,
                _ => throw new InvalidOperationException("Unknown unit")
            };
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj is null)
                return false;

            if (obj is not Quantity other)
                return false;

            return ConvertToBaseUnit().Equals(other.ConvertToBaseUnit());
        }

        public override int GetHashCode()
        {
            return ConvertToBaseUnit().GetHashCode();
        }
    }
}
