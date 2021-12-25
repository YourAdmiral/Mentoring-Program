using System;
using System.Collections.Generic;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            List<int> numbers = new List<int>();

            long longValue = 0;

            int intValue = 0;

            int multiplier = 1;

            bool isPositive = true;

            if (stringValue == null)
            {
                throw new ArgumentNullException();
            }

            if (stringValue.Trim() == "")
            {
                throw new FormatException();
            }

            stringValue = stringValue.Trim();

            if (stringValue.StartsWith('+'))
            {
                stringValue = stringValue.Remove(0, 1);
            }
            else if (stringValue.StartsWith('-'))
            {
                stringValue = stringValue.Remove(0, 1);

                isPositive = false;
            }

            for (int i = 0; i < stringValue.Length; i++)
            {
                switch (stringValue[i])
                {
                    case '0':
                        numbers.Add(0);
                        break;

                    case '1':
                        numbers.Add(1);
                        break;

                    case '2':
                        numbers.Add(2);
                        break;

                    case '3':
                        numbers.Add(3);
                        break;

                    case '4':
                        numbers.Add(4);
                        break;

                    case '5':
                        numbers.Add(5);
                        break;

                    case '6':
                        numbers.Add(6);
                        break;

                    case '7':
                        numbers.Add(7);
                        break;

                    case '8':
                        numbers.Add(8);
                        break;

                    case '9':
                        numbers.Add(9);
                        break;

                    default:
                        throw new FormatException("Value is not valid");
                }
            }

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                try
                {
                    numbers[i] = numbers[i] * multiplier;

                    longValue += numbers[i];

                    multiplier = multiplier * 10;
                }
                catch (Exception)
                {
                    throw;
                }

            }

            if (!isPositive)
            {
                longValue = longValue * -1;
            }

            if (longValue > int.MaxValue || longValue < int.MinValue)
            {
                throw new OverflowException();
            }

            intValue = (int) longValue;

            return intValue;
        }
    }
}