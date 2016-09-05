using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIPriceCompare
{
    public partial class resultForm : Form
    {
        public resultForm(string[] arr)
        {
            InitializeComponent(arr);
        }

        private async void getChainInfo(object sender, EventArgs e)
        {
            var information = await BULogic.ProgramLogic.getChainInfo(((Button) sender).Text);
            if (sumLabel.Visible == false)
            {
                sumLabel.Visible = true;
                cheapestLabel.Visible = true;
                expenciveLabel.Visible = true;
            }

            for (int i = 1; i < information.cheapestList.Count+1; i++)
            {
                cheapestResultLabels[i-1].Text = information.cheapestList[i-1];
            }
            for (int i = 1; i < information.expensiveList.Count+1; i++)
            {
                expenciveResultLabels[i-1].Text = information.expensiveList[i-1];
            }
            sumResultLabel.Text = information.sum.ToString();
        }


    }
}
