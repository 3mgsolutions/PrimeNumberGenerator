using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumberGenerator.NumeralSystem
{
    public interface INumeralSystemConverter
    {
        string DecimalToArbitrarySystem(long decimalNumber, int radix);

        long ArbitraryToDecimalSystem(string number, int radix);
    }
}
