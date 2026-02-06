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
        protected readonly QuantityType QuantityType;

        protected Quantity(double value, Unit unit, QuantityType quantityType)
        {
            Value = value;
            Unit = unit;
            QuantityType = quantityType;
        }

        private double ConvertToBaseUnit()
        {
            return Unit switch
            {
                Unit.Feet => Value * 12,
                Unit.Inch => Value,
                Unit.Yard => Value * 36,
                Unit.Centimeter => Value * 0.393701,

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

            // 🔒 UC5 core rule
            if (this.QuantityType != other.QuantityType)
                return false;

            return ConvertToBaseUnit().Equals(other.ConvertToBaseUnit());
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ConvertToBaseUnit(), QuantityType);
        }
    }
}
