using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using GraphEditor.App.Views;
using Petri_Net_Editor.App.Controllers;
using Petri_Net_Editor.App.Models;
using Petri_Net_Editor.App.Models.Wrappers;

namespace Petri_Net_Editor.App.Views
{
    public class PetriNetGraphEditView : GraphView
    {
        public bool addTransition { get; set; }

        public PetriNetGraphWrapper petriGraph { get { return graphWrapper as PetriNetGraphWrapper; } }
        
        public new PetriGraphEditorController MainController { get { return GetController("MainController") as PetriGraphEditorController; } }

        public PetriNetGraphEditView(Control control)
            : base(control)
        {
            Controllers.RemoveAll(controller => controller.Name == "MainController");
            Controllers.Add(new PetriGraphEditorController(this, "MainController"));
            MainController.ViewLoad();
            addTransition = false;
            this.Control.MouseWheel += new MouseEventHandler(Control_MouseWheel);
        }

        void Control_MouseWheel(object sender, MouseEventArgs e)
        {
            MainController.RotateTransition(e.Delta / 120);
        }

    }
}
