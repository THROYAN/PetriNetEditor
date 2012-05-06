using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using GraphEditor.App.Models;

using MagicLibrary.MathUtils.Graphs;
using MagicLibrary.MathUtils.PetriNetsUtils.Graphs;

namespace Petri_Net_Editor.App.Models.Wrappers
{
    [Serializable]
    public class PetriNetGraphWrapper : WFGraphWrapper
    {
        public Size DefaultPlaceSize { get; set; }
        public Size DefaultTransitionSize { get; set; }

        private int pCounter { get; set; }
        private int tCounter { get; set; }

        public PetriNetGraph PetriGraph { get { return Graph as PetriNetGraph; } }

        public PetriNetGraphWrapper() : base()
        {
            DefaultPlaceSize = base.DefaultVertexSize;
            DefaultTransitionSize = base.DefaultVertexSize;
            Graph = new PetriNetGraph();
            PetriNetGraphWrapper.SetDefaultEventHandlers(this);
        }

        public static void SetDefaultEventHandlers(PetriNetGraphWrapper graphWrapper)
        {
            WFGraphWrapper.SetDefaultEventHandlers(graphWrapper);

            graphWrapper.Graph.OnVertexAdded += new EventHandler<VerticesModifiedEventArgs>(graphWrapper.graph_OnVertexAdded);
        }

        void graph_OnVertexAdded(object sender, VerticesModifiedEventArgs e)
        {
            if (e.Status == ModificationStatus.Successful)
            {
                WFVertexWrapper last = VertexWrappers.Last() as WFVertexWrapper;

                if (e.Vertex is Place)
                {
                    VertexWrappers.Add(new PlaceWrapper(this, e.Vertex as Place) { Coords = last.Coords, SizeF = DefaultPlaceSize });
                }
                else
                {
                    VertexWrappers.Add(new TransitionWrapper(this, e.Vertex as Transition) { Coords = last.Coords, SizeF = DefaultTransitionSize });
                }
                VertexWrappers.Remove(last);
            }
        }

        public void AddPlace(PointF coords)
        {
            currentCoords = coords;
            PetriGraph.AddPlace();
            currentCoords = new PointF();
        }

        public void AddTransition(PointF coords)
        {
            currentCoords = coords;
            PetriGraph.AddTransition();
            currentCoords = new PointF();
        }

        public override object Clone()
        {
            PetriNetGraphWrapper pWrapper = new PetriNetGraphWrapper();

            this.CopyTo(pWrapper);

            return pWrapper;
        }

        public override void CopyTo(IGraphWrapper graphWrapper)
        {
            base.CopyTo(graphWrapper);

            (graphWrapper as PetriNetGraphWrapper).DefaultPlaceSize = this.DefaultPlaceSize;
            (graphWrapper as PetriNetGraphWrapper).DefaultTransitionSize = this.DefaultTransitionSize;

            PetriNetGraphWrapper.SetDefaultEventHandlers(graphWrapper as PetriNetGraphWrapper);
        }
    }
}
