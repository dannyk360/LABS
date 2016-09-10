using System;
using System.Windows.Forms;
using BULogic;

namespace UIPriceCompare
{
    public partial class ResultForm : Form
    {
        public ResultForm(string[] arr)
        {
            InitializeComponent(arr);
            ShowChainsSum();
        }

        private async void ShowChainsSum()
        {
            var sumsOfChains = await ProgramLogic.GetSumsOfChains();
            for (var i = 0; i < sumsOfChains.Count; i++)
                sumResultLabel[i].Text = sumsOfChains[i].ToString();
        }

        private async void GetChainInfo(object sender, EventArgs e)
        {
            var information = await ProgramLogic.GetChainInfo(((Button) sender).Text);
            if (sumLabel.Visible == false)
            {
                cheapestLabel.Visible = true;
                expenciveLabel.Visible = true;
            }

            for (var i = 1; i < information.CheapestList.Count + 1; i++)
                cheapestResultLabels[i - 1].Text = information.CheapestList[i - 1];
            for (var i = 1; i < information.ExpensiveList.Count + 1; i++)
                expenciveResultLabels[i - 1].Text = information.ExpensiveList[i - 1];
        }
    }
}