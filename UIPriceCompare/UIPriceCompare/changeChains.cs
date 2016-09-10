using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using BULogic;

namespace UIPriceCompare
{
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