using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17
{
    class Class1
    {
        Random rnd = new Random();
        public int lambda { get; set; }
        public int[] Freq { get; set; }

        public Class1()
        {
            Freq = new int[30];
        }
        public void SimulateFreq(double T)
        {
            int NumPoints = 0;
            for (double ct = -SimulateTime(); ct <= T; ct -= SimulateTime()) NumPoints++;
            if (Freq.Length - 1 < NumPoints)
            {
                int[] NewFreq = new int[NumPoints * 10];
                for (int i = 0; i < Freq.Length; i++)
                    NewFreq[i] = Freq[i];
                Freq = NewFreq;
            }
            Freq[NumPoints]++;
        }
        private double SimulateTime()
        {
            double a;
            do
            {
                a = rnd.NextDouble();
            } while (a == 0);
            return Math.Log(a) / lambda;
        }
    }
}
