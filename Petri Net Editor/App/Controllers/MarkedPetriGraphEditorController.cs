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
    public class MarkedPetriGraphEditorController : PetriGraphEditorController
    {
        public MarkedPetriGraphEditorController(MarkedPetriNetGraphEditView view, string name)
            : base(view,name)
        {
            View = view;
        }

        public MarkedPetriNetGraphEditView geView { get { return View as MarkedPetriNetGraphEditView; } }

        public void ChangeMarks(PointF coords, int delta)
        {
            GraphEditor.App.Models.IVertexWrapper vw = GetSelectedVertex(coords);
            if (vw == null)
                return;
            IVertex v = vw.Vertex;
            if (v is MarkedPlace)
            {
                (v as MarkedPlace).TokenCount += delta;
            }
        }

        public new void ViewLoad()
        {
            base.ViewLoad();
            geView.graphWrapper = new MarkedPetriNetGraphWrapper() { DefaultTransitionSize = new Size(2, 20) };
            geView.petriNet = new PetriNet(geView.graphWrapper.Graph as MarkedPetriGraph);
        }

        public override void DoSomethingElse(PointF coords)
        {
            if (geView.executeState == PetriNetExecuteState.EditGraph)
            {
                ChangeMarks(coords, geView.marks);
            }
            if (geView.executeState == PetriNetExecuteState.SelectTransition)
            {
                if (geView.selectionVertexIndex != -1)
                    (geView.graphWrapper[geView.selectionVertexIndex].Vertex as Transition).Execute();
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
            if (selected is Transition)
            {
                if((selected as Transition).IsAvailable())
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
            geView.petriNet = new PetriNet(geView.graphWrapper.Graph as MarkedPetriGraph);
            return f;
        }
    }
}
