using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimesCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Thread calculateThread;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("please enter numbers in the textboxs");
                return;
            }
            int number1, number2;
            if (!int.TryParse(textBox1.Text, out number1) || !int.TryParse(textBox2.Text, out number2))
            {
                MessageBox.Show("please enter numbers in the textboxs");
                return;
            }

            calculateThread = new Thread(() => { calcAllPrimes(number1, number2); });
            calculateThread.Start();

        }
        private void  calcAllPrimes(int start,int finish)
        {
            List<int> result = new List<int>();
            if(finish<2 || finish<start)
                return;
            
            if(start<3)
            {
                result.Add(2);
                start = 3;
            }
            if (start % 2 == 0)
                start++;
            for (int i = start; i < finish; i += 2)
            {
                if (i.isPrime())
                    result.Add(i);
            }
            for (int i = 0; i < result.Count; i++)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    listBox1.Items.Add(result[i]);
                });
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            calculateThread.Abort();
        }
    }
}
