using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherTeller
{
    class DayComperator : IComparer<Day>
    {
        public int Compare(Day x, Day y)
        {
            string[] xDay = x.date.Split('.');
            string[] yDay = y.date.Split('.');

            int compare = xDay[2].CompareTo(yDay[2]);

            if (compare != 0)
                return compare;

            compare = xDay[1].CompareTo(yDay[1]);

            if (compare != 0)
                return compare;

            return xDay[0].CompareTo(yDay[0]);
        }
    }
}
