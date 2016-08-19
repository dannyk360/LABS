using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int firstNumber, secondNumber;
            int.TryParse(textBox1.Text, out firstNumber);
            int.TryParse(textBox2.Text, out secondNumber);
            currentDelegate PrimesCalculator = new currentDelegate(new calculatePrimes().CalcPrimes);
            
            PrimesCalculator.BeginInvoke(firstNumber, secondNumber, callbackMethod, PrimesCalculator);        
        }
        // method name should begin with big letter
        private void callbackMethod(IAsyncResult Iasync)
        {
            // delete first 2 lines and define "PrimesCalculator" as parameter class
            AsyncResult res = (AsyncResult)Iasync;
            CallbackClass callback = new CallbackClass();
            currentDelegate caller = (currentDelegate)res.AsyncDelegate;
            var PrimeNumbers = caller.EndInvoke(Iasync);
            foreach (var num in PrimeNumbers)
            {
                // invoke - synchronic , beginInvoke - asynchronic
                // The UI is blocked
                Invoke((MethodInvoker)delegate
                {
                    listBox1.Items.Add(num);
                });
            }
        }
    }
    
}
