using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantityMeasurementApp.Tests
{
    public class InchTests
    {
        [Fact]
        public void GivenSameInchValues_WhenCompared_ShouldReturnTrue()
        {
            var inch1 = new Inch(1.0);
            var inch2 = new Inch(1.0);

            Assert.True(inch1.Equals(inch2));
        }

        [Fact]
        public void GivenDifferentInchValues_WhenCompared_ShouldReturnFalse()
        {
            var inch1 = new Inch(1.0);
            var inch2 = new Inch(2.0);

            Assert.False(inch1.Equals(inch2));
        }

        [Fact]
        public void GivenInch_WhenComparedWithNull_ShouldReturnFalse()
        {
            var inch = new Inch(1.0);

            Assert.False(inch.Equals(null));
        }

        [Fact]
        public void GivenSameInchReference_WhenCompared_ShouldReturnTrue()
        {
            var inch = new Inch(1.0);

            Assert.True(inch.Equals(inch));
        }

        [Fact]
        public void GivenInch_WhenComparedWithDifferentType_ShouldReturnFalse()
        {
            var inch = new Inch(1.0);

            Assert.False(inch.Equals(new Feet(1.0)));
        }
    }
}
