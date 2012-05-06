namespace Petri_Net_Editor.App.Views
{
    partial class ColorsEditForm
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
            this.colorsListBox = new System.Windows.Forms.ListBox();
            this.addColorButton = new System.Windows.Forms.Button();
            this.removeColorButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.varsListBox = new System.Windows.Forms.ListBox();
            this.removeVarButton = new System.Windows.Forms.Button();
            this.addVarButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.removeFuncButton = new System.Windows.Forms.Button();
            this.addFuncButton = new System.Windows.Forms.Button();
            this.funcsListBox = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorsListBox
            // 
            this.colorsListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorsListBox.FormattingEnabled = true;
            this.colorsListBox.Location = new System.Drawing.Point(3, 16);
            this.colorsListBox.Name = "colorsListBox";
            this.colorsListBox.Size = new System.Drawing.Size(162, 225);
            this.colorsListBox.TabIndex = 0;
            this.colorsListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.colorsListBox_DrawItem);
            this.colorsListBox.SelectedIndexChanged += new System.EventHandler(this.colorsListBox_SelectedIndexChanged);
            this.colorsListBox.DoubleClick += new System.EventHandler(this.colorsListBox_DoubleClick);
            // 
            // addColorButton
            // 
            this.addColorButton.Location = new System.Drawing.Point(6, 247);
            this.addColorButton.Name = "addColorButton";
            this.addColorButton.Size = new System.Drawing.Size(72, 23);
            this.addColorButton.TabIndex = 1;
            this.addColorButton.Text = "Добавить";
            this.addColorButton.UseVisualStyleBackColor = true;
            this.addColorButton.Click += new System.EventHandler(this.addColorButton_Click);
            // 
            // removeColorButton
            // 
            this.removeColorButton.Enabled = false;
            this.removeColorButton.Location = new System.Drawing.Point(84, 247);
            this.removeColorButton.Name = "removeColorButton";
            this.removeColorButton.Size = new System.Drawing.Size(76, 23);
            this.removeColorButton.TabIndex = 1;
            this.removeColorButton.Text = "Удалить";
            this.removeColorButton.UseVisualStyleBackColor = true;
            this.removeColorButton.Click += new System.EventHandler(this.removeColorButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.colorsListBox);
            this.groupBox1.Controls.Add(this.removeColorButton);
            this.groupBox1.Controls.Add(this.addColorButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 275);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Цвета";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.removeVarButton);
            this.groupBox2.Controls.Add(this.addVarButton);
            this.groupBox2.Controls.Add(this.varsListBox);
            this.groupBox2.Location = new System.Drawing.Point(184, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 275);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Переменные";
            // 
            // varsListBox
            // 
            this.varsListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.varsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.varsListBox.FormattingEnabled = true;
            this.varsListBox.Location = new System.Drawing.Point(3, 16);
            this.varsListBox.Name = "varsListBox";
            this.varsListBox.Size = new System.Drawing.Size(162, 225);
            this.varsListBox.TabIndex = 1;
            this.varsListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.colorsListBox_DrawItem);
            this.varsListBox.SelectedIndexChanged += new System.EventHandler(this.varsListBox_SelectedIndexChanged);
            this.varsListBox.DoubleClick += new System.EventHandler(this.varsListBox_DoubleClick);
            // 
            // removeVarButton
            // 
            this.removeVarButton.Enabled = false;
            this.removeVarButton.Location = new System.Drawing.Point(84, 247);
            this.removeVarButton.Name = "removeVarButton";
            this.removeVarButton.Size = new System.Drawing.Size(76, 23);
            this.removeVarButton.TabIndex = 3;
            this.removeVarButton.Text = "Удалить";
            this.removeVarButton.UseVisualStyleBackColor = true;
            this.removeVarButton.Click += new System.EventHandler(this.removeVarButton_Click);
            // 
            // addVarButton
            // 
            this.addVarButton.Enabled = false;
            this.addVarButton.Location = new System.Drawing.Point(6, 247);
            this.addVarButton.Name = "addVarButton";
            this.addVarButton.Size = new System.Drawing.Size(72, 23);
            this.addVarButton.TabIndex = 2;
            this.addVarButton.Text = "Добавить";
            this.addVarButton.UseVisualStyleBackColor = true;
            this.addVarButton.Click += new System.EventHandler(this.addVarButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.removeFuncButton);
            this.groupBox3.Controls.Add(this.addFuncButton);
            this.groupBox3.Controls.Add(this.funcsListBox);
            this.groupBox3.Location = new System.Drawing.Point(358, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(168, 275);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Функции";
            // 
            // removeFuncButton
            // 
            this.removeFuncButton.Enabled = false;
            this.removeFuncButton.Location = new System.Drawing.Point(84, 247);
            this.removeFuncButton.Name = "removeFuncButton";
            this.removeFuncButton.Size = new System.Drawing.Size(76, 23);
            this.removeFuncButton.TabIndex = 3;
            this.removeFuncButton.Text = "Удалить";
            this.removeFuncButton.UseVisualStyleBackColor = true;
            this.removeFuncButton.Click += new System.EventHandler(this.removeFuncButton_Click);
            // 
            // addFuncButton
            // 
            this.addFuncButton.Location = new System.Drawing.Point(6, 247);
            this.addFuncButton.Name = "addFuncButton";
            this.addFuncButton.Size = new System.Drawing.Size(72, 23);
            this.addFuncButton.TabIndex = 2;
            this.addFuncButton.Text = "Добавить";
            this.addFuncButton.UseVisualStyleBackColor = true;
            this.addFuncButton.Click += new System.EventHandler(this.addFuncButton_Click);
            // 
            // funcsListBox
            // 
            this.funcsListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.funcsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.funcsListBox.FormattingEnabled = true;
            this.funcsListBox.Location = new System.Drawing.Point(3, 16);
            this.funcsListBox.Name = "funcsListBox";
            this.funcsListBox.Size = new System.Drawing.Size(162, 225);
            this.funcsListBox.TabIndex = 1;
            this.funcsListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.colorsListBox_DrawItem);
            this.funcsListBox.SelectedIndexChanged += new System.EventHandler(this.funcsListBox_SelectedIndexChanged);
            this.funcsListBox.DoubleClick += new System.EventHandler(this.funcsListBox_DoubleClick);
            // 
            // ColorsEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(537, 299);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ColorsEditForm";
            this.Text = "ColorsEditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColorsEditForm_FormClosing);
            this.Load += new System.EventHandler(this.ColorsEditForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox colorsListBox;
        private System.Windows.Forms.Button addColorButton;
        private System.Windows.Forms.Button removeColorButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button removeVarButton;
        private System.Windows.Forms.Button addVarButton;
        private System.Windows.Forms.ListBox varsListBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button removeFuncButton;
        private System.Windows.Forms.Button addFuncButton;
        private System.Windows.Forms.ListBox funcsListBox;
    }
}