using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Petri_Net_Editor.App.Controllers;
using Petri_Net_Editor.App.Views;
using Petri_Net_Editor.App.Models;

using MagicLibrary.MVC.WinForms;
using GraphEditor.App.Views;
using GraphEditor.App.Models;

namespace Petri_Net_Editor.App.Views
{
    public partial class PetriGraphEditFormView : GraphEditForm
    {
        public new PetriNetGraphEditView selectedGraph { get { return base.selectedGraph as PetriNetGraphEditView; } }

        public new PetriNetGraphEditFormController MainController
        {
            get { return GetController("MainController") as PetriNetGraphEditFormController; }
            set { Controllers.RemoveAll(c => c.Name == value.Name); AddController(value); }
        }

        public PetriGraphEditFormView()
        {
            InitializeComponent();
            MainController = new PetriNetGraphEditFormController("MainController", this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolStripMenuItem item = new ToolStripMenuItem("Добавить переход");
            item.Click += new EventHandler(item_Click);
            (menuStrip1.Items["добавлениеToolStripMenuItem"] as ToolStripDropDownItem).DropDownItems["добавитьВершинуToolStripMenuItem"].Text = "Добавить позицию";
            (menuStrip1.Items["добавлениеToolStripMenuItem"] as ToolStripDropDownItem).DropDownItems.Insert(1, item);
            (menuStrip1.Items["добавлениеToolStripMenuItem"] as ToolStripDropDownItem).DropDownItems["добавитьВершинуToolStripMenuItem"].Click += new EventHandler(PetriGraphEditorView_Click);
        }

        void PetriGraphEditorView_Click(object sender, EventArgs e)
        {
            selectedGraph.addTransition = false;
        }

        void item_Click(object sender, EventArgs e)
        {
            selectedGraph.action = GraphEditActions.AddVertex;
            selectedGraph.addTransition = true;
        }
    }
}
