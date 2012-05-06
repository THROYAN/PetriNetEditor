using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using Petri_Net_Editor.App.Models;
using Petri_Net_Editor.App.Controllers;

using Microsoft.VisualBasic;
using Petri_Net_Editor.App.Models.Wrappers;
using MagicLibrary.MathUtils.PetriNetsUtils.Graphs;
using MagicLibrary.MathUtils.Functions;

namespace Petri_Net_Editor.App.Views
{
    public class ColouredPetriGraphEditFormView : PetriGraphEditFormView
    {
        public RadioButton addTranistionRadioButton;
        private Button editColorsButton;
        public RadioButton addTransitionRadioButton;
    
        public new ColouredPetriNetGraphEditView selectedGraph { get { return base.selectedGraph as ColouredPetriNetGraphEditView; } }

        public new ColouredPetriNetEditFormController MainController { get { return GetController("MainController") as ColouredPetriNetEditFormController; } }

        public ColouredPetriGraphEditFormView()
        {
            InitializeComponent();
            Controllers.RemoveAll(c => c.Name.Equals("MainController"));
            AddController(new ColouredPetriNetEditFormController("MainController", this));

            this.radioGroup.Add(this.addTranistionRadioButton, GraphEditor.App.Views.GraphEditAction.AddVertex);
        }

