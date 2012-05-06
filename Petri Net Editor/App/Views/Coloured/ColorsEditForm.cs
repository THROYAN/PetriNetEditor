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
using MagicLibrary.MathUtils.Functions;
using MagicLibrary.MathUtils.MathFunctions;

namespace Petri_Net_Editor.App.Views
{
    public partial class ColorsEditForm : Form
    {
        private bool _isModified = false;

        public ColorSetCollection Colors { get; private set; }
        public List<Tuple<string, string, string>> ColorsDescriptions { get; set; }
        public List<Tuple<string, string>> VarsDescriptions { get; set; }
        public List<string> FunctionsDescriptions { get; set; }
        private Dictionary<Control, List<bool>> errors { get; set; }

        public ColorsEditForm(List<Tuple<string, string, string>> colorsDescription, List<Tuple<string,string>> varsDescription, List<string> funcsDescription)
        {
            InitializeComponent();

            this.Colors = new ColorSetCollection();

            this.errors = new Dictionary<Control, List<bool>>();
            this.errors[this.colorsListBox] = new List<bool>();
            this.errors[this.varsListBox] = new List<bool>();
            this.errors[this.funcsListBox] = new List<bool>();

            this.ColorsDescriptions = new List<Tuple<string,string,string>>(colorsDescription);
            this.VarsDescriptions = new List<Tuple<string,string>>(varsDescription);
            this.FunctionsDescriptions = new List<string>(funcsDescription);
        }

        private void addColorButton_Click(object sender, EventArgs e)
        {
            var f = new ModifyColorSetForm(this.Colors);
            f.ShowDialog();
            if (f.Succesful)
            {
                this._isModified = true;
                this.ColorsDescriptions.Add(f.ColorSetDescription);
                this.refreshColors();
            }
        }

        private void refreshColors()
        {
            this.Colors.ClearColors();
            this.colorsListBox.Items.Clear();
            this.errors[this.colorsListBox].Clear();

            foreach (var item in this.ColorsDescriptions)
            {
                try
                {
                    var c = new ColorSet(String.Format("{0}={1}({2})", item.Item1, item.Item2, item.Item3), this.Colors);
                    this.errors[this.colorsListBox].Add(this.Colors.GetColorSet(c.Name) != null);
                    this.Colors.AddColorSet(c);
                }
                catch (InvalidColorSetAttributesException)
                {
                    this.errors[this.colorsListBox].Add(true);
                }
                this.colorsListBox.Items.Add(String.Format("{0}({1})", item.Item1, item.Item2));
            }

            if (this.Colors.Count() == 0)
            {
                this.addVarButton.Enabled = false;
            }
            else
            {
                this.addVarButton.Enabled = true;
            }
            this.refreshVars();
        }

        private void refreshVars()
        {
            this.Colors.ClearVariables();
            this.errors[this.varsListBox].Clear();
            this.varsListBox.Items.Clear();

            foreach (var item in this.VarsDescriptions)
            {
                this.Colors.AddVariable(item.Item1, item.Item2);
                if (String.IsNullOrEmpty(item.Item1) || this.Colors.GetColorSet(item.Item2) == null)
                {
                    this.errors[this.varsListBox].Add(true);
                }
                else
                {
                    this.errors[this.varsListBox].Add(false);
                }
                this.varsListBox.Items.Add(String.Format("{0}: {1}", item.Item1, item.Item2));
            }
        }

        private void refreshFuncs()
        {
            this.errors[this.funcsListBox].Clear();
            this.funcsListBox.Items.Clear();
            this.Colors.ClearFunctions();

            foreach (var item in this.FunctionsDescriptions)
            {
                IMathFunction mf = null;
                try
                {
                    mf = MathFunction.MultiLineFunction(item);
                    this.Colors.AddFunction(item);
                    this.errors[this.funcsListBox].Add(false);
                }
                catch (InvalidFunctionStringException)
                {
                    this.Colors.RegisterAllFunctions();
                    this.errors[this.funcsListBox].Add(true);
                }
                funcsListBox.Items.Add(mf == null ? "<error>" : mf.FunctionName);
            }
        }

        private void colorsListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            var listBox = sender as ListBox;
            if (e.Index == -1)
            {
                return;
            }

            if (this.errors[listBox][e.Index])
            {
                e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }
            if (this.colorsListBox.SelectedIndex == e.Index)
            {
                e.Graphics.DrawRectangle(new Pen(SystemBrushes.GradientActiveCaption, 1), e.Bounds);
            }

