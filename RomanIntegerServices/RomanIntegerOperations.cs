using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace RomanIntegerServices
{
    /*
     * Important Rules to forming roman numbers
     * 1. No digit is repeated in succession more the thrice. Apply to I, X, C and M
     * 2. The digits V, L and D can't be repeated
     * 3. V is never written to the left of X
     */
    
    public enum RomanDigit
    {
        I = 1,
        V = 5,
        X = 10,
        L = 50,
        C = 100,
        D = 500,
        M = 1000
    }

    public static class RomanIntegersOperations
    {
        private const int MAX_ROMAN = 3999;
        private const int MIN_ROMAN = 1;
        private static string acceptableCharacters = "IVXLCDM";
        private static String[] romanStrings = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        private static int[] integersValues = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        public static int RomanToInteger(string romanStringParameter)
        {
            var roman = romanStringParameter.ToUpper().Trim();
            
            if (!roman.All(c => acceptableCharacters.Contains(c)))
            {
                // Return an invalid value if there is any non accepted character to convert
                return 0;
            }
            else if (roman.Contains("IIII") || roman.Contains("XXXX") || roman.Contains("CCCC") ||
                     roman.Contains("MMMM"))
            {
                // Return an invalid value if the first rule doesn't complain
                return 0;
            }
            else if (roman.Count(c => c == 'V') > 1 || roman.Count(c => c == 'L') > 1 || roman.Count(c => c == 'D') > 1)
            {
                // Return an invalid value if the second rule doesn't complain
                return 0;
            }
            else if (roman.Contains("VX"))
            {
                // Return and invalid value if the third rule doesn't complain
                return 0;
            }
            
            
            var romanStringIndex = 0;
            var values = new List<int>();
            while (romanStringIndex < roman.Length)
            {
                var numeral = roman[romanStringIndex];
                var digit = (int)Enum.Parse(typeof(RomanDigit), numeral.ToString());
                
                if (romanStringIndex < roman.Length - 1)
                {
                    var nextNumeral = roman[romanStringIndex + 1];
                    var nextDigit = (int)Enum.Parse(typeof(RomanDigit), nextNumeral.ToString());

                    if (nextDigit > digit)
                    {
                        digit = nextDigit - digit;
                        romanStringIndex++;
                    }
                }

                values.Add(digit);
                romanStringIndex++;
            }

            var total = values.Sum();

            if (total <= MAX_ROMAN && total >= MIN_ROMAN)
            {
                return total;
            }
            else
            {
                return 0;
            }
        }

        public static string IntegerToRoman(int integerNumber)
        {
            var number = integerNumber;
            if (number > MAX_ROMAN || number < MIN_ROMAN)
            {
                return "error";
            }
            else
            {
                var romanValue = String.Empty;

                for (var i = 0; i < romanStrings.Length; i++)
                {
                    while (number >= integersValues[i])
                    {
                        number -= integersValues[i];
                        romanValue += romanStrings[i];
                    }
                }

                return romanValue;
            }
        }

        public static string RomanSum(string roman1, string roman2)
        {
            var integer1 = RomanToInteger(roman1);
            var integer2 = RomanToInteger(roman2);

            return IntegerToRoman(integer1 + integer2);
        }

        public static string RomanSubtraction(string roman1, string roman2)
        {
            var integer1 = RomanToInteger(roman1);
            var integer2 = RomanToInteger(roman2);

            return IntegerToRoman(integer1 - integer2);
        }

        public static string RomanMultiplication(string roman1, string roman2)
        {
            var integer1 = RomanToInteger(roman1);
            var integer2 = RomanToInteger(roman2);

            return IntegerToRoman(integer1 * integer2);
        }
        
        public static string RomanDivision(string roman1, string roman2)
        {
            var integer1 = RomanToInteger(roman1);
            var integer2 = RomanToInteger(roman2);

            return IntegerToRoman(integer1 / integer2);
        }
    }
}
