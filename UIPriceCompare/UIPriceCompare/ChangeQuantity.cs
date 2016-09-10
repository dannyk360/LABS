using System;
using System.Drawing;
using System.Windows.Forms;
using BULogic;

namespace UIPriceCompare
{
    public partial class ChangeQuantity : Form
    {
        private readonly string _itemName;

        public ChangeQuantity(string itemName)
        {
            _itemName = itemName;
            InitializeComponent();
            label1.Font = new Font("Arial", 20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double result;

            if (!double.TryParse(textBox1.Text, out result))
            {
                MessageBox.Show("נא להכניס מספר לכמות חדשה");
                return;
            }

            if (result <= 0)
            {
                MessageBox.Show("נא להכניס מספר גדול מ-0");
                return;
            }
            if (!_itemName.Contains("(משקל)") && (Math.Abs(result - (int) result) > 0))
            {
                MessageBox.Show("נא להכניס מספר שלם");
                return;
            }

            ProgramLogic.ChangeGrocieryCount(_itemName, result);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}