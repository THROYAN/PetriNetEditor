using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GraphEditor.App.Controllers;
using Petri_Net_Editor.App.Views;

namespace Petri_Net_Editor.App.Controllers
{
    public class PetriNetGraphEditFormController : GraphEditFormController
    {
        public new PetriGraphEditFormView MainView { get { return View as PetriGraphEditFormView; } set { View = value; } }

        public PetriNetGraphEditFormController(string name, PetriGraphEditFormView view) : base(name, view) { }

        public override GraphEditor.App.Views.GraphView NewGraphView()
        {
            return new PetriNetGraphEditView(new PictureBox());
        }
    }
}
