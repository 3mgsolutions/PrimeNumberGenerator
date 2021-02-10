using PrimeNumberGenerator.NumeralSystem;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PrimeNumberGenerator.Test
{
    public class NumeralSystemConverterTest
    {
        [Fact]
        public void NumeralSystemConverter_DecimalToBase13_Test()
        {
            //Assign
            var numeralSystemConverter = new NumeralSystemConverter();
            Dictionary<int, string> decimalBase13Set = new Dictionary<int, string>()
            { { 0, "0"}, {1, "1"}, {9, "9"}, {10, "A" }, {11, "B"}, {12, "C" }, {13, "10" }, {14, "11" }, {15, "12" }, {16, "13" } };
            foreach (var decimalBase13Pair in decimalBase13Set)
            {
                //Act
                var result = numeralSystemConverter.DecimalToArbitrarySystem(decimalBase13Pair.Key, 13);
                //Asert
                Assert.Equal(decimalBase13Pair.Value, result);
            }
        }

        [Fact]
        public void NumeralSystemConverter_Base13ToDecimal_Test()
        {
            //Assign
            var numeralSystemConverter = new NumeralSystemConverter();
            Dictionary<int, string> decimalBase13Set = new Dictionary<int, string>()
            { { 0, "0"}, {1, "1"}, {9, "9"}, {10, "A" }, {11, "B"}, {12, "C" }, {13, "10" }, {14, "11" }, {15, "12" }, {16, "13" } };
            foreach (var decimalBase13Pair in decimalBase13Set)
            {
                //Act
                var result = numeralSystemConverter.ArbitraryToDecimalSystem(decimalBase13Pair.Value, 13);
                //Asert
                Assert.Equal(decimalBase13Pair.Key, result);
            }
        }
    }
}
