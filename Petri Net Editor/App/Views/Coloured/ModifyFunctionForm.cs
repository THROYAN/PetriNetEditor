using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MagicLibrary.MathUtils.MathFunctions;
using MagicLibrary.Exceptions;

namespace Petri_Net_Editor.App.Views
{
    public partial class ModifyFunctionForm : Form
    {
        public string FunctionDescription { get; set; }

        public ModifyFunctionForm(string funcDescription = null)
        {
            InitializeComponent();
            this.FunctionDescription = funcDescription;
        }

        private void funcTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var mf = MathFunction.MultiLineFunction(this.funcTextBox.Text);
                this.errorLabel.Text = "";
            }
            catch (InvalidFunctionStringException)
            {
                this.errorLabel.Text = "Ошибка в описании функции";
            }
        }

        private void ModifyFunctionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.FunctionDescription != null && this.FunctionDescription.Equals(this.funcTextBox.Text))
            {
                return;
            }

            DialogResult d = MessageBox.Show("Сохранить изменения?", "Внимание!", MessageBoxButtons.YesNoCancel);
            if (d == System.Windows.Forms.DialogResult.Cancel)
                e.Cancel = true;
            this.FunctionDescription = this.funcTextBox.Text;
            this.Succesful = d == System.Windows.Forms.DialogResult.Yes;
        }

        public bool Succesful { get; set; }

        private void ModifyFunctionForm_Load(object sender, EventArgs e)
        {
            if (this.FunctionDescription != null)
            {
                this.funcTextBox.Text = this.FunctionDescription;
            }
        }
    }
}
