using System.Windows.Forms;

namespace UIPriceCompare
{
    partial class Form1
    {
        private const int numberOfCategories = 7;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.categories = new System.Windows.Forms.Button[numberOfCategories];
            for(int i=0;i<numberOfCategories;i++)
            {
                categories[i] = new System.Windows.Forms.Button();
            }
            this.categoryItems = new System.Windows.Forms.ListBox();
            this.addGroceryCount = new System.Windows.Forms.TextBox();
            this.addGrocery = new System.Windows.Forms.Button();
            this.shoppingCart = new System.Windows.Forms.ListBox();
            this.shoppingCartCount = new System.Windows.Forms.ListBox();
            this.subGroceryCount = new System.Windows.Forms.TextBox();
            this.subGrocery = new System.Windows.Forms.Button();
            this.calculate = new System.Windows.Forms.Button();
            this.emptyShoppingCart = new System.Windows.Forms.Button();
            this.changeDefaultChains = new System.Windows.Forms.Button();
            this.SuspendLayout();

            const int x = 1240;
            const int addY = 120;
            int y = 20;

            const int sizeX = 240;
            const int sizeY = 90;


            for (int i = 0; i < numberOfCategories; i++)
            {
                this.categories[i].Location = new System.Drawing.Point(x, y + i*addY);
                this.categories[i].Name = "category-" + (i + 1).ToString();
                this.categories[i].Size = new System.Drawing.Size(sizeX, sizeY);
                this.categories[i].TabIndex = i;
                this.categories[i].UseVisualStyleBackColor = true;
                this.categories[i].Click += new System.EventHandler(this.ShowOptionGroceries);
            }


            this.categories[0].Text = "פירות וירקות";
            this.categories[1].Text = "מוצרי חלב";
            this.categories[2].Text = "בשר ונקניקים";
            this.categories[3].Text = "סלטים";
            this.categories[4].Text = "שימורים";
            this.categories[5].Text = "ממתקים";
            this.categories[6].Text = "שתייה";


            this.categoryItems.FormattingEnabled = true;
            this.categoryItems.Location = new System.Drawing.Point(765, 30);
            this.categoryItems.Name = "categoryItems";
            this.categoryItems.Size = new System.Drawing.Size(375, 650);
            this.categoryItems.TabIndex = 8;

            this.addGroceryCount.Location = new System.Drawing.Point(765, 700);
            this.addGroceryCount.Name = "groceryCount";
            this.addGroceryCount.Size = new System.Drawing.Size(375, 200);
            this.addGroceryCount.TabIndex = 9;

            this.addGrocery.Location = new System.Drawing.Point(765, 750);
            this.addGrocery.Name = "addGrocery";
            this.addGrocery.Size = new System.Drawing.Size(385, 50);
            this.addGrocery.TabIndex = 10;
            this.addGrocery.Text = "להוסיף";
            this.addGrocery.UseVisualStyleBackColor = true;
            this.addGrocery.Click += new System.EventHandler(this.AddToCartGroceries);
            
            this.shoppingCart.FormattingEnabled = true;
            this.shoppingCart.Location = new System.Drawing.Point(365, 30);
            this.shoppingCart.Name = "shoppingCart";
            this.shoppingCart.Size = new System.Drawing.Size(300, 650);
            this.shoppingCart.TabIndex = 11;

            this.shoppingCartCount.FormattingEnabled = true;
            this.shoppingCartCount.Location = new System.Drawing.Point(665, 30);
            this.shoppingCartCount.Name = "shoppingCartCount";
            this.shoppingCartCount.Size = new System.Drawing.Size(77, 650);
            this.shoppingCartCount.TabIndex = 13;

            this.subGroceryCount.Location = new System.Drawing.Point(365, 700);
            this.subGroceryCount.Name = "groceryCount";
            this.subGroceryCount.Size = new System.Drawing.Size(375, 200);
            this.subGroceryCount.TabIndex = 9;

            this.subGrocery.Location = new System.Drawing.Point(365, 750);
            this.subGrocery.Name = "addGrocery";
            this.subGrocery.Size = new System.Drawing.Size(385, 50);
            this.subGrocery.TabIndex = 10;
            this.subGrocery.Text = "להפחית";
            this.subGrocery.UseVisualStyleBackColor = true;
            this.subGrocery.Click += new System.EventHandler(this.SubstructFromCartGroceries);

            this.calculate.Location = new System.Drawing.Point(40, 265);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(195, 330);
            this.calculate.TabIndex = 12;
            this.calculate.Text = "לחישוב";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.ShowResult);

            this.emptyShoppingCart.Location = new System.Drawing.Point(40, 600);
            this.emptyShoppingCart.Name = "empty shop";
            this.emptyShoppingCart.Size = new System.Drawing.Size(195, 50);
            this.emptyShoppingCart.TabIndex = 14;
            this.emptyShoppingCart.Text = "לרוקן סל";
            this.emptyShoppingCart.UseVisualStyleBackColor = true;
            this.emptyShoppingCart.Click += new System.EventHandler(this.emptyCart);

            this.changeDefaultChains.Location = new System.Drawing.Point(40, 650);
            this.changeDefaultChains.Name = "empty shop";
            this.changeDefaultChains.Size = new System.Drawing.Size(195, 100);
            this.changeDefaultChains.TabIndex = 15;
            this.changeDefaultChains.Text = "לשנות רשתות";
            this.changeDefaultChains.UseVisualStyleBackColor = true;
            this.changeDefaultChains.Click += new System.EventHandler(this.changeChains);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 880);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.emptyShoppingCart);
            this.Controls.Add(this.changeDefaultChains);
            this.Controls.Add(this.categoryItems);
            this.Controls.Add(this.addGroceryCount);
            this.Controls.Add(this.addGrocery);
            this.Controls.Add(this.subGroceryCount);
            this.Controls.Add(this.subGrocery);
            this.Controls.Add(this.shoppingCart);
            this.Controls.Add(this.shoppingCartCount);
            for (int i = 0; i < numberOfCategories; i++)
            {
                this.Controls.Add(this.categories[i]);
            }
            this.Name = "Form1";
            this.Text = "קניות בכיף";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button[] categories;
        private System.Windows.Forms.ListBox categoryItems;
        private System.Windows.Forms.TextBox addGroceryCount;
        private System.Windows.Forms.Button addGrocery;
        private System.Windows.Forms.ListBox shoppingCart;
        private System.Windows.Forms.ListBox shoppingCartCount;
        private System.Windows.Forms.TextBox subGroceryCount;
        private System.Windows.Forms.Button subGrocery;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.Button emptyShoppingCart;
        private System.Windows.Forms.Button changeDefaultChains;
    }
}

