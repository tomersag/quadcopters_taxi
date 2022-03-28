using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quadcopters_taxi
{
    class QuadcopterNode
    {
        public QuadcopterNode m_Next;
        public QuadcopterNode m_Prev;
        public quadcopter m_Current;

        public QuadcopterNode(quadcopter i_Current)
        {
            m_Current = i_Current;
            m_Next = null;
            m_Prev = null;
        }
    }
}
