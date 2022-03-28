using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quadcopters_taxi
{
    class quadcopter
    {
        private bool m_OnAir = false;
        private int m_NumQuadcopter;
        private int m_TimeRemainForLanding = 0;
        private double m_TimeRemainForAPersonToCome = 0;
        private int m_CurrentHeight;
        private TimeConverter m_TimeConverter;
        private Random m_Rand;

        public quadcopter(int i_NumQuadcopter)
        {
            m_Rand = new Random(i_NumQuadcopter);
            m_TimeConverter = new TimeConverter();
            m_TimeRemainForAPersonToCome = (15) * m_Rand.NextDouble();
            m_NumQuadcopter = i_NumQuadcopter;
            m_CurrentHeight = 0;
        }
        public int CurrentHeight
        {
            get{ return m_CurrentHeight;}
            set{ m_CurrentHeight = value;}
        }
        public int GetNumQuadcopter
        {
            get
            {
                return m_NumQuadcopter;
            }
        }
        public double GetTimeRemainForAPersonToCome
        {
            get
            {
                return m_TimeRemainForAPersonToCome;
            }
        }
        public double GetTimeRemainForLanding
        {
            get
            {
                return m_TimeRemainForLanding;
            }
        }
        public void CalculateRoad()
        {
            m_TimeRemainForLanding = (int)(1 + 4 * m_Rand.NextDouble() + ((2 * m_CurrentHeight) / 1000));
            m_OnAir = true;
        }
        public void CalculateTimeForAPersonToCome()
        {
            m_TimeRemainForAPersonToCome = (15) * m_Rand.NextDouble();
        }
        public void update(int time)
        {
            if (m_TimeRemainForAPersonToCome > 0)
            {
                m_TimeRemainForAPersonToCome--;
                if (m_TimeRemainForAPersonToCome <= 0)
                {
                    m_TimeRemainForAPersonToCome = 0;
                    Console.WriteLine(m_TimeConverter.ToHour(time).ToString() + ": a person arrived to quadcopter \nnumber " +
                        m_NumQuadcopter);
                }
            }
            if (m_TimeRemainForLanding > 0)
            {
                m_TimeRemainForLanding--;
                if(m_TimeRemainForLanding == 0)
                {
                    m_OnAir = false; 
                }
            }
        }
    }
}
