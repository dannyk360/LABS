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
    public partial class changeChains : Form
    {
        public changeChains()
        {
            InitializeComponent();
            getChainsAsync();
            
        }

        private async void getChainsAsync()
        {
            Dictionary<string,bool> chainsDictonary = await BULogic.ProgramLogic.getAllChains();
            foreach (var chainName in chainsDictonary.Keys)
            {
                checkedListBox1.Items.Add(chainName);
                checkedListBox1.SetItemChecked(checkedListBox1.Items.Count-1,chainsDictonary[chainName]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string,bool> chainsDictonary  = new Dictionary<string, bool>();
            for (int i=0;i<checkedListBox1.Items.Count;i++)
            {
                chainsDictonary.Add(checkedListBox1.Items[i].ToString(),checkedListBox1.GetItemChecked(i));
            }
            new System.Threading.Thread(() => BULogic.ProgramLogic.ChangeChainsBool(chainsDictonary)).Start();
            changeChains.ActiveForm.Close();
        }
    }
}
