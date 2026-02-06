using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantityMeasurementApp.Tests
{
    public class FeetTests
    {
        [Fact]
        public void GivenSameFeetValues_WhenCompared_ShouldReturnTrue()
        {
            var feet1 = new Feet(1.0);
            var feet2 = new Feet(1.0);

            Assert.True(feet1.Equals(feet2));
        }

        [Fact]
        public void GivenDifferentFeetValues_WhenCompared_ShouldReturnFalse()
        {
            var feet1 = new Feet(1.0);
            var feet2 = new Feet(2.0);

            Assert.False(feet1.Equals(feet2));
        }

        [Fact]
        public void GivenFeet_WhenComparedWithNull_ShouldReturnFalse()
        {
            var feet = new Feet(1.0);

            Assert.False(feet.Equals(null));
        }

        [Fact]
        public void GivenSameFeetReference_WhenCompared_ShouldReturnTrue()
        {
            var feet = new Feet(1.0);

            Assert.True(feet.Equals(feet));
        }

        [Fact]
        public void GivenFeet_WhenComparedWithDifferentType_ShouldReturnFalse()
        {
            var feet = new Feet(1.0);
            var notFeet = 1.0;

            Assert.False(feet.Equals(notFeet));
        }
    }
}
