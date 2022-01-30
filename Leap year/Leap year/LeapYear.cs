using System;

namespace Leap_year
{
    public static class LeapYear
    {
        public static bool IsLeapYear(int year)
        {
            if (year < 1 
                || year > 9999)
            {
                throw new ArgumentOutOfRangeException();
            }

            return (year % 4) == 0 && (year % 100 != 0 || year % 400 == 0);
        }
    }
}
