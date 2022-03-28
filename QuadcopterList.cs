using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quadcopters_taxi
{
    class QuadcopterList
    {
        private quadcopter m_Quadcopter;
        private QuadcopterNode m_Head;
        private int m_Count;

        public QuadcopterList()
        {
            m_Head = null;
            m_Count = 0;
        }
        public QuadcopterList(quadcopter i_Quadcopter)
        {
            m_Quadcopter = i_Quadcopter;
            m_Head = new QuadcopterNode(i_Quadcopter);
            m_Count = 0;
        }
        
        public QuadcopterNode GetHead
        {
            get
            {
                if (m_Head == null)
                {
                    return null;
                }
                else
                {
                    return m_Head;
                }
            }
        }
        public int GetCount
        {
            get
            {
                return m_Count;
            }
        }
        public void AddBefore(quadcopter i_QuadcopterToAdd,
            QuadcopterNode i_TheQuadcopterToAddBefore)
        {
            QuadcopterNode ToAdd = new QuadcopterNode(i_QuadcopterToAdd);   
            /*if the is no node in the list*/
            if (m_Head.m_Current == null)
            {
                m_Head = ToAdd;
            }
            else 
            {
                /*changing the head*/
                if (m_Head == i_TheQuadcopterToAddBefore)
                {
                    m_Head.m_Prev = ToAdd;
                    ToAdd.m_Next = m_Head;
                    m_Head = ToAdd;
                }
                /*adding in the middle*/
                else
                {
                    ToAdd.m_Next = i_TheQuadcopterToAddBefore;
                    ToAdd.m_Prev = i_TheQuadcopterToAddBefore.m_Prev;
                    i_TheQuadcopterToAddBefore.m_Prev.m_Next = ToAdd;
                    i_TheQuadcopterToAddBefore.m_Prev = ToAdd;
                }
            }
            m_Count++;
        }
        public void AddAfter(quadcopter i_Quadcopter,
            QuadcopterNode i_TheQuadcopterToAddAfter)
        {
            QuadcopterNode ToAdd = new QuadcopterNode(i_Quadcopter);
            ToAdd.m_Prev = i_TheQuadcopterToAddAfter;
            if(i_TheQuadcopterToAddAfter.m_Next != null)
            {
                i_TheQuadcopterToAddAfter.m_Next.m_Prev = ToAdd;
                ToAdd.m_Next = i_TheQuadcopterToAddAfter.m_Next;
            }
            i_TheQuadcopterToAddAfter.m_Next = ToAdd;
            m_Count++;
        }
        public quadcopter RemoveFirst()
        {
            quadcopter Current = null;

            /*if there is a quadcopter in the list*/
            if (m_Head != null)
            {
                Current = m_Head.m_Current;

                /*if there is only one quadcopter in the list*/
                if (m_Head.m_Next == null)
                {
                    m_Head.m_Current = null;
                }

                /*there is more than one, so we are changing the head*/
                else
                {
                    m_Head = m_Head.m_Next;
                    m_Head.m_Prev = null;
                }
                m_Count--;
            }
            return Current;
        }
        
    }
}
