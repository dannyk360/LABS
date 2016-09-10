using System;
using System.Drawing;
using System.Windows.Forms;

namespace UIPriceCompare
{
    partial class Form1
    {
        
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

            var categoriesNamesTask = this.ChangeNamesOfCategories();
            categoriesNamesTask.Wait();
            var categoriesNames = categoriesNamesTask.Result;
            int numberOfCategories = categoriesNames.Length;
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
            this.subGrocery = new System.Windows.Forms.Button();
            this.deleteGrocery = new System.Windows.Forms.Button();
            this.calculate = new System.Windows.Forms.Button();
            this.emptyShoppingCart = new System.Windows.Forms.Button();
            this.changeDefaultChains = new System.Windows.Forms.Button();
            this.SuspendLayout();

            const int x = 1210;
            const int addY = 115;
            int y = 30;

            const int sizeX = 240;
            const int sizeY = 85;


            for (int i = 0; i < numberOfCategories; i++)
            {
                this.categories[i].Location = new System.Drawing.Point(x, y + i*addY);
                this.categories[i].Name = "category-" + (i + 1).ToString();
                this.categories[i].Size = new System.Drawing.Size(sizeX, sizeY);
                this.categories[i].TabIndex = i;
                this.categories[i].UseVisualStyleBackColor = true;
                this.categories[i].Text = categoriesNames[i];
                this.categories[i].Click += new System.EventHandler(this.ShowOptionGroceries);
            }
            this.categorizedLabel = new Label();
            this.categorizedLabel.AutoSize = true;
            this.categorizedLabel.Location = new System.Drawing.Point(940, 25);
            this.categorizedLabel.Name = "sum";
            this.categorizedLabel.Size = new System.Drawing.Size(30, 20);
            this.categorizedLabel.TabIndex = 0;
            this.categorizedLabel.Text = "בחר מוצר";
            this.Controls.Add(this.categorizedLabel);


            this.categoryItems.FormattingEnabled = true;
            this.categoryItems.Location = new System.Drawing.Point(835, 60);
            this.categoryItems.Name = "categoryItems";
            this.categoryItems.Size = new System.Drawing.Size(320, 600);
            this.categoryItems.TabIndex = 8;
            this.categoryItems.RightToLeft = RightToLeft.Yes;
            this.categoryItems.SelectedIndexChanged += new EventHandler(ChangeLabelToShowTheProduct);

            this.giveGroceryNumber = new Label();
            this.giveGroceryNumber.AutoSize = true;
            this.giveGroceryNumber.Location = new System.Drawing.Point(670, 25);
            this.giveGroceryNumber.Name = "sum";
            this.giveGroceryNumber.Size = new System.Drawing.Size(100, 20);
            this.giveGroceryNumber.TabIndex = 0;
            this.giveGroceryNumber.Text = "בחר כמות";
            this.Controls.Add(this.giveGroceryNumber);

            this.ItemLabel = new Label();
            this.ItemLabel.AutoSize = true;
            this.ItemLabel.Location = new System.Drawing.Point(640, 230);
            this.ItemLabel.Name = "sum";
            this.ItemLabel.Size = new System.Drawing.Size(30, 20);
            this.ItemLabel.TabIndex = 0;
            this.ItemLabel.Text = "";
            this.Controls.Add(this.ItemLabel);

            this.addGroceryCount.Location = new System.Drawing.Point(640, 260);
            this.addGroceryCount.Name = "groceryCount";
            this.addGroceryCount.Size = new System.Drawing.Size(180, 200);
            this.addGroceryCount.TabIndex = 9;
            this.addGroceryCount.Visible = false;

            this.addGrocery.Location = new System.Drawing.Point(640, 320);
            this.addGrocery.Name = "addGrocery";
            this.addGrocery.Size = new System.Drawing.Size(185, 100);
            this.addGrocery.TabIndex = 10;
            this.addGrocery.Text = "להוסיף";
            this.addGrocery.UseVisualStyleBackColor = true;
            this.addGrocery.Visible = false;
            this.addGrocery.Click += new System.EventHandler(this.AddToCartGroceries);
            
            this.shoppingCartItemsLabel = new Label();
            this.shoppingCartItemsLabel.AutoSize = true;
            this.shoppingCartItemsLabel.Location = new System.Drawing.Point(422, 25);
            this.shoppingCartItemsLabel.Name = "sum";
            this.shoppingCartItemsLabel.Size = new System.Drawing.Size(30, 20);
            this.shoppingCartItemsLabel.TabIndex = 0;
            this.shoppingCartItemsLabel.Text = "סל הקניות";
            this.Controls.Add(this.shoppingCartItemsLabel);
            
