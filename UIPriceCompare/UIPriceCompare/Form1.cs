using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace UIPriceCompare
{
    public partial class Form1 : Form
    {
        private BackgroundWorker bw;
        public Form1()
        {
            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += AddGroceries;
            InitializeComponent();
        }


        private void ShowOptionGroceries(object sender, EventArgs e)
        {
            categoryItems.Items.Clear();
            if (bw.IsBusy)
            {
                bw.CancelAsync();
                
            }
            else
            {
                bw.RunWorkerAsync(((Button) sender).Text);
            }
        }

        private void AddGroceries(object sender, DoWorkEventArgs e)
        {
            var results = BULogic.ProgramLogic.GetGroceries(e.Argument.ToString());
            SetResult(results);


        }

        private void SetResult(List<string> products)
        {
            if (categoryItems.InvokeRequired)
            {
                var d = new SetResultCallback(SetResult);
                this.Invoke(d, new object[] {products});
            }
            else
            {
                if (products != null) products.ForEach((item) => categoryItems.Items.Add(item));
            }
        }

        private async void AddToCartGroceries(object sender, EventArgs e)
        {
            if (!validateItemPicked(categoryItems))
                return;
            int countOfNumbers;
            if (!validateNumber(addGroceryCount, out countOfNumbers))
                return;

            var itemName = categoryItems.SelectedItem;
            var index = shoppingCart.Items.IndexOf(itemName);

            if (index != -1)
            {
                shoppingCartCount.Items[index] = await BULogic.ProgramLogic.AddGrocieryCount(itemName.ToString(), countOfNumbers);
                return;
            }

            shoppingCart.Items.Add(categoryItems.SelectedItem);
            shoppingCartCount.Items.Add(addGroceryCount.Text);
            new System.Threading.Thread(() => BULogic.ProgramLogic.AddGrociery(itemName.ToString(), countOfNumbers)).Start();

        }

        private bool validateNumber(TextBox numberTextBox, out int countOfNumbers)
        {
            if (numberTextBox.Text == "" || !int.TryParse(numberTextBox.Text, out countOfNumbers) || countOfNumbers <= 0)
            {
                MessageBox.Show("נא לבחור מספר גדול מ0");
                countOfNumbers = 0;
                return false;
            }
            return true;

        }

        private bool validateItemPicked(ListBox listBox)
        {
            if (listBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("לא בחרת מוצר");
                return false;
            }
            return true;
        }

        private async void SubstructFromCartGroceries(object sender, EventArgs e)
        {
            if (!validateItemPicked(shoppingCart))
                return;
            int subCount;
            if (!validateNumber(subGroceryCount, out subCount))
                return;

            var itemName = shoppingCart.SelectedItem;
            var index = shoppingCart.Items.IndexOf(itemName);
            int result;

            result = await BULogic.ProgramLogic.ReplaceGrocieryCount(itemName.ToString(),subCount);

            if(result == -1)
            {
                MessageBox.Show("נא לתת מספר שיותר קטן מהמספר הפריטים שנמצאו");
                return;
            }

            if (result == 0)
            {
                shoppingCart.Items.RemoveAt(index);
                shoppingCartCount.Items.RemoveAt(index);
                return;
            }

            shoppingCartCount.Items[index] = result;
            
        }

        private void ShowResult(object sender, EventArgs e)
        {
            var rf = new resultForm(BULogic.ProgramLogic.getChainsName());
            var result = rf.ShowDialog();
        }

        private void emptyCart(object sender, EventArgs e)
        {
            shoppingCartCount.Items.Clear();
            shoppingCart.Items.Clear();
            BULogic.ProgramLogic.ClearGrocieries();
        }

        private void changeChains(object sender, EventArgs e)
        {
            var rf = new changeChains();
            rf.ShowDialog();
        }
    }

    delegate void SetResultCallback(List<string> str);
}

