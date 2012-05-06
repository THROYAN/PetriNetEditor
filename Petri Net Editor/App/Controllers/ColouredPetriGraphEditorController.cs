using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Petri_Net_Editor.App.Views;
using Petri_Net_Editor.App.Models;
using Petri_Net_Editor.App.Models.Wrappers;

using MagicLibrary.MathUtils.Graphs;
using MagicLibrary.MathUtils.PetriNetsUtils.Graphs;
using MagicLibrary.MathUtils.PetriNetsUtils;

namespace Petri_Net_Editor.App.Controllers
{
    public class ColouredPetriGraphEditorController : PetriGraphEditorController
    {
        public ColouredPetriGraphEditorController(ColouredPetriNetGraphEditView view, string name)
            : base(view,name)
        {
            View = view;
        }

        public ColouredPetriNetGraphEditView geView { get { return View as ColouredPetriNetGraphEditView; } }

        public new void ViewLoad()
        {
            base.ViewLoad();
            geView.graphWrapper = new ColouredPetriGraphWrapper() { DefaultTransitionSize = new Size(2, 20) };
            geView.petriNet = new ColouredPetriNet(geView.graphWrapper.Graph as ColouredPetriGraph);
        }

        public override void DoSomethingElse(PointF coords)
        {
            if (geView.executeState == PetriNetExecuteState.SelectTransition)
            {
                if (geView.selectionVertexIndex != -1)
                    (geView.graphWrapper[geView.selectionVertexIndex].Vertex as ColouredTransition).Execute();
            }
        }

        public override void DoSomethingElseDinamic(PointF coords)
        {
            if (geView.executeState == PetriNetExecuteState.EditGraph)
                SelectVertex(coords);
            if (geView.executeState == PetriNetExecuteState.SelectTransition)
                SelectAvailableTransition(coords);
        }

        public void SelectAvailableTransition(PointF coords)
        {
            int temp = geView.selectionVertexIndex;
            GraphEditor.App.Models.IVertexWrapper tempWrapper = GetSelectedVertex(coords);
            IVertex selected = tempWrapper != null ? tempWrapper.Vertex : null;
            if (selected is ColouredTransition)
            {
                if ((selected as ColouredTransition).IsAvailable())
                    geView.selectionVertexIndex = geView.petriGraph.Graph.GetVertices().IndexOf(selected);
            }
            else
            {
                geView.selectionVertexIndex = -1;
            }
            if (temp != geView.selectionVertexIndex)
            {
                geView.Refresh();
            }
        }

        public override bool OpenGraph(string path)
        {
            var f = base.OpenGraph(path);
            geView.petriNet = new ColouredPetriNet(geView.graphWrapper.Graph as ColouredPetriGraph);
            (geView.graphWrapper.Graph as ColouredPetriGraph).Colors.RegisterAllFunctions();
            return f;
        }
    }
}
