using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Petri_Net_Editor.App.Views;

namespace Petri_Net_Editor.App.Controllers
{
    public class ColouredPetriNetEditFormController : PetriNetGraphEditFormController
    {
        public new ColouredPetriGraphEditFormView MainView { get { return View as ColouredPetriGraphEditFormView; } set { View = value; } }

        public ColouredPetriNetEditFormController(string name, ColouredPetriGraphEditFormView view) : base(name, view) { }

        public override GraphEditor.App.Views.GraphView NewGraphView()
        {
            return new ColouredPetriNetGraphEditView(new PictureBox());
        }
    }
}
