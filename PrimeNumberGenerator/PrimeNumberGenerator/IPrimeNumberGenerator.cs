using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumberGenerator
{
    public interface IPrimeNumberGenerator
    {
        IEnumerable<long> ExecuteWithYield(long primeNumbersToBeGeneratedCount);
    }
}
