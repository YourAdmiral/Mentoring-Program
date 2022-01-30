using System;
using System.Collections.Generic;

namespace StringSum
{
    public static class StringSummer
    {
        public static string Sum(string num1, string num2)
        {
            var firstNumber = NumberParser.Parse(num1);

            var secondNumber = NumberParser.Parse(num2);

            int finalNumber = 0;

            var numbers = new Dictionary<int, bool>();

            numbers.Add(firstNumber, IsNaturalNumber(firstNumber));

            numbers.Add(secondNumber, IsNaturalNumber(secondNumber));

            foreach (var item in numbers)
            {
                if (item.Value)
                {
                    finalNumber += item.Key;
                }
            }

            return finalNumber.ToString();
        }

        private static bool IsNaturalNumber(int num)
        {
            bool isNatural = true;

            if (num <= 0)
            {
                isNatural = false;
            }
            else
            {
                for (int i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        isNatural = false;
                        break;
                    }
                }
            }

            return isNatural;
        }
    }
}
