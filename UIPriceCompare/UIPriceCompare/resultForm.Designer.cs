using System.Windows.Forms;

namespace UIPriceCompare
{
    partial class ResultForm
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
        /// <param name="arr"></param>
        /// <param name="chainsName"></param>
        private void InitializeComponent(string[] chainsName)
        {
            this.chains = new System.Windows.Forms.Button[chainsName.Length];
            
            const int buttonX = 50;
            const int buttonYStart = 50;
            const int buttonXAdd = 110;
            const int sizeX = 100, sizeY = 60;
            for (int i = 0; i < chainsName.Length; i++)
            {
                this.chains[i] = new System.Windows.Forms.Button();
                this.chains[i].Location = new System.Drawing.Point(buttonX + buttonXAdd * i, buttonYStart );
                this.chains[i].Name = chainsName[i];
                this.chains[i].Text = chainsName[i];
                this.chains[i].Size = new System.Drawing.Size(sizeX, sizeY);
                this.chains[i].TabIndex = i;
                this.chains[i].UseVisualStyleBackColor = true;
                this.chains[i].Click += new System.EventHandler(this.GetChainInfo);
                this.Controls.Add(this.chains[i]);
            }


            this.sumLabel = new Label();
            this.sumLabel.AutoSize = true;
            this.sumLabel.Location = new System.Drawing.Point(buttonX + buttonXAdd * chainsName.Length, buttonYStart + 70);
            this.sumLabel.Name = "sum";
            this.sumLabel.Size = new System.Drawing.Size(30, 20);
            this.sumLabel.TabIndex = 0;
            this.sumLabel.Text = ":סכום";
            this.Controls.Add(this.sumLabel);

            sumResultLabel = new Label[chains.Length];
            for (int i = 0; i < chains.Length; i++)
            {
                this.sumResultLabel[i] = new Label();
                this.sumResultLabel[i].AutoSize = true;
                this.sumResultLabel[i].Location = new System.Drawing.Point(buttonX + buttonXAdd * i + 35, buttonYStart + 70);
                this.sumResultLabel[i].Name = "sum";
                this.sumResultLabel[i].Size = new System.Drawing.Size(50, 20);
                this.sumResultLabel[i].TabIndex = 0;
                this.Controls.Add(this.sumResultLabel[i]);
            }
            this.SuspendLayout();

            this.cheapestLabel = new Label();
            this.cheapestLabel.AutoSize = true;
            this.cheapestLabel.Location = new System.Drawing.Point((110 * this.chains.Length + 90) *3 /5, 200);
            this.cheapestLabel.Name = "cheap";
            this.cheapestLabel.Size = new System.Drawing.Size(30, 20);
            this.cheapestLabel.TabIndex = 0;
            this.cheapestLabel.Text = ":המוצרים הזולים ביותר";
            //this.cheapestLabel.Visible = false;
            this.Controls.Add(this.cheapestLabel);

            const int LabelItems = 3;
            this.cheapestResultLabels = new System.Windows.Forms.Label[LabelItems];

            int labelX = (110 * this.chains.Length + 90) /2;
            int labelYStart = 220;
            const int labelYAdd = 20;
            for (int i = 0; i < LabelItems; i++)
            {
                this.cheapestResultLabels[i] = new Label();
                this.cheapestResultLabels[i].AutoSize = true;
                this.cheapestResultLabels[i].Location = new System.Drawing.Point(labelX, labelYStart + i * labelYAdd);
                this.cheapestResultLabels[i].Name = "cheap" +i;
                this.cheapestResultLabels[i].Size = new System.Drawing.Size(30, 20);
                this.cheapestResultLabels[i].TabIndex = 0;
                this.Controls.Add(this.cheapestResultLabels[i]);
            }


            this.expenciveLabel = new Label();
            this.expenciveLabel.AutoSize = true;
            this.expenciveLabel.Location = new System.Drawing.Point((110 * this.chains.Length + 90) / 5, 200);
            this.expenciveLabel.Name = "expencive";
            this.expenciveLabel.Size = new System.Drawing.Size(30, 20);
            this.expenciveLabel.TabIndex = 0;
            this.expenciveLabel.Text = ":המוצרים היקרים ביותר";
            //this.expenciveLabel.Visible = false;
            this.Controls.Add(this.expenciveLabel);

            this.expenciveResultLabels = new System.Windows.Forms.Label[LabelItems];

            labelX = 10;

            for (int i = 0; i < LabelItems; i++)
            {
                this.expenciveResultLabels[i] = new Label();
                this.expenciveResultLabels[i].AutoSize = true;
                this.expenciveResultLabels[i].Location = new System.Drawing.Point(labelX, labelYStart + i * labelYAdd);
                this.expenciveResultLabels[i].Name = "expencive" + i;
                this.expenciveResultLabels[i].Size = new System.Drawing.Size(30, 20);
                this.expenciveResultLabels[i].TabIndex = 0;
                this.Controls.Add(this.expenciveResultLabels[i]);
            }
            // 
            // resultForm
            // 
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(110 * this.chains.Length +90, 500);

            this.Name = "ResultForm";
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button[] chains;
        private System.Windows.Forms.Label sumLabel;
        private System.Windows.Forms.Label[] sumResultLabel;
        private System.Windows.Forms.Label cheapestLabel;
        private System.Windows.Forms.Label[] cheapestResultLabels;
        private System.Windows.Forms.Label expenciveLabel;
        private System.Windows.Forms.Label[] expenciveResultLabels;
        #endregion
    }
}