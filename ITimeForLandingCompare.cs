using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quadcopters_taxi
{
    class ITimeForLandingCompare: IComparable
    {
        public bool IsBigger(quadcopter first, quadcopter second)
        {
            bool flag = false;
            if (first.GetTimeRemainForLanding > second.GetTimeRemainForLanding) flag = true;
            return flag;
        }
    }
}
