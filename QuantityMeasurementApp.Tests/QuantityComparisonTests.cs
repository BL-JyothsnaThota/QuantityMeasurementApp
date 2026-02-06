using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantityMeasurementApp.Tests
{
    public class QuantityComparisonTests
    {
        [Fact]
        public void Given1FeetAnd12Inch_WhenCompared_ShouldReturnTrue()
        {
            var feet = new Feet(1);
            var inch = new Inch(12);

            Assert.True(feet.Equals(inch));
        }

        [Fact]
        public void Given2FeetAnd24Inch_WhenCompared_ShouldReturnTrue()
        {
            var feet = new Feet(2);
            var inch = new Inch(24);

            Assert.True(feet.Equals(inch));
        }

        [Fact]
        public void Given1FeetAnd10Inch_WhenCompared_ShouldReturnFalse()
        {
            var feet = new Feet(1);
            var inch = new Inch(10);

            Assert.False(feet.Equals(inch));
        }

        
        [Fact]
        public void Given1YardAnd3Feet_WhenCompared_ShouldReturnTrue()
        {
            Assert.True(new Yard(1).Equals(new Feet(3)));
        }

        [Fact]
        public void Given2FeetAnd60Centimeter_WhenCompared_ShouldReturnFalse()
        {
            Assert.False(new Feet(2).Equals(new Centimeter(60)));
        }
    }
}
