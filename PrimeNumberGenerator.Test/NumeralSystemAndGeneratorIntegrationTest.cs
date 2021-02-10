using System;
using System.Collections.Generic;
using Xunit;
using System.Collections;
using System.Linq;
using PrimeNumberGenerator.NumeralSystem;

namespace PrimeNumberGenerator.Test
{
    public class NumeralSystemAndGeneratorIntegrationTest
    {
        [Fact]
        public void NumeralSystemAndGeneratorIntegrationTest_ThrowsArgumentException_Test()
        {
            //Assign
            var inputInBase13 = "0";
            var numeralSystemConverter = new NumeralSystemConverter();
            var primeNumberGenerator = new PrimeNumberGeneratorNaive();
            //Act
            var inputInDecimal = numeralSystemConverter.ArbitraryToDecimalSystem(inputInBase13, 13);
            //Assert
            Assert.Throws<ArgumentException>(() => primeNumberGenerator.ExecuteWithYield(inputInDecimal));
        }
        [Fact]
        public void NumeralSystemAndGeneratorIntegrationTest_Equal_Test()
        {
            //Assign
            var primeNumberInBase13HardCoded = new List<string>()
            {
               "2", "3", "5", "7", "B", "10"
            };
            var numeralSystemConverter = new NumeralSystemConverter();
            var primeNumberGenerator = new PrimeNumberGeneratorNaive();
            //Act
            var primeNumberGeneratedInBase13 = new List<string>();
            foreach (long primeNumber in primeNumberGenerator.ExecuteWithYield(primeNumberInBase13HardCoded.Count))
            {
                primeNumberGeneratedInBase13.Add(numeralSystemConverter.DecimalToArbitrarySystem(primeNumber, 13));
            }
            var result = (primeNumberGeneratedInBase13.Count == primeNumberInBase13HardCoded.Count
                && (!primeNumberGeneratedInBase13.Except(primeNumberInBase13HardCoded).Any() || !primeNumberInBase13HardCoded.Except(primeNumberGeneratedInBase13).Any()));
            //Assert
            Assert.True(result);
        }
        [Fact]
        public void NumeralSystemAndGeneratorIntegrationTest_NotEqual_Test()
        {
            //Assign
            var primeNumberInBase13HardCoded = new List<string>()
            {
               "2", "3", "5", "7", "A", "10"
            };
            var numeralSystemConverter = new NumeralSystemConverter();
            var primeNumberGenerator = new PrimeNumberGeneratorNaive();
            //Act
            var primeNumberGeneratedInBase13 = new List<string>();
            foreach (long primeNumber in primeNumberGenerator.ExecuteWithYield(primeNumberInBase13HardCoded.Count))
            {
                primeNumberGeneratedInBase13.Add(numeralSystemConverter.DecimalToArbitrarySystem(primeNumber, 13));
            }
            var result = (primeNumberGeneratedInBase13.Count == primeNumberInBase13HardCoded.Count
                && (!primeNumberGeneratedInBase13.Except(primeNumberInBase13HardCoded).Any() || !primeNumberInBase13HardCoded.Except(primeNumberGeneratedInBase13).Any()));
            //Assert
            Assert.False(result);
        }
    }
}
