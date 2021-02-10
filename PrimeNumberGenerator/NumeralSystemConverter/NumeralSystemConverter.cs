using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumberGenerator.NumeralSystem
{
    public class NumeralSystemConverter : INumeralSystemConverter
    {
        private const string allNumeralSystemChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string DecimalToArbitrarySystem(long decimalNumber, int radix)
        {
            var allowedChars = allNumeralSystemChars.Substring(0, radix);
            const int BitsInLong = 64;
            if (radix < 2 || radix > allowedChars.Length)
            {
                throw new ArgumentException("The radix must be >= 2 and <= " + allowedChars.Length.ToString());
            }
            if (decimalNumber == 0)
            {
                return "0";
            }
            int index = BitsInLong - 1;
            long currentNumber = Math.Abs(decimalNumber);
            char[] charArray = new char[BitsInLong];
            while (currentNumber != 0)
            {
                int remainder = (int)(currentNumber % radix);
                charArray[index--] = allowedChars[remainder];
                currentNumber /= radix;
            }
            string result = new String(charArray, index + 1, BitsInLong - index - 1);
            if (decimalNumber < 0)
            {
                result = "-" + result;
            }
            return result;
        }

        public long ArbitraryToDecimalSystem(string number, int radix)
        {
            var allowedChars = allNumeralSystemChars.Substring(0, radix);
            if (radix < 2 || radix > allowedChars.Length)
            {
                throw new ArgumentException("The radix must be >= 2 and <= " + allowedChars.Length.ToString());
            }
            if (String.IsNullOrEmpty(number))
            {
                return 0;
            }
            number = number.ToUpperInvariant();
            long result = 0;
            long multiplier = 1;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                char c = number[i];
                if (i == 0 && c == '-')
                {
                    // This is the negative sign symbol
                    result = -result;
                    break;
                }
                int digit = allowedChars.IndexOf(c);
                if (digit == -1)
                {
                    throw new ArgumentException("Invalid character in the arbitrary numeral system number", "number");
                }
                result += digit * multiplier;
                multiplier *= radix;
            }
            return result;
        }
    }
}
