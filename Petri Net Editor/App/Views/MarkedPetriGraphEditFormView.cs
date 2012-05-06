using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using Petri_Net_Editor.App.Models;
using Petri_Net_Editor.App.Controllers;

using Microsoft.VisualBasic;

namespace Petri_Net_Editor.App.Views
{
    public class MarkedPetriGraphEditFormView : PetriGraphEditFormView
    {
        public new MarkedPetriNetGraphEditView selectedGraph { get { return base.selectedGraph as MarkedPetriNetGraphEditView; } }

        public new MarkedPetriNetEditFormController MainController { get { return GetController("MainController") as MarkedPetriNetEditFormController; }}

        public MarkedPetriGraphEditFormView()
        {
            InitializeComponent();
            Controllers.RemoveAll(c => c.Name == "MainController");
            AddController(new MarkedPetriNetEditFormController("MainController", this));
        }

        public new void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarkedPetriGraphEditFormView));
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(0, 61);
            this.tabControl1.Size = new System.Drawing.Size(841, 481);
            // 
            // MarkedPetriGraphEditFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(841, 542);
            this.Name = "MarkedPetriGraphEditFormView";
            this.Text = "MarkedPetriNetGraph Editor";
            this.Load += new System.EventHandler(this.MarkedPetriGraphEditorView_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MarkedPetriGraphEditorView_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MarkedPetriGraphEditorView_Load(object sender, EventArgs e)
        {
            ToolStripItemCollection c = (menuStrip1.Items["добавлениеToolStripMenuItem"] as ToolStripDropDownItem).DropDownItems;
            ToolStripMenuItem item1 = new ToolStripMenuItem("Фишки+");
            item1.Click += new EventHandler(item1_Click);
            ToolStripMenuItem item2 = new ToolStripMenuItem("Фишки-");
            item2.Click += new EventHandler(item2_Click);

            c.AddRange(new ToolStripItem[] { item1, item2 });

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

        void item1_Click(object sender, EventArgs e)
        {
            selectedGraph.marks = +1;
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
    }
}
