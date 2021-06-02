using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab17
{
    public partial class Form1 : Form
    {
        Class1 first;
        Class1 second;
        Class2 both;
        Class1 summ;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            first = new Class1();
            second = new Class1();
            both = new Class2();
            summ = new Class1();
            first.lambda = (int)numericUpDown1.Value;
            second.lambda = (int)numericUpDown2.Value;
            both.lambda[0] = first.lambda;
            both.lambda[1] = second.lambda;
            summ.lambda = first.lambda + second.lambda;
            int N = (int)numericUpDown3.Value;
            double T = (double)numericUpDown4.Value;
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            for (int i = 0; i < N; i++)
            {
                first.SimulateFreq(T);
                second.SimulateFreq(T);
                both.SimulateFreq(T);
                summ.SimulateFreq(T);
            }
            label4.Text = "L1:\n";
            label6.Text = "L2:\n";
            label7.Text = "L1 + L2:\n";
            label8.Text = "L1 and L2:\n";
            for (int i = 0; i < first.Freq.Length; i++)
            {
                if (first.Freq[i] != 0)
                    label4.Text += i + ": " + ((double)first.Freq[i] / N) + "\n";
            }
            for (int i = 0; i < second.Freq.Length; i++)
            {
                if (second.Freq[i] != 0)
                    label6.Text += i + ": " + ((double)second.Freq[i] / N) + "\n";
            }
            for (int i = 0; i < summ.Freq.Length; i++)
            {
                if (summ.Freq[i] != 0)
                    label7.Text += i + ": " + ((double)summ.Freq[i] / N) + "\n";
                chart2.Series[0].Points.AddXY(i, (double)summ.Freq[i] / N);
            }
            for (int i = 0; i < both.Freq.Length; i++)
            {
                if (both.Freq[i] != 0)
                    label8.Text += i + ": " + ((double)both.Freq[i] / N) + "\n";
                chart1.Series[0].Points.AddXY(i, (double)both.Freq[i] / N);
            }
        }
    }

}