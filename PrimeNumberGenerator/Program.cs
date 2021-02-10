using Microsoft.Extensions.DependencyInjection;
using PrimeNumberGenerator.NumeralSystem;
using System;

namespace PrimeNumberGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<INumeralSystemConverter, NumeralSystemConverter>()
                .AddSingleton<IPrimeNumberGenerator, PrimeNumberGeneratorNaive>()
                .BuildServiceProvider();

            var numeralSystemConverter = serviceProvider.GetService<INumeralSystemConverter>();
            var primeNumberGenerator = serviceProvider.GetService<IPrimeNumberGenerator>();

            Console.WriteLine("Please, enter a Base13 value: ");
            var inputInBase13 = Console.ReadLine();
            try
            {
                var inputAsLong = numeralSystemConverter.ArbitraryToDecimalSystem(inputInBase13, 13);
                Console.WriteLine("All prime numbers before: " + inputAsLong);
                foreach (long primeNumber in primeNumberGenerator.ExecuteWithYield(inputAsLong))
                {
                    Console.WriteLine(numeralSystemConverter.DecimalToArbitrarySystem(primeNumber, 13));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
