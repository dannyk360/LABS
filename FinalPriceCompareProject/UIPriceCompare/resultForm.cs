using System;
using System.Windows.Forms;
using BULogic;

namespace UIPriceCompare
{
    /**
    * When creating a UI application- consider one of the following paradigms: MVC, MVP or MVVM
    * It is best to refrain from coding in the codebehind of the UI class.
    * This enables better testability and separation of UI from User interaction and Business Logic.
    * 
    * Consider :
    * a) https://he.wikipedia.org/wiki/Model_View_Controller
    * b) https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93presenter
    * c) https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel
    */
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