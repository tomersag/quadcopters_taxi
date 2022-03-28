using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace quadcopters_taxi
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            simulator MySimulator = new simulator();
            MySimulator.run();
        }
    }
}
