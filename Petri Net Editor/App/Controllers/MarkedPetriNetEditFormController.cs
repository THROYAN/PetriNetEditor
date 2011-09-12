using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Petri_Net_Editor.App.Views;

namespace Petri_Net_Editor.App.Controllers
{
    public class MarkedPetriNetEditFormController : PetriNetGraphEditFormController
    {
        public new MarkedPetriGraphEditFormView MainView { get { return View as MarkedPetriGraphEditFormView; } set { View = value; } }

        public MarkedPetriNetEditFormController(string name, PetriGraphEditFormView view) : base(name, view) { }

        public override GraphEditor.App.Views.GraphView NewGraphView()
        {
            return new MarkedPetriNetGraphEditView(new PictureBox());
        }
    }
}
