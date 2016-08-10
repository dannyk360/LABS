using System;

namespace BackgamonUI
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
            this.buttons = new System.Windows.Forms.Button[28];
            for (int i = 0; i < 28; i++)
                buttons[i] = new System.Windows.Forms.Button();
            this.labels = new System.Windows.Forms.Label[4];
            for (int i = 0; i < 4; i++)
                labels[i] = new System.Windows.Forms.Label();

            this.SuspendLayout();

            this.labels[0].AutoSize = true;
            this.labels[0].Location = new System.Drawing.Point(200, 290);
            this.labels[0].Name = "label0";
            this.labels[0].Size = new System.Drawing.Size(25, 20);
            this.labels[0].TabIndex = 0;
            this.labels[0].Text = "the player is:";
            
            this.labels[1].AutoSize = true;
            this.labels[1].Location = new System.Drawing.Point(285, 290);
            this.labels[1].Name = "label1";
            this.labels[1].Size = new System.Drawing.Size(50, 20);
            this.labels[1].TabIndex = 1;
            this.labels[1].Text = "";

            this.labels[2].AutoSize = true;
            this.labels[2].Location = new System.Drawing.Point(600, 290);
            this.labels[2].Name = "label2";
            this.labels[2].Size = new System.Drawing.Size(25, 20);
            this.labels[2].TabIndex = 2;
            this.labels[2].Text = "the cubes that we have gotten is:";

            this.labels[3].AutoSize = true;
            this.labels[3].Location = new System.Drawing.Point(817, 290);
            this.labels[3].Name = "label3";
            this.labels[3].Size = new System.Drawing.Size(5, 20);
            this.labels[3].TabIndex = 3;
            this.labels[3].Text = "";
            
            for (int i = 0; i < 12; i++)
            {
                buttons[i].Location = new System.Drawing.Point(15 + 70 * i +70*(i/6), 15);
                buttons[i].Name = "button" + i.ToString();
                buttons[i].Size = new System.Drawing.Size(62,62);
                buttons[i].TabIndex = i;
                buttons[i].Text = "";
                buttons[i].UseVisualStyleBackColor = true;
                buttons[i].Click += new System.EventHandler(this.button_Click);
            }
            for (int i = 12; i < 24; i++)
            {
                buttons[i].Location = new System.Drawing.Point(15 + 70 * (23 - i) + 70 * (17 / i), 498);
                buttons[i].Name = "button" + i.ToString();
                buttons[i].Size = new System.Drawing.Size(62, 62);
                buttons[i].TabIndex = i;
                buttons[i].Text = "";
                buttons[i].UseVisualStyleBackColor = true;
                buttons[i].Click += new System.EventHandler(this.button_Click);
            }

            buttons[24].Location = new System.Drawing.Point(15 + 70 * 6, 175);
            buttons[24].Name = "button" + 24.ToString();
            buttons[24].Size = new System.Drawing.Size(62, 62);
            buttons[24].TabIndex = 24;
            buttons[24].Text = "black jail = 0";
            buttons[24].UseVisualStyleBackColor = true;
            buttons[24].Click += new System.EventHandler(this.button_Click);

            buttons[25].Location = new System.Drawing.Point(15+70*6, 350);
            buttons[25].Name = "button" + 25.ToString();
            buttons[25].Size = new System.Drawing.Size(62, 62);
            buttons[25].TabIndex = 25;
            buttons[25].Text = "white jail = 0";
            buttons[25].UseVisualStyleBackColor = true;
            buttons[25].Click += new System.EventHandler(this.button_Click);

            buttons[26].Cursor = System.Windows.Forms.Cursors.Default;
            buttons[26].Location = new System.Drawing.Point(15, 175);
            buttons[26].Name = "button" + 26.ToString();
            buttons[26].Size = new System.Drawing.Size(62, 237);
            buttons[26].TabIndex = 26;
            buttons[26].Text = "go out";
            buttons[26].UseVisualStyleBackColor = true;
            buttons[26].Click += new System.EventHandler(this.button_Click);

            buttons[27].Cursor = System.Windows.Forms.Cursors.Default;
            buttons[27].Location = new System.Drawing.Point(600, 230);
            buttons[27].Name = "button" + 27.ToString();
            buttons[27].Size = new System.Drawing.Size(100, 50);
            buttons[27].TabIndex = 27;
            buttons[27].Text = "roll Cubes";
            buttons[27].UseVisualStyleBackColor = true;
            buttons[27].Click += new System.EventHandler(this.clickToRoll);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(894, 569);
            for (int i = 0; i < 28; i++)
            {
                this.Controls.Add(buttons[i]);
            }
            for (int i = 0; i < 4; i++)
            {
                this.Controls.Add(labels[i]);
            }
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(950, 615);
            this.MinimumSize = new System.Drawing.Size(950, 615);
            this.Name = "Form1";
            this.Text = "Form1";
            //this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button[] buttons;
        private System.Windows.Forms.Label[] labels;
    }
}

