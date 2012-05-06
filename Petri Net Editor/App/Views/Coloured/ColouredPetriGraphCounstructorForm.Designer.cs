namespace Petri_Net_Editor.App.Views
{
    partial class ColouredPetriGraphConstructorForm
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
            this.firstPartVerticesCounter = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.firstPartVerticesComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.incidentsGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.secondPartVerticesCount = new System.Windows.Forms.NumericUpDown();
            this.secondPartVerticesComboBox = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.colorsDescriptionError = new System.Windows.Forms.Label();
            this.colorsEditButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.firstPartVerticesCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.incidentsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondPartVerticesCount)).BeginInit();
            this.SuspendLayout();
            // 
            // firstPartVerticesCounter
            // 
            this.firstPartVerticesCounter.Location = new System.Drawing.Point(150, 12);
            this.firstPartVerticesCounter.Name = "firstPartVerticesCounter";
            this.firstPartVerticesCounter.Size = new System.Drawing.Size(40, 20);
            this.firstPartVerticesCounter.TabIndex = 0;
            this.firstPartVerticesCounter.ValueChanged += new System.EventHandler(this.fitstPartVerticesCounter_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Количество позиций:";
            // 
            // firstPartVerticesComboBox
            // 
            this.firstPartVerticesComboBox.FormattingEnabled = true;
            this.firstPartVerticesComboBox.Location = new System.Drawing.Point(196, 12);
            this.firstPartVerticesComboBox.Name = "firstPartVerticesComboBox";
            this.firstPartVerticesComboBox.Size = new System.Drawing.Size(206, 21);
            this.firstPartVerticesComboBox.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(408, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Редактировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // incidentsGrid
            // 
            this.incidentsGrid.AllowUserToAddRows = false;
            this.incidentsGrid.AllowUserToDeleteRows = false;
            this.incidentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.incidentsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.incidentsGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.incidentsGrid.Location = new System.Drawing.Point(0, 63);
            this.incidentsGrid.Name = "incidentsGrid";
            this.incidentsGrid.Size = new System.Drawing.Size(631, 359);
            this.incidentsGrid.TabIndex = 4;
            this.incidentsGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.incidentsGrid_CellEndEdit);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Количество переходов:";
            // 
            // secondPartVerticesCount
            // 
            this.secondPartVerticesCount.Location = new System.Drawing.Point(150, 37);
            this.secondPartVerticesCount.Name = "secondPartVerticesCount";
            this.secondPartVerticesCount.Size = new System.Drawing.Size(40, 20);
            this.secondPartVerticesCount.TabIndex = 5;
            this.secondPartVerticesCount.ValueChanged += new System.EventHandler(this.secondPardVerticesCount_ValueChanged);
            // 
            // secondPartVerticesComboBox
            // 
            this.secondPartVerticesComboBox.FormattingEnabled = true;
            this.secondPartVerticesComboBox.Location = new System.Drawing.Point(196, 36);
            this.secondPartVerticesComboBox.Name = "secondPartVerticesComboBox";
            this.secondPartVerticesComboBox.Size = new System.Drawing.Size(206, 21);
            this.secondPartVerticesComboBox.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(408, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Редактировать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // colorsDescriptionError
            // 
            this.colorsDescriptionError.AutoSize = true;
            this.colorsDescriptionError.ForeColor = System.Drawing.Color.Red;
            this.colorsDescriptionError.Location = new System.Drawing.Point(12, 122);
            this.colorsDescriptionError.Name = "colorsDescriptionError";
            this.colorsDescriptionError.Size = new System.Drawing.Size(0, 13);
            this.colorsDescriptionError.TabIndex = 8;
            // 
            // colorsEditButton
            // 
            this.colorsEditButton.Location = new System.Drawing.Point(522, 9);
            this.colorsEditButton.Name = "colorsEditButton";
            this.colorsEditButton.Size = new System.Drawing.Size(93, 48);
            this.colorsEditButton.TabIndex = 9;
            this.colorsEditButton.Text = "Редактировать\r\nописание сети";
            this.colorsEditButton.UseVisualStyleBackColor = true;
            this.colorsEditButton.Click += new System.EventHandler(this.colorsEditButton_Click);
            // 
            // ColouredPetriGraphConstructorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 422);
            this.Controls.Add(this.colorsEditButton);
            this.Controls.Add(this.colorsDescriptionError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.secondPartVerticesCount);
            this.Controls.Add(this.incidentsGrid);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.secondPartVerticesComboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.firstPartVerticesComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.firstPartVerticesCounter);
            this.Name = "ColouredPetriGraphConstructorForm";
            this.Text = "CPN Constructor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraphConstructorForm_FormClosing);
            this.Load += new System.EventHandler(this.GraphConstructorForm_Load);
            this.Resize += new System.EventHandler(this.GraphConstructorForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.firstPartVerticesCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.incidentsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondPartVerticesCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown firstPartVerticesCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox firstPartVerticesComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView incidentsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown secondPartVerticesCount;
        private System.Windows.Forms.ComboBox secondPartVerticesComboBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label colorsDescriptionError;
        private System.Windows.Forms.Button colorsEditButton;
    }
}