using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
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
    public partial class ChangeChains : Form
    {
        public ChangeChains()
        {
            InitializeComponent();
            GetChainsAsync();
        }

        private async void GetChainsAsync()
        {
            var chainsDictonary = await ProgramLogic.GetAllChains();
            foreach (var chainName in chainsDictonary.Keys)
            {
                checkedListBox1.Items.Add(chainName);
                checkedListBox1.SetItemChecked(checkedListBox1.Items.Count - 1, chainsDictonary[chainName]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var chainsDictonary = new Dictionary<string, bool>();

            for (var i = 0; i < checkedListBox1.Items.Count; i++)
                chainsDictonary.Add(checkedListBox1.Items[i].ToString(), checkedListBox1.GetItemChecked(i));
            if (chainsDictonary.Count(value => value.Value) < 3)
            {
                label1.ForeColor = Color.Red;
                return;
            }
            new Thread(() => ProgramLogic.ChangeChainsBool(chainsDictonary)).Start();
            if (ActiveForm != null) ActiveForm.Close();
        }
    }
}