using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quadcopters_taxi
{
    class PriorityQueue
    {
        private QuadcopterList m_Queue;
        private IComparable m_StrategyCompare; /*strategy instance for the comparing algorithm*/

        /*constructor for the priority queue class*/
        public PriorityQueue(IComparable i_StrategyCompare)
        {
            m_Queue = new QuadcopterList(null);
            m_StrategyCompare = i_StrategyCompare;
        }

        /*returns the first quadcopter in the queue*/
        public quadcopter GetFirst()
        {
            if (m_Queue.GetHead != null)
            {
                return m_Queue.GetHead.m_Current;
            }
            return null;
        }

        /*adds a quadcopter to the right place in the queue, or to the landing queue, or to 
         * the wating for a person queue*/
        public void add(quadcopter i_ToAdd)
        {
            /*if the queue is empty*/
            if(m_Queue.GetHead.m_Current == null)
            {
                m_Queue.AddBefore(i_ToAdd,null);
            }
            /*inserting in the right place*/
            else
            {
                QuadcopterNode current = m_Queue.GetHead;
                QuadcopterNode next = m_Queue.GetHead.m_Next;
                while(true)
                {
                    /*checks if the queue is empty*/
                    if (current.m_Current != null)
                    {
                        /*checks if the time of the new quad is smaller in one of the strategys, 
                         or for a person to come, or time for landing*/
                        if (m_StrategyCompare.IsBigger(current.m_Current,i_ToAdd))
                        {
                            m_Queue.AddBefore(i_ToAdd,current);
                            break;
                        }
                        /*if the time for the new quadcopter is larger*/
                        else
                        {
                            /*if the queue ended, add the new quadcopter to the end*/
                            if (next == null)
                            {
                                m_Queue.AddAfter(i_ToAdd,current);
                                break;
                            }
                            /*else, check the next quadcopter in the queue*/
                            else
                            {
                                current = next;
                                next = next.m_Next;
                            }
                        }
                    }
                    /*the queue is empty*/
                    else
                    {
                        m_Queue.AddBefore(i_ToAdd,null);
                    }
                }
            }
        }

        /*removing the first quadcopter in the queue*/
        public quadcopter RemoveFirst()
        {
            quadcopter first = m_Queue.RemoveFirst();
            return first;
        } 
    }
}
