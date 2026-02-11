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

            //return ConvertToBaseUnit().Equals(other.ConvertToBaseUnit());
            return Math.Abs(this.ConvertToBaseUnit() - other.ConvertToBaseUnit()) < 0.0001;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ConvertToBaseUnit(), QuantityType);
        }

        public static Quantity Add(Quantity q1, Quantity q2, Unit targetUnit)
        {
            if (q1 == null || q2 == null)
                throw new ArgumentNullException("Quantities cannot be null");

            if (!Enum.IsDefined(typeof(Unit), targetUnit))
                throw new ArgumentException("Invalid target unit");

            if (q1.QuantityType != q2.QuantityType)
                throw new InvalidOperationException("Cannot add different quantity types");

            if (!double.IsFinite(q1.Value) || !double.IsFinite(q2.Value))
                throw new ArgumentException("Values must be finite numbers");

            // Convert both to base unit (FEET for Length)
            double baseSum =
                q1.ConvertToBaseUnit() + q2.ConvertToBaseUnit();

            // Convert base sum to target unit
            double convertedValue = ConvertFromBaseUnit(baseSum, targetUnit);

            return CreateQuantity(convertedValue, targetUnit);
        }

        protected static Quantity CreateQuantity(double value, Unit unit)
        {
            return unit switch
            {
                Unit.Feet => new Feet(value),
                Unit.Inch => new Inch(value),
                Unit.Yard => new Yard(value),
                Unit.Centimeter => new Centimeter(value),
                _ => throw new ArgumentException("Unsupported unit")
            };
        }

        protected static double ConvertFromBaseUnit(double baseValue, Unit unit)
        {
            return unit switch
            {
                //Unit.Feet => baseValue,
                //Unit.Inch => baseValue * 12,
                //Unit.Yard => baseValue / 3,
                //Unit.Centimeter => baseValue * 30.48,
                Unit.Feet => baseValue / 12,
                Unit.Inch => baseValue,
                Unit.Yard => baseValue / 36,
                Unit.Centimeter => baseValue * 2.54,
                _ => throw new ArgumentException("Unsupported unit")
            };
        }

    }
}
