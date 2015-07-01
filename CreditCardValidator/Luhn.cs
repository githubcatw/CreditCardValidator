﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator
{
    public static class Luhn
    {
        //Convert to int
        static Func<char, int> charToInt = c => c - '0';

        static Func<int, bool> isEven = i => i % 2 == 0;

        //New Double Concept => 7 * 2 = 14 => 1 + 4 = 5
        static Func<int, int> doubleDigit = i => (i * 2).ToString().Select(charToInt).Sum();

        public static bool CheckLuhn(String creditCardNumber)
        {
            var checkSum = creditCardNumber
                .Select(charToInt)
                .Reverse()
                .Select((digit, index) => isEven(index + 1) ? doubleDigit(digit) : digit)
                .Sum();

            return checkSum % 10 == 0;
        }

        public static String CreateCheckDigit()
        {
            throw new NotImplementedException();
        }
    }
}