            e.Graphics.DrawString(listBox.Items[e.Index].ToString(), new Font("Arial", 8), Brushes.Black, new PointF(0, e.Bounds.Top));
        }

        private void colorsListBox_DoubleClick(object sender, EventArgs e)
        {
            if (this.colorsListBox.SelectedIndex != -1)
            {
                var f = new ModifyColorSetForm(this.Colors, this.ColorsDescriptions[this.colorsListBox.SelectedIndex]);
                f.ShowDialog();
                if (f.Succesful)
                {
                    this._isModified = true;
                    this.ColorsDescriptions[this.colorsListBox.SelectedIndex] = f.ColorSetDescription;
                    this.refreshColors();
                }
            }
        }

        private void removeColorButton_Click(object sender, EventArgs e)
        {
            this._isModified = true;
            this.ColorsDescriptions.RemoveAt(this.colorsListBox.SelectedIndex);
            this.refreshColors();
        }

        private void colorsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.colorsListBox.Refresh();
            this.removeColorButton.Enabled = this.colorsListBox.SelectedIndex != -1;
        }

        private void ColorsEditForm_Load(object sender, EventArgs e)
        {
            this.refreshColors();
            this.refreshFuncs();
        }

        private void varsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.varsListBox.Refresh();
            this.removeVarButton.Enabled = this.varsListBox.SelectedIndex != -1;
        }

        private void addVarButton_Click(object sender, EventArgs e)
        {
            if (this.Colors.Count() == 0)
            {
                return;
            }

            var f = new ModifyVariableForm(this.Colors);
            f.ShowDialog();

            if (f.Succesful)
            {
                this._isModified = true;
                this.VarsDescriptions.Add(new Tuple<string, string>(f.VarName, f.ColorSetName));
                this.refreshVars();
                this.refreshFuncs();
            }
        }

        private void ColorsEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this._isModified)
            {
                return;
            }

            DialogResult d = MessageBox.Show("Сохранить изменения?", "Внимание!", MessageBoxButtons.YesNoCancel);
            if (d == System.Windows.Forms.DialogResult.Cancel)
                e.Cancel = true;
            this.Succesful = d == System.Windows.Forms.DialogResult.Yes;
        }

        public bool Succesful { get; set; }

        private void funcsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.funcsListBox.Refresh();
            this.removeFuncButton.Enabled = this.funcsListBox.SelectedIndex != -1;
        }

        private void varsListBox_DoubleClick(object sender, EventArgs e)
        {
            if (this.varsListBox.SelectedIndex == -1 || this.Colors.Count() == 0)
            {
                return;
            }

            var f = new ModifyVariableForm(this.Colors, this.VarsDescriptions[this.varsListBox.SelectedIndex]);
            f.ShowDialog();

            if (f.Succesful)
            {
                this._isModified = true;
                this.VarsDescriptions[this.varsListBox.SelectedIndex] = new Tuple<string, string>(f.VarName, f.ColorSetName);
                this.refreshVars();
            }
        }

        private void addFuncButton_Click(object sender, EventArgs e)
        {
            var f = new ModifyFunctionForm();
            f.ShowDialog();
            if (f.Succesful)
            {
                this._isModified = true;
                this.FunctionsDescriptions.Add(f.FunctionDescription);
                this.refreshFuncs();
            }
        }

        private void removeVarButton_Click(object sender, EventArgs e)
        {
            if (this.varsListBox.SelectedIndex == -1)
            {
                return;
            }
            this._isModified = true;
            this.VarsDescriptions.RemoveAt(this.varsListBox.SelectedIndex);
            this.refreshVars();
        }

        private void removeFuncButton_Click(object sender, EventArgs e)
        {
            if (this.funcsListBox.SelectedIndex == -1)
            {
                return;
            }
            this._isModified = true;
            this.FunctionsDescriptions.RemoveAt(this.funcsListBox.SelectedIndex);
            this.refreshFuncs();
        }

        private void funcsListBox_DoubleClick(object sender, EventArgs e)
        {
            if (this.funcsListBox.SelectedIndex == -1)
            {
                return;
            }

            var f = new ModifyFunctionForm(this.FunctionsDescriptions[this.funcsListBox.SelectedIndex]);
            f.ShowDialog();
            if (f.Succesful)
            {
                this._isModified = true;
                this.FunctionsDescriptions[this.funcsListBox.SelectedIndex] = f.FunctionDescription;
                this.refreshFuncs();
            }
        }
    }
}
