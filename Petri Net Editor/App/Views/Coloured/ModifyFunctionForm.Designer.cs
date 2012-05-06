namespace Petri_Net_Editor.App.Views
{
    partial class ModifyFunctionForm
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
            this.funcTextBox = new System.Windows.Forms.TextBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // funcTextBox
            // 
            this.funcTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.funcTextBox.Location = new System.Drawing.Point(0, 0);
            this.funcTextBox.Multiline = true;
            this.funcTextBox.Name = "funcTextBox";
            this.funcTextBox.Size = new System.Drawing.Size(284, 236);
            this.funcTextBox.TabIndex = 0;
            this.funcTextBox.TextChanged += new System.EventHandler(this.funcTextBox_TextChanged);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(12, 239);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 1;
            // 
            // ModifyFunctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 256);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.funcTextBox);
            this.Name = "ModifyFunctionForm";
            this.Text = "ModifyFunctionForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModifyFunctionForm_FormClosing);
            this.Load += new System.EventHandler(this.ModifyFunctionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox funcTextBox;
        private System.Windows.Forms.Label errorLabel;
    }
}