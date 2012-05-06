using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MagicLibrary.MathUtils.PetriNetsUtils;
using MagicLibrary.Exceptions;

namespace Petri_Net_Editor.App.Views
{
    public partial class ModifyColorSetForm : Form
    {
        private Size size;
        public Tuple<string, string, string> ColorSetDescription { get; set; }
        public ColorSetCollection Colors { get; set; }
        public bool Succesful { get; set; }

        public ModifyColorSetForm(ColorSetCollection colors, Tuple<string, string, string> colorSetDescription = null)
        {
            InitializeComponent();
            this.Colors = colors;
            if (colorSetDescription == null)
            {
                this.ColorSetDescription = null;// new Tuple<string, string, string>("", ColorSet.Types.Keys.ElementAt(0), "");
                this.Name = "Создание цвета";
            }
            else
            {
                this.ColorSetDescription = new Tuple<string, string, string>(colorSetDescription.Item1, colorSetDescription.Item2, colorSetDescription.Item3);
                this.Name = "Редактирование цвета";
            }

            size = this.Size;
        }

        private void ModifyColorSetForm_Resize(object sender, EventArgs e)
        {
            this.Size = size;
        }

        private void ModifyColorSetForm_Load(object sender, EventArgs e)
        {
            foreach (var item in ColorSet.Types)
            {
                this.typeComboBox.Items.Add(item.Key);
            }

            if (this.ColorSetDescription != null)
            {
                this.nameTextBox.Text = this.ColorSetDescription.Item1;
                this.typeComboBox.SelectedItem = this.ColorSetDescription.Item2;
                this.colorSetDescriptionTextBox.Text = this.ColorSetDescription.Item3;
            }
            else
            {
                this.typeComboBox.SelectedIndex = 0;
            }
        }

        private void colorSetDescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            this.checkColor();
        }

        private void checkColor()
        {
            try
            {
                string name = this.nameTextBox.Text;
                if (String.IsNullOrEmpty(name))
                {
                    name = "NewColor";
                }
                new ColorSet(String.Format("{0}={1}({2})", name, this.typeComboBox.SelectedItem, this.colorSetDescriptionTextBox.Text), this.Colors);
                this.errorLabel.Text = "";
            }
            catch (InvalidColorSetAttributesException err)
            {
                this.errorLabel.Text = err.Message;
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.ColorSetDescription != null && !this.nameTextBox.Text.Equals(this.ColorSetDescription.Item1) && this.Colors.ContainsColorSet(this.nameTextBox.Text))
            {
                this.errorLabel.Text = "Цвет с таким именем уже есть";
            }
            else
            {
                this.checkColor();
            }
        }

        private void ModifyColorSetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.ColorSetDescription != null &&
                this.ColorSetDescription.Item1.Equals(this.nameTextBox.Text) &&
                this.ColorSetDescription.Item2.Equals(this.typeComboBox.SelectedItem.ToString()) &&
                this.ColorSetDescription.Item3.Equals(this.colorSetDescriptionTextBox.Text))
            {
                return;
            }

            DialogResult d = MessageBox.Show("Сохранить изменения?", "Внимание!", MessageBoxButtons.YesNoCancel);
            if (d == System.Windows.Forms.DialogResult.Cancel)
                e.Cancel = true;
            this.ColorSetDescription = new Tuple<string, string, string>(this.nameTextBox.Text, this.typeComboBox.SelectedItem.ToString(), this.colorSetDescriptionTextBox.Text);
            this.Succesful = d == System.Windows.Forms.DialogResult.Yes;
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.checkColor();
        }
    }
}
