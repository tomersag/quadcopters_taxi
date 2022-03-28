using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quadcopters_taxi
{
    interface IComparable
    {
        bool IsBigger(quadcopter first, quadcopter second);
    }
}
