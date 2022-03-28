using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quadcopters_taxi
{
    class ITimeForAPersonToComeCompare: IComparable
    {
        public bool IsBigger(quadcopter first, quadcopter second)
        {
            bool flag = false;
            if (first.GetTimeRemainForAPersonToCome > second.GetTimeRemainForAPersonToCome) flag = true;
            return flag;
        }
    }
}
