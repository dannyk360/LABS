using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BULogic;

namespace UIPriceCompare
{
    public partial class Form1 : Form
    {
        private readonly BackgroundWorker _bw;

        public Form1()
        {
            _bw = new BackgroundWorker {WorkerSupportsCancellation = true};
            _bw.DoWork += AddGroceries;
            InitializeComponent();
        }

        public Task<string[]> ChangeNamesOfCategories()
        {
            return Task.Run(() => ProgramLogic.GetCategoriesOfItems());
        }

        private void ShowOptionGroceries(object sender, EventArgs e)
        {
            categoryItems.Items.Clear();
            ItemLabel.Text = "";
            if (_bw.IsBusy)
                _bw.CancelAsync();
            else
                _bw.RunWorkerAsync(((Button) sender).Text);
        }

        private void AddGroceries(object sender, DoWorkEventArgs e)
        {
            var results = ProgramLogic.GetGroceries(e.Argument.ToString());
            SetResult(results);
        }

        private void SetResult(List<string> products)
        {
            if (categoryItems.InvokeRequired)
            {
                var d = new SetResultCallback(SetResult);
                Invoke(d, products);
            }
            else
            {
                if (products != null)
                {
                    products.ForEach(item => categoryItems.Items.Add(item));
                    ItemLabel.Text = "";
                    addGrocery.Visible = false;
                    addGroceryCount.Visible = false;
                }
            }
        }

        private void AddToCartGroceries(object sender, EventArgs e)
        {
            if (ItemLabel.Text == "")
                return;
            double countOfNumbers;
            if (!ValidateNumber(addGroceryCount, out countOfNumbers))
                return;

            var itemName = ItemLabel.Text;
            var index = shoppingCart.Items.IndexOf(itemName);

            if (index != -1)
            {
                MessageBox.Show("כבר בחרת את המוצר הזה");
                return;
            }
            if (shoppingCart.Items.Count == 0)
                emptyShoppingCart.Visible = true;
            shoppingCart.Items.Add(categoryItems.SelectedItem);
            shoppingCartCount.Items.Add(addGroceryCount.Text);
            new Thread(() => ProgramLogic.AddGrociery(itemName, countOfNumbers)).Start();
        }

        private bool ValidateNumber(TextBox numberTextBox, out double countOfNumbers)
        {
            if ((numberTextBox.Text == "") || !double.TryParse(numberTextBox.Text, out countOfNumbers) ||
                (countOfNumbers <= 0))
            {
                MessageBox.Show("נא לבחור מספר גדול מ0");
                countOfNumbers = 0;
                return false;
            }
            if (!ItemLabel.Text.Contains("(משקל)") && (Math.Abs(countOfNumbers - (int) countOfNumbers) > 0))
            {
                MessageBox.Show("נא לבחור מספר שלם");
                countOfNumbers = 0;
                return false;
            }
            return true;
        }

        private async void ShowResult(object sender, EventArgs e)
        {
            var rf = new ResultForm(await ProgramLogic.GetChainsName());
            rf.ShowDialog();
        }

        private void EmptyCart(object sender, EventArgs e)
        {
            shoppingCartCount.Items.Clear();
            shoppingCart.Items.Clear();
            emptyShoppingCart.Visible = false;
            new Thread(ProgramLogic.ClearGrocieries).Start();
        }

        private void ChangeChains(object sender, EventArgs e)
        {
            var rf = new ChangeChains();
            rf.ShowDialog();
        }


        private void ChangeLabelToShowTheProduct(object sender, EventArgs e)
        {
            if (categoryItems.SelectedItems.Count != 0)
            {
                ItemLabel.Text = categoryItems.Items[categoryItems.SelectedIndex].ToString();
                addGrocery.Visible = true;
                addGroceryCount.Visible = true;
            }
        }

        private async void ChangeQuantity(object sender, EventArgs e)
        {
            if (shoppingCart.SelectedIndex == -1)
            {
                MessageBox.Show("לא בחרת מוצר");
                return;
            }
            var itemToChange = shoppingCart.SelectedItem.ToString();
            var cq = new ChangeQuantity(itemToChange);
            cq.ShowDialog();
            shoppingCartCount.Items[shoppingCart.SelectedIndex] = await ProgramLogic.GetItemCapacity(itemToChange);
        }

        private void DeleteItem(object sender, EventArgs e)
        {
            if (shoppingCart.SelectedIndex == -1)
            {
                MessageBox.Show("לא בחרת מוצר");
                return;
            }

            var itemToDelete = shoppingCart.SelectedItem.ToString();
            shoppingCartCount.Items.RemoveAt(shoppingCart.SelectedIndex);
            shoppingCart.Items.RemoveAt(shoppingCart.SelectedIndex);
            if (shoppingCart.Items.Count == 0)
                emptyShoppingCart.Visible = false;
            new Thread(() => ProgramLogic.ChangeGrocieryCount(itemToDelete, 0)).Start();
        }

        private void MakeVisibleOptions(object sender, EventArgs e)
        {
            if (shoppingCart.SelectedItems.Count == 0)
            {
                deleteGrocery.Visible = false;
                subGrocery.Visible = false;
                return;
            }
            deleteGrocery.Visible = true;
            subGrocery.Visible = true;
        }
    }

    internal delegate void SetResultCallback(List<string> str);
}