            this.shoppingCart.FormattingEnabled = true;
            this.shoppingCart.Location = new System.Drawing.Point(300, 60);
            this.shoppingCart.Name = "shoppingCart";
            this.shoppingCart.Size = new System.Drawing.Size(264, 600);
            this.shoppingCart.TabIndex = 11;
            this.shoppingCart.RightToLeft = RightToLeft.Yes;
            this.shoppingCart.SelectedIndexChanged += new EventHandler(this.MakeVisibleOptions);

            this.shoppingCartCount.FormattingEnabled = true;
            this.shoppingCartCount.Location = new System.Drawing.Point(565, 60);
            this.shoppingCartCount.Name = "shoppingCartCount";
            this.shoppingCartCount.Size = new System.Drawing.Size(60, 600);
            this.shoppingCartCount.TabIndex = 13;
           
            this.subGrocery.Location = new System.Drawing.Point(30, 60);
            this.subGrocery.Name = "addGrocery";
            this.subGrocery.Size = new System.Drawing.Size(260, 192);
            this.subGrocery.TabIndex = 10;
            this.subGrocery.Text = "לשנות כמות";
            this.subGrocery.UseVisualStyleBackColor = true;
            this.subGrocery.Visible = false;
            this.subGrocery.Click += new System.EventHandler(this.ChangeQuantity);

            this.deleteGrocery.Location = new System.Drawing.Point(30, 256);
            this.deleteGrocery.Name = "deleteGrocery";
            this.deleteGrocery.Size = new System.Drawing.Size(260, 192);
            this.deleteGrocery.TabIndex = 10;
            this.deleteGrocery.Text = "מחק מוצר";
            this.deleteGrocery.UseVisualStyleBackColor = true;
            this.deleteGrocery.Visible = false;
            this.deleteGrocery.Click += new System.EventHandler(this.DeleteItem);

            this.emptyShoppingCart.Location = new System.Drawing.Point(30, 453);
            this.emptyShoppingCart.Name = "empty shop";
            this.emptyShoppingCart.Size = new System.Drawing.Size(260, 190);
            this.emptyShoppingCart.TabIndex = 14;
            this.emptyShoppingCart.Text = "לרוקן סל";
            this.emptyShoppingCart.UseVisualStyleBackColor = true;
            this.emptyShoppingCart.Visible = false;
            this.emptyShoppingCart.Click += new System.EventHandler(this.EmptyCart);
 
            this.calculate.Location = new System.Drawing.Point(762, 680);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(400, 125);
            this.calculate.TabIndex = 12;
            this.calculate.Text = "לחישוב";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.ShowResult);



            this.changeDefaultChains.Location = new System.Drawing.Point(300, 680);
            this.changeDefaultChains.Name = "empty shop";
            this.changeDefaultChains.Size = new System.Drawing.Size(400, 125);
            this.changeDefaultChains.TabIndex = 15;
            this.changeDefaultChains.Text = "לשנות רשתות";
            this.changeDefaultChains.UseVisualStyleBackColor = true;
            this.changeDefaultChains.Click += new System.EventHandler(this.ChangeChains);
            // 
            // Form1
            // 

            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2240, numberOfCategories * 130);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.emptyShoppingCart);
            this.Controls.Add(this.changeDefaultChains);
            this.Controls.Add(this.categoryItems);
            this.Controls.Add(this.addGroceryCount);
            this.Controls.Add(this.addGrocery);
            this.Controls.Add(this.subGrocery);
            this.Controls.Add(this.deleteGrocery);
            this.Controls.Add(this.shoppingCart);
            this.Controls.Add(this.shoppingCartCount);
            for (int i = 0; i < numberOfCategories; i++)
            {
                this.Controls.Add(this.categories[i]);
            }
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "קניות בכיף";
            this.ResumeLayout(false);

            this.Size = new Size(920, numberOfCategories * 58);
        }

        #endregion

        private System.Windows.Forms.Label ItemLabel;
        private System.Windows.Forms.Label giveGroceryNumber;
        private System.Windows.Forms.Label categorizedLabel;
        private System.Windows.Forms.Label shoppingCartItemsLabel;
        private System.Windows.Forms.Button[] categories;
        private System.Windows.Forms.ListBox categoryItems;
        private System.Windows.Forms.TextBox addGroceryCount;
        private System.Windows.Forms.Button addGrocery;
        private System.Windows.Forms.ListBox shoppingCart;
        private System.Windows.Forms.ListBox shoppingCartCount;
        private System.Windows.Forms.Button subGrocery;
        private System.Windows.Forms.Button deleteGrocery;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.Button emptyShoppingCart;
        private System.Windows.Forms.Button changeDefaultChains;
    }
}

