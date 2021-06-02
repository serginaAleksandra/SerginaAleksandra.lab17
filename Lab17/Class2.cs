using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17
{
    class Class2
    {
        Random rnd = new Random();
        public int[] lambda { get; set; } = new int[2];
        public int[] Freq { get; set; }

        public Class2()
        {
            Freq = new int[30];
        }
        public void SimulateFreq(double T)
        {
            int NumPoints = 0;
            for (double ct = -SimulateTime(0); ct <= T; ct -= SimulateTime(0)) NumPoints++;
            for (double ct = -SimulateTime(1); ct <= T; ct -= SimulateTime(1)) NumPoints++;
            if (Freq.Length - 1 < NumPoints)
            {
                int[] NewFreq = new int[NumPoints * 10];
                for (int i = 0; i < Freq.Length; i++)
                    NewFreq[i] = Freq[i];
                Freq = NewFreq;
            }
            Freq[NumPoints]++;
        }
        private double SimulateTime(int i)
        {
            double a;
            do
            {
                a = rnd.NextDouble();
            } while (a == 0);
            return Math.Log(a) / lambda[i];
        }
    }
}
