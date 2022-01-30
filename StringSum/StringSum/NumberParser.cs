using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSum
{
    public static class NumberParser
    {
        public static int Parse(string stringValue)
        {
            List<int> numbers;

            int intValue;

            bool isPositive = true;

            CheckStringValidity(stringValue);

            stringValue = stringValue.Trim();

            if (stringValue.StartsWith("+"))
            {
                stringValue = stringValue.Remove(0, 1);
            }
            else if (stringValue.StartsWith("-"))
            {
                stringValue = stringValue.Remove(0, 1);

                isPositive = false;
            }

            numbers = GetNumbersListFromString(stringValue);

            intValue = GetIntFromLong(
                GetLongFromList(numbers),
                isPositive);

            return intValue;
        }

        private static long GetLongFromList(List<int> numbers)
        {
            long longValue = 0;

            int multiplier = 1;

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

            return longValue;
        }

        private static int GetIntFromLong(long longValue, bool isPositive)
        {
            if (!isPositive)
            {
                longValue = longValue * -1;
            }

            if (longValue > int.MaxValue || longValue < int.MinValue)
            {
                throw new OverflowException();
            }

            return (int)longValue;
        }

        private static void CheckStringValidity(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException();
            }

            if (stringValue.Trim() == "")
            {
                throw new FormatException();
            }
        }

        private static List<int> GetNumbersListFromString(string stringValue)
        {
            List<int> numbers = new List<int>();

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

            return numbers;
        }
    }
}
