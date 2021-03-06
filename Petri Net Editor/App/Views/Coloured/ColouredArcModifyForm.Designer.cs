﻿namespace Petri_Net_Editor.App.Views
{
    partial class ColouredArcModifyForm
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
            this.tailComboBox = new System.Windows.Forms.ComboBox();
            this.headComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.funcTextBox = new System.Windows.Forms.TextBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tailComboBox
            // 
            this.tailComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tailComboBox.FormattingEnabled = true;
            this.tailComboBox.Location = new System.Drawing.Point(12, 36);
            this.tailComboBox.Name = "tailComboBox";
            this.tailComboBox.Size = new System.Drawing.Size(68, 21);
            this.tailComboBox.TabIndex = 0;
            // 
            // headComboBox
            // 
            this.headComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.headComboBox.FormattingEnabled = true;
            this.headComboBox.Location = new System.Drawing.Point(147, 36);
            this.headComboBox.Name = "headComboBox";
            this.headComboBox.Size = new System.Drawing.Size(68, 21);
            this.headComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "--------------->";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Хвост";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Голова";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Функция:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(152, 230);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // funcTextBox
            // 
            this.funcTextBox.Location = new System.Drawing.Point(12, 76);
            this.funcTextBox.Multiline = true;
            this.funcTextBox.Name = "funcTextBox";
            this.funcTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.funcTextBox.Size = new System.Drawing.Size(203, 135);
            this.funcTextBox.TabIndex = 6;
            this.funcTextBox.TextChanged += new System.EventHandler(this.funcTextBox_TextChanged);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(16, 214);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 7;
            // 
            // ColouredArcModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 256);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.funcTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.headComboBox);
            this.Controls.Add(this.tailComboBox);
            this.Name = "ColouredArcModifyForm";
            this.Text = "ArcModifyForm";
            this.Load += new System.EventHandler(this.ArcModifyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox tailComboBox;
        private System.Windows.Forms.ComboBox headComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox funcTextBox;
        private System.Windows.Forms.Label errorLabel;
    }
}