using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumberGenerator
{
    /*
     created only for testing purposes
    */
    public class PrimeNumberSieveOfEratosthenes
    {
        public IEnumerable<long> GenerateAllPreviousPrimeNumbers(long n)
        {
            bool[] prime = new bool[n + 1];

            for (long i = 0; i < n; i++)
            {
                prime[i] = true;
            }

            for (long p = 2; p * p <= n; p++)
            {
                if (prime[p] == true)
                {
                    // Update all multiples of p
                    for (long i = p * p; i <= n; i += p)
                        prime[i] = false;
                }
            }
            for (long i = 2; i <= n; i++)
            {
                if (prime[i] == true)
                {
                    yield return i;
                }
            }
        }
    }
}
