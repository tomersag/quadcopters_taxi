using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quadcopters_taxi
{
    class TimeConverter
    {
        public TimeConverter(){}
        public StringBuilder ToHour(int hour)
        {
            StringBuilder ToHours = new StringBuilder();
            ToHours.Append("0" + hour / 60 + ":");
            if (hour % 60 >= 10)
            {
                ToHours.Append(hour % 60);
            }
            else
            {
                ToHours.Append("0" + hour % 60);
            }
            return ToHours;
        }
    }
}
