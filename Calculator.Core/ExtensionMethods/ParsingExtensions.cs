using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Core.Exceptions;

namespace Calculator.Core.ExtensionMethods
{
    public static class ParsingExtensions
    {
        public static bool IsMarkedAsBinary(this string value)
        {
            return value.StartsWith("B", StringComparison.InvariantCultureIgnoreCase);
        }

        public static decimal GetDecimalFromBinary(this string value)
        {
            return (decimal)Convert.ToInt32(value.Substring(1, value.Length - 1), 2);
        }

        public static bool IsMarkedAsHexadecimal(this string value)
        {
            return value.StartsWith("H", StringComparison.InvariantCultureIgnoreCase);
        }

        public static decimal GetDecimalFromHexadecimal(this string value)
        {
            return (decimal)Convert.ToInt32(value.Substring(1, value.Length - 1), 16);
        }

        public static bool IsValidRomanNumeral(this string value)
        {
            var romanChars = GetValidRomanNumerals();

            return value.ToUpper().ToCharArray().All(x => romanChars.ContainsKey(x));
        }

        public static decimal GetDecimalFromRomanNumeral(this string value)
        {
            //I stole this from http://stackoverflow.com/questions/14900228/roman-numbers-to-integers
            //I did modify it slightly
            var romanChars = GetValidRomanNumerals();

            int retVal = 0;
            string formattedValue = value.ToUpper();
            //go backwards
            for (int i = formattedValue.Count() - 1; i >= 0; i--)
            {
                //get current character
                char c = formattedValue.ElementAt(i);

                //error checking
                if (!romanChars.ContainsKey(c)) throw new CannotParseValueException();

                //determine if we are adding or subtracting
                bool op = formattedValue.Skip(i).Any(rn => romanChars[rn] > romanChars[c]);

                //then do so
                retVal = op ? retVal - romanChars[c] : retVal + romanChars[c];
            }

            return retVal;
        }

        private static Dictionary<char, int> GetValidRomanNumerals()
        {
            return new Dictionary<char, int> { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };
        }
    }
}
