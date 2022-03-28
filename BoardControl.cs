using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quadcopters_taxi
{
    class BoardControl
    {
        private List<int> m_AvailableHeightsList;
        
        public BoardControl()
        {
            m_AvailableHeightsList = new List<int>();
            for(int i = 0; i < 15; i++)
            {
                m_AvailableHeightsList.Add((i + 1) * 10);
            }
        }

        /*returns the first height that available, if the is no one available, returns -1*/
        public int GetFirstAvailableHeight()
        {
            int first = -1;
            if (m_AvailableHeightsList.Count > 0)
            {
                first = m_AvailableHeightsList.ElementAt(0);
                m_AvailableHeightsList.RemoveAt(0);
            }
            return first;
        }

        /*adds available height to the list*/
        public void AddAvailableHeight(int i_ToAdd)
        {
            m_AvailableHeightsList.Add(i_ToAdd);
        }
    }
}
