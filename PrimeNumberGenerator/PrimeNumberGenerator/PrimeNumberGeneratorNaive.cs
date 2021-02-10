using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumberGenerator
{
    public class PrimeNumberGeneratorNaive : IPrimeNumberGenerator
    {
        public IEnumerable<long> ExecuteWithYield(long primeNumbersToBeGeneratedCount)
        {
            if (primeNumbersToBeGeneratedCount < 1)
            {
                throw new ArgumentException();
            }
            return Execute(primeNumbersToBeGeneratedCount);
        }

        private IEnumerable<long> Execute(long primeNumbersToBeGeneratedCount)
        {
            List<long> primes = new List<long>();
            primes.Add(2);
            yield return 2;

            long nextPrime = 3;
            while (primes.Count < primeNumbersToBeGeneratedCount)
            {
                long sqrt = (long)Math.Sqrt(nextPrime);
                bool isPrime = true;
                for (int i = 0; (long)primes[i] <= sqrt; i++)
                {
                    if (nextPrime % primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(nextPrime);
                    yield return nextPrime;
                }
                nextPrime += 2;
            }
        }
    }
}