        public new void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColouredPetriGraphEditFormView));
            this.addTransitionRadioButton = new System.Windows.Forms.RadioButton();
            this.addTranistionRadioButton = new System.Windows.Forms.RadioButton();
            this.editColorsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(0, 63);
            this.tabControl1.Size = new System.Drawing.Size(841, 479);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(841, 39);
            // 
            // addArcRadioButton
            // 
            this.addArcRadioButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.addArcRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.addArcRadioButton.Location = new System.Drawing.Point(70, 6);
            // 
            // moveRadioButton
            // 
            this.moveRadioButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.moveRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Blue;
            // 
            // removeArcRadioButton
            // 
            this.removeArcRadioButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.removeArcRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Blue;
            // 
            // removeVertexRadioButton
            // 
            this.removeVertexRadioButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.removeVertexRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Blue;
            // 
            // addVertexRadioButton
            // 
            this.addVertexRadioButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.addVertexRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Blue;
            this.addVertexRadioButton.CheckedChanged += new System.EventHandler(this.addVertexRadioButton_CheckedChanged_2);
            // 
            // changeWeightRadioButton
            // 
            this.changeWeightRadioButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.changeWeightRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Blue;
            this.changeWeightRadioButton.Location = new System.Drawing.Point(263, 6);
            this.changeWeightRadioButton.Visible = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Size = new System.Drawing.Size(668, 39);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Size = new System.Drawing.Size(841, 39);
            // 
            // splitContainer3
            // 
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.addTranistionRadioButton);
            this.splitContainer3.Size = new System.Drawing.Size(628, 39);
            this.splitContainer3.SplitterDistance = 103;
            // 
            // splitContainer4
            // 
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.editColorsButton);
            this.splitContainer4.Size = new System.Drawing.Size(521, 39);
            this.splitContainer4.SplitterDistance = 71;
            // 
            // addTransitionRadioButton
            // 
            this.addTransitionRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.addTransitionRadioButton.AutoSize = true;
            this.addTransitionRadioButton.BackColor = System.Drawing.SystemColors.Control;
            this.addTransitionRadioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addTransitionRadioButton.BackgroundImage")));
            this.addTransitionRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addTransitionRadioButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.addTransitionRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Blue;
            this.addTransitionRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTransitionRadioButton.Location = new System.Drawing.Point(253, 6);
            this.addTransitionRadioButton.Name = "addTransitionRadioButton";
            this.addTransitionRadioButton.Size = new System.Drawing.Size(28, 25);
            this.addTransitionRadioButton.TabIndex = 7;
            this.addTransitionRadioButton.Text = "   ";
            this.addTransitionRadioButton.UseVisualStyleBackColor = false;
            this.addTransitionRadioButton.CheckedChanged += new System.EventHandler(this.addTransitionRadioButton_CheckedChanged_1);
            // 
            // addTranistionRadioButton
            // 
            this.addTranistionRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.addTranistionRadioButton.AutoSize = true;
            this.addTranistionRadioButton.BackColor = System.Drawing.SystemColors.Control;
            this.addTranistionRadioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addTranistionRadioButton.BackgroundImage")));
            this.addTranistionRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addTranistionRadioButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.addTranistionRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Blue;
            this.addTranistionRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTranistionRadioButton.Location = new System.Drawing.Point(37, 6);
            this.addTranistionRadioButton.Name = "addTranistionRadioButton";
            this.addTranistionRadioButton.Size = new System.Drawing.Size(28, 25);
            this.addTranistionRadioButton.TabIndex = 6;
            this.addTranistionRadioButton.Text = "   ";
            this.addTranistionRadioButton.UseVisualStyleBackColor = false;
            this.addTranistionRadioButton.CheckedChanged += new System.EventHandler(this.addTranistionRadioButton_CheckedChanged);
            // 
            // editColorsButton
            // 
            this.editColorsButton.BackgroundImage = global::Petri_Net_Editor.Properties.Resources._1336228806_preferences_desktop_color;
            this.editColorsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editColorsButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.editColorsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editColorsButton.Location = new System.Drawing.Point(3, 6);
            this.editColorsButton.Name = "editColorsButton";
            this.editColorsButton.Size = new System.Drawing.Size(28, 25);
            this.editColorsButton.TabIndex = 7;
            this.editColorsButton.UseVisualStyleBackColor = true;
            this.editColorsButton.Click += new System.EventHandler(this.editColorsButton_Click);
            // 
            // ColouredPetriGraphEditFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(841, 542);
            this.Name = "ColouredPetriGraphEditFormView";
            this.Text = "ColouredPetriNetGraph Editor";
            this.Load += new System.EventHandler(this.MarkedPetriGraphEditorView_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MarkedPetriGraphEditorView_Paint);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MarkedPetriGraphEditorView_Load(object sender, EventArgs e)
        {
            ToolStripMenuItem item20 = new ToolStripMenuItem("Запуск") { Name = "Запуск"};

            ToolStripMenuItem item21 = new ToolStripMenuItem("Выбрать переход");
            item21.Click += new EventHandler(item21_Click);
            ToolStripMenuItem item22 = new ToolStripMenuItem("Случайный переход");
            item22.ShortcutKeys = Keys.R | Keys.Control;
            item22.Click += new EventHandler(item3_Click);
            ToolStripMenuItem item23 = new ToolStripMenuItem("Автоматический запуск");
            item23.ShortcutKeys = Keys.F5;
            item23.Click += new EventHandler(item4_Click);
            item20.DropDownItems.AddRange(new ToolStripItem[] { item21, item22, item23 });

            menuStrip1.Items.Insert(2,item20);
            GraphMenuEnable = false;
        }

        void item21_Click(object sender, EventArgs e)
        {
            selectedGraph.action = GraphEditor.App.Views.GraphEditAction.SomethingElse;
            selectedGraph.executeState = PetriNetExecuteState.SelectTransition;
        }

        void item4_Click(object sender, EventArgs e)
        {
            int count = 50;
            string c = selectedGraph.InputWindow("Введите количество иттераций:", "Запуск анимации:", count.ToString());
            string t = selectedGraph.InputWindow("Введите задержку анимации(ms):", "Запуск анимации:", count.ToString());
            try
            {
                selectedGraph.action = GraphEditor.App.Views.GraphEditAction.SomethingElse;
                selectedGraph.executeState = PetriNetExecuteState.AutoExecute;
                selectedGraph.StartTimer(Convert.ToInt32(t), Convert.ToInt32(c));
            }
            catch { }
        }

        void item3_Click(object sender, EventArgs e)
        {
            if (selectedGraph.petriNet.GetAvailableTransitions().Length > 0)
            {
                selectedGraph.petriNet.ExecuteRandomTransition();
                selectedGraph.Refresh();
            }
        }

        void item2_Click(object sender, EventArgs e)
        {
            selectedGraph.marks = 0;
            selectedGraph.action = GraphEditor.App.Views.GraphEditAction.SomethingElse;
            selectedGraph.executeState = PetriNetExecuteState.EditGraph;
        }

        private void MarkedPetriGraphEditorView_Paint(object sender, PaintEventArgs e)
        {
            if(selectedGraph != null)
                selectedGraph.petriNet.GetAvailableTransitions().ToList().ForEach(t => selectedGraph.graphWrapper[t.Value as string].Draw(e.Graphics, Pens.Red));
        }

        public override bool GraphMenuEnable
        {
            set
            {
                base.GraphMenuEnable = value;
                if(menuStrip1.Items["Запуск"] != null)
                    menuStrip1.Items["Запуск"].Enabled = value;
            }
        }

        private void addVertexRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedGraph.addTransition = false;
        }

        private void addTransitionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            MainController.SetAction(GraphEditor.App.Views.GraphEditAction.AddVertex);
            selectedGraph.addTransition = true;
        }

        private void addVertexRadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            this.selectedGraph.addTransition = false;
        }

        private void addTransitionRadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            this.MainController.SetAction(GraphEditor.App.Views.GraphEditAction.AddVertex);
            this.selectedGraph.addTransition = true;
        }

        private void addTranistionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedGraph.addTransition = true;
            this.MainController.SelectRadioButton(sender as RadioButton);
        }

        private void addVertexRadioButton_CheckedChanged_2(object sender, EventArgs e)
        {
            this.selectedGraph.addTransition = false;
        }

        private void editColorsButton_Click(object sender, EventArgs e)
        {
            var wrapper = this.selectedGraph.graphWrapper as ColouredPetriGraphWrapper;
            var f = new ColorsEditForm(wrapper.ColorsDescription, wrapper.VariablesDescription, wrapper.FunctionsDescription);
            f.ShowDialog();

            if (f.Succesful)
            {
                wrapper.ColorsDescription = new List<Tuple<string, string, string>>(f.ColorsDescriptions);
                wrapper.VariablesDescription = new List<Tuple<string, string>>(f.VarsDescriptions);
                wrapper.FunctionsDescription = new List<string>(f.FunctionsDescriptions);
                var cGraph = wrapper.Graph as ColouredPetriGraph;
                cGraph.Colors.ClearColors();
                cGraph.Colors.ClearFunctions();
                Function.ResetMathFunctions();

                foreach (var color in f.Colors)
                {
                    cGraph.Colors.AddColorSet(color);
                }

                foreach (var var in f.Colors.ColorVariables)
                {
                    cGraph.Colors.AddVariable(var.Name, var.ColorSet.Name);
                }

                foreach (var func in f.Colors.FunctionsDescription)
                {
                    cGraph.Colors.AddFunction(func);
                }
                this.Refresh();
            }
        }
    }

    public enum PetriNetExecuteState { SelectTransition, RandomTransition, AutoExecute, EditGraph };
}
