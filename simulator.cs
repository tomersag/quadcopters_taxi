using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace quadcopters_taxi
{
    public delegate void MyDelegate(int time);
    class simulator
    {
        private PriorityQueue m_PriorityWaitingForAPersonQueue;
        private PriorityQueue m_PriorityWaitingForArrivalQueue;
        private BoardControl m_BoardControl;
        private int m_NumOfMinutes = 0;
        private TimeConverter m_TimeConverter;
        MyDelegate m_Delegate = null;
        public simulator()
        {
            m_TimeConverter = new TimeConverter();
            m_BoardControl = new BoardControl();
            m_PriorityWaitingForAPersonQueue = new PriorityQueue(new ITimeForAPersonToComeCompare());
            m_PriorityWaitingForArrivalQueue = new PriorityQueue(new ITimeForLandingCompare());
            for(int i = 1; i < 21; i++)
            {
                quadcopter ToAdd = new quadcopter(i);
                m_Delegate += ToAdd.update;
                m_PriorityWaitingForAPersonQueue.add(ToAdd);
            }
        }
        public void run()
        {
            bool HeightsAvailable = true;
            bool ThereAreQuadcopersThatLanded = true;
            while (m_NumOfMinutes < 241)
            {
                while (ThereAreQuadcopersThatLanded)
                {
                    quadcopter FirstToLand = m_PriorityWaitingForArrivalQueue.GetFirst();
                    /*there are no quadcopters that waiting for landing at the moment*/
                    if (FirstToLand == null)
                    {
                        ThereAreQuadcopersThatLanded = false;
                    }
                    /*there are quadcopters that waiting for landing*/
                    else
                    {
                        if (FirstToLand.GetTimeRemainForLanding == 0)
                        {
                            m_PriorityWaitingForArrivalQueue.RemoveFirst();
                            Console.WriteLine(m_TimeConverter.ToHour(m_NumOfMinutes).ToString() + ": Quadcopter number " +
                               FirstToLand.GetNumQuadcopter + "\nhas just landed");
                            m_BoardControl.AddAvailableHeight(FirstToLand.CurrentHeight);
                            FirstToLand.CurrentHeight = 0;
                            FirstToLand.CalculateTimeForAPersonToCome();
                            m_PriorityWaitingForAPersonQueue.add(FirstToLand);
                        }
                        else
                        {
                            ThereAreQuadcopersThatLanded = false;
                        }
                    }
                }
                ThereAreQuadcopersThatLanded = true;

                while (HeightsAvailable)
                {
                    quadcopter FirstQuad = m_PriorityWaitingForAPersonQueue.GetFirst();
                    if (FirstQuad.GetTimeRemainForAPersonToCome == 0)
                    {
                        int height = m_BoardControl.GetFirstAvailableHeight();

                        /*there is no height available*/
                        if (height == -1)
                        {
                            Console.WriteLine(m_TimeConverter.ToHour(m_NumOfMinutes).ToString() + ": Quadcopter number " +
                               FirstQuad.GetNumQuadcopter + "\nasked for a permition to take off and got refused");
                            HeightsAvailable = false;
                        }
                        /*there is a height available, a new flight is about to take off*/
                        else
                        {
                            m_PriorityWaitingForAPersonQueue.RemoveFirst();
                            FirstQuad.CurrentHeight = height;
                            FirstQuad.CalculateRoad();
                            Console.WriteLine(m_TimeConverter.ToHour(m_NumOfMinutes).ToString() + ": Quadcopter number " +
                               FirstQuad.GetNumQuadcopter + "\nasked for a permition to take off and got accepted, height:" + height);
                            m_PriorityWaitingForArrivalQueue.add(FirstQuad);
                        }
                    }
                    else
                    {
                        HeightsAvailable = false;
                    }
                }
                HeightsAvailable = true;
                Thread.Sleep(1000);
                m_NumOfMinutes++;
                m_Delegate.Invoke(m_NumOfMinutes); 
            }
        }
    }
}
