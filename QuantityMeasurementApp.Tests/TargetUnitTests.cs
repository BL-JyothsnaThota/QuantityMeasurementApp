using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace QuantityMeasurementApp.Tests
{
    public class TargetUnitTests
    {
        [Fact]
        public void Given2Point55FeetAnd2Point44Feet_WhenAdded_TargetFeet_ShouldReturn4Point99Feet()
        {
            var result = Quantity.Add(new Feet(2.55), new Feet(2.44), Unit.Feet);
            Assert.False(result.Equals(new Feet(5)));
        }

        [Theory]
        [InlineData(2,2,2.001)]
        [InlineData(1.1,2.1,3.201)]
        public void GivenFeetAndFeet_WhenAdded_TargetFeet_ShouldReturnFalse(double a,double b,double c)
        {
            var result = Quantity.Add(new Feet(a), new Feet(b), Unit.Feet);
            Assert.False(result.Equals(new Feet(c)));
        }
        // 1. Define the data source
        public static IEnumerable<object[]> GetNullData()
        {
            yield return new object[] { null, new Feet(3), Unit.Feet };
            yield return new object[] { new Feet(4), null, Unit.Yard };
        }

        // 2. Point the test to the data source
        [Theory]
        [MemberData(nameof(GetNullData))]
        public void GivenNullQuantity_WhenAdded_ShouldThrowArgumentNullException(Quantity q1, Quantity q2, Unit targetUnit)
        {
            // Now you can use the objects directly!
            Assert.Throws<ArgumentNullException>(() =>
                Quantity.Add(q1, q2, targetUnit)
            );
        }

        [Fact]
        public void GivenOtherTargetUnit_WhenAdded_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            Quantity.Add(new Feet(4), new Feet(5), (Unit)999));
        }
        [Fact]
        public void Given5FeetAnd2Feet_WhenAdded_TargetFeet_ShouldReturn7Feet()
        {
            // 5ft + 2ft = 7ft
            var result = Quantity.Add(new Feet(5), new Feet(2), Unit.Feet);
            Console.WriteLine(result);
            Assert.True(result.Equals(new Feet(7)));
        }

        [Fact]
        public void Given6FeetAnd9Feet_WhenAdded_TargetYard_ShouldReturn5Yard()
        {
            // 6ft (2yd) + 9ft (3yd) = 5yd
            var result = Quantity.Add(new Feet(6), new Feet(9), Unit.Yard);
            Assert.True(result.Equals(new Yard(5)));
        }

        [Fact]
        public void Given1FeetAnd0_5Feet_WhenAdded_TargetInch_ShouldReturn18Inch()
        {
            // 1ft (12in) + 0.5ft (6in) = 18in
            var result = Quantity.Add(new Feet(1), new Feet(0.5), Unit.Inch);
            Assert.True(result.Equals(new Inch(18)));
        }

        [Fact]
        public void Given2FeetAnd3Feet_WhenAdded_TargetCentimeter_ShouldReturn152_4Centimeter()
        {
            // 5ft total -> 5 * 30.48cm = 152.4cm
            var result = Quantity.Add(new Feet(2), new Feet(3), Unit.Centimeter);
            Assert.True(result.Equals(new Centimeter(152.4)));
        }
        [Fact]
        public void Given3FeetAnd1Yard_WhenAdded_TargetFeet_ShouldReturn6Feet()
        {
            // 3ft + 1yd (3ft) = 6ft
            var result = Quantity.Add(new Feet(3), new Yard(1), Unit.Feet);
            Assert.True(result.Equals(new Feet(6)));
        }

        [Fact]
        public void Given3FeetAnd2Yard_WhenAdded_TargetYard_ShouldReturn3Yard()
        {
            // 3ft (1yd) + 2yd = 3yd
            var result = Quantity.Add(new Feet(3), new Yard(2), Unit.Yard);
            Assert.True(result.Equals(new Yard(3)));
        }

        [Fact]
        public void Given1FeetAnd1Yard_WhenAdded_TargetInch_ShouldReturn48Inch()
        {
            // 1ft (12in) + 1yd (36in) = 48in
            var result = Quantity.Add(new Feet(1), new Yard(1), Unit.Inch);
            Assert.True(result.Equals(new Inch(48)));
        }

        [Fact]
        public void Given1FeetAnd1Yard_WhenAdded_TargetCentimeter_ShouldReturn121_92Centimeter()
        {
            // 1ft (30.48cm) + 1yd (91.44cm) = 121.92cm
            var result = Quantity.Add(new Feet(1), new Yard(1), Unit.Centimeter);
            Assert.True(result.Equals(new Centimeter(121.92)));
        }
        [Fact]
        public void Given1FeetAnd12Inch_WhenAdded_TargetFeet_ShouldReturn2Feet()
        {
            var result = Quantity.Add(new Feet(1), new Inch(12), Unit.Feet);
            Assert.True(result.Equals(new Feet(2)));
        }

        [Fact]
        public void Given3FeetAnd36Inch_WhenAdded_TargetYard_ShouldReturn2Yard()
        {
            var result = Quantity.Add(new Feet(3), new Inch(36), Unit.Yard);
            Assert.True(result.Equals(new Yard(2)));
        }

        [Fact]
        public void Given2FeetAnd6Inch_WhenAdded_TargetInch_ShouldReturn30Inch()
        {
            var result = Quantity.Add(new Feet(2), new Inch(6), Unit.Inch);
            Assert.True(result.Equals(new Inch(30)));
        }

        [Fact]
        public void Given1FeetAnd5Inch_WhenAdded_TargetCentimeter_ShouldReturn43_18Centimeter()
        {
            // (12 + 5) inches = 17 inches * 2.54 = 43.18
            var result = Quantity.Add(new Feet(1), new Inch(5), Unit.Centimeter);
            Assert.True(result.Equals(new Centimeter(43.18)));
        }
        [Fact]
        public void Given2FeetAnd30_48Centimeter_WhenAdded_TargetFeet_ShouldReturn3Feet()
        {
            var result = Quantity.Add(new Feet(2), new Centimeter(30.48), Unit.Feet);
            Assert.True(result.Equals(new Feet(3)));
        }

        [Fact]
        public void Given6FeetAnd91_44Centimeter_WhenAdded_TargetYard_ShouldReturn3Yard()
        {
            var result = Quantity.Add(new Feet(6), new Centimeter(91.44), Unit.Yard);
            Assert.True(result.Equals(new Yard(3)));
        }

        [Fact]
        public void Given1FeetAnd25_4Centimeter_WhenAdded_TargetInch_ShouldReturn22Inch()
        {
            // 12in + 10in = 22in
            var result = Quantity.Add(new Feet(1), new Centimeter(25.4), Unit.Inch);
            Assert.True(result.Equals(new Inch(22)));
        }

        [Fact]
        public void Given1FeetAnd10Centimeter_WhenAdded_TargetCentimeter_ShouldReturn40_48Centimeter()
        {
            var result = Quantity.Add(new Feet(1), new Centimeter(10), Unit.Centimeter);
            Assert.True(result.Equals(new Centimeter(40.48)));
        }
        [Fact]
        public void Given1YardAnd3Feet_WhenAdded_TargetFeet_ShouldReturn6Feet()
        {
            var result = Quantity.Add(new Yard(1), new Feet(3), Unit.Feet);
            Assert.True(result.Equals(new Feet(6)));
        }

        [Fact]
        public void Given2YardAnd3Feet_WhenAdded_TargetYard_ShouldReturn3Yard()
        {
            var result = Quantity.Add(new Yard(2), new Feet(3), Unit.Yard);
            Assert.True(result.Equals(new Yard(3)));
        }

        [Fact]
        public void Given1YardAnd1Feet_WhenAdded_TargetInch_ShouldReturn48Inch()
        {
            // 36in + 12in = 48in
            var result = Quantity.Add(new Yard(1), new Feet(1), Unit.Inch);
            Assert.True(result.Equals(new Inch(48)));
        }

        [Fact]
        public void Given1YardAnd2Feet_WhenAdded_TargetCentimeter_ShouldReturn152_4Centimeter()
        {
            // 5 feet total = 152.4 cm
            var result = Quantity.Add(new Yard(1), new Feet(2), Unit.Centimeter);
            Assert.True(result.Equals(new Centimeter(152.4)));
        }
        [Fact]
        public void Given1YardAnd1Yard_WhenAdded_TargetFeet_ShouldReturn6Feet()
        {
            var result = Quantity.Add(new Yard(1), new Yard(1), Unit.Feet);
            Assert.True(result.Equals(new Feet(6)));
        }

        [Fact]
        public void Given1_5YardAnd0_5Yard_WhenAdded_TargetYard_ShouldReturn2Yard()
        {
            var result = Quantity.Add(new Yard(1.5), new Yard(0.5), Unit.Yard);
            Assert.True(result.Equals(new Yard(2)));
        }

        [Fact]
        public void Given1YardAnd2Yard_WhenAdded_TargetInch_ShouldReturn108Inch()
        {
            var result = Quantity.Add(new Yard(1), new Yard(2), Unit.Inch);
            Assert.True(result.Equals(new Inch(108)));
        }

        [Fact]
        public void Given1YardAnd1Yard_WhenAdded_TargetCentimeter_ShouldReturn182_88Centimeter()
        {
            var result = Quantity.Add(new Yard(1), new Yard(1), Unit.Centimeter);
            Assert.True(result.Equals(new Centimeter(182.88)));
        }
        [Fact]
        public void Given1YardAnd12Inch_WhenAdded_TargetFeet_ShouldReturn4Feet()
        {
            var result = Quantity.Add(new Yard(1), new Inch(12), Unit.Feet);
            Assert.True(result.Equals(new Feet(4)));
        }

        [Fact]
        public void Given2YardAnd36Inch_WhenAdded_TargetYard_ShouldReturn3Yard()
        {
            var result = Quantity.Add(new Yard(2), new Inch(36), Unit.Yard);
            Assert.True(result.Equals(new Yard(3)));
        }

        [Fact]
        public void Given1YardAnd6Inch_WhenAdded_TargetInch_ShouldReturn42Inch()
        {
            var result = Quantity.Add(new Yard(1), new Inch(6), Unit.Inch);
            Assert.True(result.Equals(new Inch(42)));
        }

        [Fact]
        public void Given1YardAnd10Inch_WhenAdded_TargetCentimeter_ShouldReturn116_84Centimeter()
        {
            // 36 + 10 = 46 inches * 2.54 = 116.84
            var result = Quantity.Add(new Yard(1), new Inch(10), Unit.Centimeter);
            Assert.True(result.Equals(new Centimeter(116.84)));
        }
        [Fact]
        public void Given1YardAnd30_48Centimeter_WhenAdded_TargetFeet_ShouldReturn4Feet()
        {
            var result = Quantity.Add(new Yard(1), new Centimeter(30.48), Unit.Feet);
            Assert.True(result.Equals(new Feet(4)));
        }

        [Fact]
        public void Given2YardAnd91_44Centimeter_WhenAdded_TargetYard_ShouldReturn3Yard()
        {
            var result = Quantity.Add(new Yard(2), new Centimeter(91.44), Unit.Yard);
            Assert.True(result.Equals(new Yard(3)));
        }

        [Fact]
        public void Given1YardAnd25_4Centimeter_WhenAdded_TargetInch_ShouldReturn46Inch()
        {
            var result = Quantity.Add(new Yard(1), new Centimeter(25.4), Unit.Inch);
            Assert.True(result.Equals(new Inch(46)));
        }

        [Fact]
        public void Given1YardAnd5Centimeter_WhenAdded_TargetCentimeter_ShouldReturn96_44Centimeter()
        {
            var result = Quantity.Add(new Yard(1), new Centimeter(5), Unit.Centimeter);
            Assert.True(result.Equals(new Centimeter(96.44)));
        }
        [Fact]
        public void Given24InchAnd1Feet_WhenAdded_TargetFeet_ShouldReturn3Feet()
        {
            var result = Quantity.Add(new Inch(24), new Feet(1), Unit.Feet);
            Assert.True(result.Equals(new Feet(3)));
        }

        [Fact]
        public void Given72InchAnd1Feet_WhenAdded_TargetYard_ShouldReturn2_333Yard()
        {
            // 2yd + 0.333yd
            var result = Quantity.Add(new Inch(72), new Feet(1), Unit.Yard);
            Assert.True(result.Equals(new Yard(2.3333333333333335)));
        }

        [Fact]
        public void Given6InchAnd2Feet_WhenAdded_TargetInch_ShouldReturn30Inch()
        {
            var result = Quantity.Add(new Inch(6), new Feet(2), Unit.Inch);
            Assert.True(result.Equals(new Inch(30)));
        }

        [Fact]
        public void Given12InchAnd1Feet_WhenAdded_TargetCentimeter_ShouldReturn60_96Centimeter()
        {
            var result = Quantity.Add(new Inch(12), new Feet(1), Unit.Centimeter);
            Assert.True(result.Equals(new Centimeter(60.96)));
        }
        [Fact]
        public void Given36InchAnd1Yard_WhenAdded_TargetFeet_ShouldReturn6Feet()
        {
            var result = Quantity.Add(new Inch(36), new Yard(1), Unit.Feet);
            Assert.True(result.Equals(new Feet(6)));
        }

        [Fact]
        public void Given18InchAnd0_5Yard_WhenAdded_TargetYard_ShouldReturn1Yard()
        {
            var result = Quantity.Add(new Inch(18), new Yard(0.5), Unit.Yard);
            Assert.True(result.Equals(new Yard(1)));
        }

        [Fact]
        public void Given10InchAnd1Yard_WhenAdded_TargetInch_ShouldReturn46Inch()
        {
            var result = Quantity.Add(new Inch(10), new Yard(1), Unit.Inch);
            Assert.True(result.Equals(new Inch(46)));
        }

        [Fact]
        public void Given5InchAnd1Yard_WhenAdded_TargetCentimeter_ShouldReturn104_14Centimeter()
        {
            // (5 + 36) * 2.54 = 104.14
            var result = Quantity.Add(new Inch(5), new Yard(1), Unit.Centimeter);
            Assert.True(result.Equals(new Centimeter(104.14)));
        }
        [Fact]
        public void Given24InchAnd12Inch_WhenAdded_TargetFeet_ShouldReturn3Feet()
        {
            var result = Quantity.Add(new Inch(24), new Inch(12), Unit.Feet);
            Assert.True(result.Equals(new Feet(3)));
        }

        [Fact]
        public void Given36InchAnd72Inch_WhenAdded_TargetYard_ShouldReturn3Yard()
        {
            var result = Quantity.Add(new Inch(36), new Inch(72), Unit.Yard);
            Assert.True(result.Equals(new Yard(3)));
        }

        [Fact]
        public void Given15InchAnd15Inch_WhenAdded_TargetInch_ShouldReturn30Inch()
        {
            var result = Quantity.Add(new Inch(15), new Inch(15), Unit.Inch);
            Assert.True(result.Equals(new Inch(30)));
        }

        [Fact]
        public void Given1InchAnd1Inch_WhenAdded_TargetCentimeter_ShouldReturn5_08Centimeter()
        {
            var result = Quantity.Add(new Inch(1), new Inch(1), Unit.Centimeter);
            Assert.True(result.Equals(new Centimeter(5.08)));
        }
        [Fact]
        public void Given12InchAnd30_48Centimeter_WhenAdded_TargetFeet_ShouldReturn2Feet()
        {
            var result = Quantity.Add(new Inch(12), new Centimeter(30.48), Unit.Feet);
            Assert.True(result.Equals(new Feet(2)));
        }

        [Fact]
        public void Given36InchAnd91_44Centimeter_WhenAdded_TargetYard_ShouldReturn2Yard()
        {
            var result = Quantity.Add(new Inch(36), new Centimeter(91.44), Unit.Yard);
            Assert.True(result.Equals(new Yard(2)));
        }

        [Fact]
        public void Given5InchAnd12_7Centimeter_WhenAdded_TargetInch_ShouldReturn10Inch()
        {
            // 5in + 5in = 10in
            var result = Quantity.Add(new Inch(5), new Centimeter(12.7), Unit.Inch);
            Assert.True(result.Equals(new Inch(10)));
        }

        [Fact]
        public void Given2InchAnd5Centimeter_WhenAdded_TargetCentimeter_ShouldReturn10_08Centimeter()
        {
            // (2 * 2.54) + 5 = 10.08
            var result = Quantity.Add(new Inch(2), new Centimeter(5), Unit.Centimeter);
            Assert.True(result.Equals(new Centimeter(10.08)));
        }

        [Fact]
        public void Given30_48CentimeterAnd1Feet_WhenAdded_TargetFeet_ShouldReturn2Feet()
        {
            var result = Quantity.Add(new Centimeter(30.48), new Feet(1), Unit.Feet);
            Assert.True(result.Equals(new Feet(2)));
        }

        [Fact]
        public void Given60_96CentimeterAnd1Feet_WhenAdded_TargetYard_ShouldReturn1Yard()
        {
            // 2ft + 1ft = 3ft (1yd)
            var result = Quantity.Add(new Centimeter(60.96), new Feet(1), Unit.Yard);
            Assert.True(result.Equals(new Yard(1)));
        }

        [Fact]
        public void Given25_4CentimeterAnd2Feet_WhenAdded_TargetInch_ShouldReturn34Inch()
        {
            // 10in + 24in = 34in
            var result = Quantity.Add(new Centimeter(25.4), new Feet(2), Unit.Inch);
            Assert.True(result.Equals(new Inch(34)));
        }

        [Fact]
        public void Given10CentimeterAnd1Feet_WhenAdded_TargetCentimeter_ShouldReturn40_48Centimeter()
        {
            var result = Quantity.Add(new Centimeter(10), new Feet(1), Unit.Centimeter);
            Assert.True(result.Equals(new Centimeter(40.48)));
        }
        [Fact]
        public void Given91_44CentimeterAnd1Yard_WhenAdded_TargetFeet_ShouldReturn6Feet()
        {
            // 3ft + 3ft = 6ft
            var result = Quantity.Add(new Centimeter(91.44), new Yard(1), Unit.Feet);
            Assert.True(result.Equals(new Feet(6)));
        }

        [Fact]
        public void Given182_88CentimeterAnd1Yard_WhenAdded_TargetYard_ShouldReturn3Yard()
        {
            // 2yd + 1yd = 3yd
            var result = Quantity.Add(new Centimeter(182.88), new Yard(1), Unit.Yard);
            Assert.True(result.Equals(new Yard(3)));
        }

        [Fact]
        public void Given25_4CentimeterAnd1Yard_WhenAdded_TargetInch_ShouldReturn46Inch()
        {
            // 10in + 36in = 46in
            var result = Quantity.Add(new Centimeter(25.4), new Yard(1), Unit.Inch);
            Assert.True(result.Equals(new Inch(46)));
        }

        [Fact]
        public void Given50CentimeterAnd2Yard_WhenAdded_TargetCentimeter_ShouldReturn232_88Centimeter()
        {
            // 50 + 182.88 = 232.88
            var result = Quantity.Add(new Centimeter(50), new Yard(2), Unit.Centimeter);
            Assert.True(result.Equals(new Centimeter(232.88)));
        }
        [Fact]
        public void Given30_48CentimeterAnd12Inch_WhenAdded_TargetFeet_ShouldReturn2Feet()
        {
            var result = Quantity.Add(new Centimeter(30.48), new Inch(12), Unit.Feet);
            Assert.True(result.Equals(new Feet(2)));
        }

        [Fact]
        public void Given91_44CentimeterAnd36Inch_WhenAdded_TargetYard_ShouldReturn2Yard()
        {
            var result = Quantity.Add(new Centimeter(91.44), new Inch(36), Unit.Yard);
            Assert.True(result.Equals(new Yard(2)));
        }

        [Fact]
        public void Given50_8CentimeterAnd10Inch_WhenAdded_TargetInch_ShouldReturn30Inch()
        {
            // 20in + 10in = 30in
            var result = Quantity.Add(new Centimeter(50.8), new Inch(10), Unit.Inch);
            Assert.True(result.Equals(new Inch(30)));
        }

        [Fact]
        public void Given10CentimeterAnd5Inch_WhenAdded_TargetCentimeter_ShouldReturn22_7Centimeter()
        {
            // 10 + 12.7 = 22.7
            var result = Quantity.Add(new Centimeter(10), new Inch(5), Unit.Centimeter);
            Assert.True(result.Equals(new Centimeter(22.7)));
        }
        [Fact]
        public void Given60_96CentimeterAnd30_48Centimeter_WhenAdded_TargetFeet_ShouldReturn3Feet()
        {
            var result = Quantity.Add(new Centimeter(60.96), new Centimeter(30.48), Unit.Feet);
            Assert.True(result.Equals(new Feet(3)));
        }

        [Fact]
        public void Given182_88CentimeterAnd91_44Centimeter_WhenAdded_TargetYard_ShouldReturn3Yard()
        {
            var result = Quantity.Add(new Centimeter(182.88), new Centimeter(91.44), Unit.Yard);
            Assert.True(result.Equals(new Yard(3)));
        }

        [Fact]
        public void Given25_4CentimeterAnd25_4Centimeter_WhenAdded_TargetInch_ShouldReturn20Inch()
        {
            var result = Quantity.Add(new Centimeter(25.4), new Centimeter(25.4), Unit.Inch);
            Assert.True(result.Equals(new Inch(20)));
        }

        [Fact]
        public void Given100CentimeterAnd50Centimeter_WhenAdded_TargetCentimeter_ShouldReturn150Centimeter()
        {
            var result = Quantity.Add(new Centimeter(100), new Centimeter(50), Unit.Centimeter);
            Assert.True(result.Equals(new Centimeter(150)));
        }

        [Fact]
        public void Given1FeetAnd12Inch_WhenAdded_TargetInch_ShouldReturn24Inch()
        {
            var result = Quantity.Add(new Feet(1), new Inch(12), Unit.Inch);
            Assert.True(result.Equals(new Inch(24)));
        }

        [Fact]
        public void Given1FeetAnd12Inch_WhenAdded_TargetYard_ShouldReturnPoint666667Yard()
        {
            var result = Quantity.Add(new Feet(1), new Inch(12), Unit.Yard);
            Assert.True(result.Equals(new Yard(0.666667)));
        }
    }
}
