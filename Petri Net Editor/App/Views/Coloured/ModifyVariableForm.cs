using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MagicLibrary.MathUtils.PetriNetsUtils;

namespace Petri_Net_Editor.App.Views
{
    public partial class ModifyVariableForm : Form
    {
        public ColorSetCollection Colors { get; set; }
        public string VarName { get; set; }
        public bool Succesful { get; set; }
        public string ColorSetName { get; set; }

        public ModifyVariableForm(ColorSetCollection colors, Tuple<string, string> varDesc = null)
        {
            InitializeComponent();
            this.Colors = colors;
            this.VarName = "";
            this.ColorSetName = Colors.ElementAt(0).Name;
            if (varDesc != null)
            {
                this.VarName = varDesc.Item1;
                this.ColorSetName = varDesc.Item2;
            }
        }

        private void ModifyVariableForm_Load(object sender, EventArgs e)
        {
            foreach (var color in this.Colors)
            {
                this.colorComboBox.Items.Add(color.Name);
            }
                
            this.nameTextBox.Text = this.VarName;
            this.colorComboBox.SelectedItem = this.ColorSetName;
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!this.VarName.Equals(this.nameTextBox.Text) && this.Colors.HasVariable(this.nameTextBox.Text))
            {
                this.errorLabel.Text = "Переменная с таким имененем уже существует";
            }
            else
            {
                this.errorLabel.Text = "";
            }
        }

        private void ModifyVariableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.ColorSetName.Equals(this.colorComboBox.SelectedItem.ToString()) && this.VarName.Equals(this.nameTextBox.Text))
            {
                return;
            }

            DialogResult d = MessageBox.Show("Сохранить изменения?", "Внимание!", MessageBoxButtons.YesNoCancel);
            if (d == System.Windows.Forms.DialogResult.Cancel)
                e.Cancel = true;
            this.VarName = this.nameTextBox.Text;
            this.ColorSetName = this.colorComboBox.SelectedItem.ToString();
            this.Succesful = d == System.Windows.Forms.DialogResult.Yes;
        }
    }
}
