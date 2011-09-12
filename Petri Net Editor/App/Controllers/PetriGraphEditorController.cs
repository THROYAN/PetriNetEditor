using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
//using System.Windows.Forms;

using MagicLibrary.MVC;
using Petri_Net_Editor.App.Views;
using Petri_Net_Editor.App.Models;
using Petri_Net_Editor.App.Models.Wrappers;

using GraphEditor.App.Controllers;
using GraphEditor.App.Models;

namespace Petri_Net_Editor.App.Controllers
{
    public class PetriGraphEditorController : GraphEditController
    {
        public PetriGraphEditorController(PetriNetGraphEditView view, string name)
            : base(view,name)
        {
            View = view;
        }

        private PetriNetGraphEditView pgeView { get { return (PetriNetGraphEditView)View; } }

        public new void ViewLoad()
        {
            pgeView.graphWrapper = new PetriNetGraphWrapper() { DefaultTransitionSize = new Size(7, 20) };
            pgeView.selectedVertexIndex = -1;
            pgeView.selectionVertexIndex = -1;
            pgeView.points = new List<PointF>();
        }

        public override void AddVertex(PointF coords)
        {
            if (!pgeView.addTransition)
                AddPlace(coords);
            else
                AddTransition(coords);
        }

        public void AddPlace(PointF coords)
        {
            if (pgeView.selectionVertexIndex == -1)
                pgeView.petriGraph.AddPlace(coords);
        }

        public void AddTransition(PointF coords)
        {
            if (pgeView.selectionVertexIndex == -1)
                pgeView.petriGraph.AddTransition(coords);
        }

        public void RotateTransition(double angle)
        {
            if (pgeView.selectionVertexIndex != -1 && pgeView.petriGraph.VertexWrappers[pgeView.selectionVertexIndex] is TransitionWrapper)
            {
                (pgeView.petriGraph.VertexWrappers[pgeView.selectionVertexIndex] as TransitionWrapper).Angle += angle;
                pgeView.Refresh();
            }
        }

        //public void SetAction(char key)
        //{
        //    if (key == '1')
        //        pgeView.action = 1;
        //    if (key == '2')
        //        pgeView.action = 2;
        //    if (key == '3')
        //        pgeView.action = 3;
        //    if (key == '4')
        //        pgeView.action = 4;
        //}

        //public void SelectElement(Point coords)
        //{
        //    bool f = true;
        //    for (int i = 0; i < pgeView.petriGraph.Order; i++)
        //    {
        //        if (
        //                (new RectangleF(
        //                    pgeView.petriGraph[i].Position,
        //                    pgeView.petriGraph[i].Size
        //                )).Contains(coords)
        //            )
        //        {
        //            f = false;
        //            if (pgeView.selectionVertexIndex != i)
        //            {
        //                pgeView.selectionVertexIndex = i;
        //                pgeView.Refresh();
        //            }
        //            break;
        //        }
        //    }
        //    if (f && pgeView.selectionVertexIndex != -1)
        //    {
        //        pgeView.selectionVertexIndex = -1;
        //        pgeView.Refresh();
        //    }
        //}

        //public void GraphEdit(Point coords)
        //{
        //    switch (pgeView.action)
        //    {
        //        case 1:
        //            if (pgeView.selectionVertexIndex == -1)
        //            {
        //                pgeView.points.Clear();
        //                pgeView.petriGraph.AddPlace(coords);
        //            }
        //            break;
        //        case 2:
        //            if (pgeView.selectionVertexIndex == -1)
        //            {
        //                pgeView.petriGraph.AddTransition(coords);
        //                pgeView.points.Clear();
        //            }
        //            break;
        //        case 3:
        //            if (pgeView.selectionVertexIndex != -1)
        //            {
        //                pgeView.selectedVertexIndex = pgeView.selectionVertexIndex;
        //                pgeView.action = 4;
        //            }
        //            break;
        //        case 4:
        //            if (pgeView.selectionVertexIndex != -1 && pgeView.selectedVertexIndex != -1)
        //            {
        //                pgeView.petriGraph.AddArc(pgeView.petriGraph[pgeView.selectedVertexIndex].Name, pgeView.petriGraph[pgeView.selectionVertexIndex].Name, 1, pgeView.points.ToArray());
        //            }
        //            else if (pgeView.selectedVertexIndex != -1)
        //            {
        //                pgeView.points.Add(coords);
        //            }
        //            break;
        //    }
        //    pgeView.Refresh();
        //}

        //public void RemoveSelected()
        //{
        //    if (pgeView.selectionVertexIndex != -1)
        //    {
        //        pgeView.petriGraph.RemoveVertex(pgeView.petriGraph[pgeView.selectionVertexIndex]);
        //        pgeView.selectionVertexIndex = -1;
        //    }
        //}

        //public WFVertexWrapper SelectionVertex()
        //{
        //    return pgeView.petriGraph[pgeView.selectionVertexIndex];
        //}
    }
}
