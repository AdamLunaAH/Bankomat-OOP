﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    public class InputValidator
    {

        public bool IsEmpty(string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        public bool IsNumber(string input)
        {
            return int.TryParse(input, out _);
        }

        public bool IsNumberDecimal(string input)
        {
            return decimal.TryParse(input, out _);
        }

        public bool IsDecimalNegative(string input)
        {
            if (decimal.TryParse(input, out decimal result))
            {
                return result < 0;
            }
            return false;
        }

        public bool IsDecimalBetweenZeroAndFive(string input)
        {
            if (decimal.TryParse(input, out decimal result))
            {
                return result >= 0 && result <= 5;
            }
            return false;
        }

        public bool IsGreaterThanBalance(string input, decimal accountBalance)
        {
            if (decimal.TryParse(input, out decimal result))
            {
                return result > accountBalance;
            }
            return false;
        }

        public int ConvertToInt(string input)
        {
            return int.Parse(input);
        }

        public decimal ConvertToDecimal(string input)
        {
            return Math.Round(decimal.Parse(input), 2);
        }

    }
}
