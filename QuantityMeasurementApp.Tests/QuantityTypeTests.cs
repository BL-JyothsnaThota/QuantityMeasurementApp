using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantityMeasurementApp.Tests
{
    public class QuantityTypeTests
    {
        private class DummyVolume : Quantity
        {
            public DummyVolume(double value)
                : base(value, Unit.Inch, QuantityType.Volume)
            {
            }
        }

        [Fact]
        public void GivenLengthAndVolume_WhenCompared_ShouldReturnFalse()
        {
            var length = new Feet(1);
            var volume = new DummyVolume(12);

            Assert.False(length.Equals(volume));
        }
    }
}
