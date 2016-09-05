using System.Windows.Forms;

namespace UIPriceCompare
{
    partial class resultForm
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
        private void InitializeComponent(string[] chainsName)
        {
            this.chains = new System.Windows.Forms.Button[chainsName.Length];
            
            const int buttonX = 300;
            const int buttonYStart = 50;
            const int buttonYAdd = 70;
            const int sizeX = 100, sizeY = 60;
            for (int i = 0; i < chainsName.Length; i++)
            {
                this.chains[i] = new System.Windows.Forms.Button();
                this.chains[i].Location = new System.Drawing.Point(buttonX, buttonYStart + i * buttonYAdd);
                this.chains[i].Name = chainsName[i];
                this.chains[i].Text = chainsName[i];
                this.chains[i].Size = new System.Drawing.Size(sizeX, sizeY);
                this.chains[i].TabIndex = i;
                this.chains[i].UseVisualStyleBackColor = true;
                this.chains[i].Click += new System.EventHandler(this.getChainInfo);
                this.Controls.Add(this.chains[i]);
            }


            this.sumLabel = new Label();
            this.sumLabel.AutoSize = true;
            this.sumLabel.Location = new System.Drawing.Point(200, 55);
            this.sumLabel.Name = "sum";
            this.sumLabel.Size = new System.Drawing.Size(30, 20);
            this.sumLabel.TabIndex = 0;
            this.sumLabel.Text = ":סכום";
            this.sumLabel.Visible = false;
            this.Controls.Add(this.sumLabel);

            this.sumResultLabel = new Label();
            this.sumResultLabel.AutoSize = true;
            this.sumResultLabel.Location = new System.Drawing.Point(100, 55);
            this.sumResultLabel.Name = "sum";
            this.sumResultLabel.Size = new System.Drawing.Size(50, 20);
            this.sumResultLabel.TabIndex = 0;
            this.sumResultLabel.Text = "";
            this.Controls.Add(this.sumResultLabel);
            this.SuspendLayout();

                        this.cheapestLabel = new Label();
            this.cheapestLabel.AutoSize = true;
            this.cheapestLabel.Location = new System.Drawing.Point(157, 80);
            this.cheapestLabel.Name = "cheap";
            this.cheapestLabel.Size = new System.Drawing.Size(30, 20);
            this.cheapestLabel.TabIndex = 0;
            this.cheapestLabel.Text = ":הזולים ביותר";
            this.cheapestLabel.Visible = false;
            this.Controls.Add(this.cheapestLabel);

            const int LabelItems = 3;
            this.cheapestResultLabels = new System.Windows.Forms.Label[LabelItems];

            int labelX = 10;
            int labelYStart = 80;
            const int labelYAdd = 20;
            for (int i = 0; i < LabelItems; i++)
            {
                this.cheapestResultLabels[i] = new Label();
                this.cheapestResultLabels[i].AutoSize = true;
                this.cheapestResultLabels[i].Location = new System.Drawing.Point(labelX, labelYStart + i*labelYAdd);
                this.cheapestResultLabels[i].Name = "cheap" +i;
                this.cheapestResultLabels[i].Size = new System.Drawing.Size(30, 20);
                this.cheapestResultLabels[i].TabIndex = 0;
                this.Controls.Add(this.cheapestResultLabels[i]);
            }


            this.expenciveLabel = new Label();
            this.expenciveLabel.AutoSize = true;
            this.expenciveLabel.Location = new System.Drawing.Point(157, 150);
            this.expenciveLabel.Name = "expencive";
            this.expenciveLabel.Size = new System.Drawing.Size(30, 20);
            this.expenciveLabel.TabIndex = 0;
            this.expenciveLabel.Text = ":היקרים ביותר";
            this.expenciveLabel.Visible = false;
            this.Controls.Add(this.expenciveLabel);

            this.expenciveResultLabels = new System.Windows.Forms.Label[LabelItems];

            labelYStart = 150;

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
            this.ClientSize = new System.Drawing.Size(410, 60 + 70 * chainsName.Length);

            this.Name = "resultForm";
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button[] chains;
        private System.Windows.Forms.Label sumLabel;
        private System.Windows.Forms.Label sumResultLabel;
        private System.Windows.Forms.Label cheapestLabel;
        private System.Windows.Forms.Label[] cheapestResultLabels;
        private System.Windows.Forms.Label expenciveLabel;
        private System.Windows.Forms.Label[] expenciveResultLabels;
        #endregion
    }
}