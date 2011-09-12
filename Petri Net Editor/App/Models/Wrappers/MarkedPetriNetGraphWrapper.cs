using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MagicLibrary.MathUtils.Graphs;
using MagicLibrary.MathUtils.PetriNetsUtils.Graphs;

using GraphEditor.App.Models;

namespace Petri_Net_Editor.App.Models.Wrappers
{
    [Serializable]
    public class MarkedPetriNetGraphWrapper : PetriNetGraphWrapper
    {
        public MarkedPetriGraph markedPetriGraph { get { return Graph as MarkedPetriGraph; } }

        public MarkedPetriNetGraphWrapper() : base()
        {
            Graph = new MarkedPetriGraph();

            MarkedPetriNetGraphWrapper.SetDefaultEventHandlers(this);
        }

        public static void SetDefaultEventHandlers(MarkedPetriNetGraphWrapper gWrapper)
        {
            PetriNetGraphWrapper.SetDefaultEventHandlers(gWrapper);

            gWrapper.Graph.OnVertexAdded += new EventHandler<VerticesModifiedEventArgs>(gWrapper.graph_OnVertexAdded);
        }


        void graph_OnVertexAdded(object sender, VerticesModifiedEventArgs e)
        {
            if (e.Status == ModificationStatus.Successful)
            {
                Random r = new Random();
                WFVertexWrapper last = VertexWrappers.Last() as WFVertexWrapper;
                if (e.Vertex is MarkedPlace)
                {
                    VertexWrappers.Add(new MarkedPlaceWrapper(this, e.Vertex as MarkedPlace) { Coords = last.Coords, SizeF = last.SizeF });
                    VertexWrappers.Remove(last);
                }
                if (e.Vertex is Transition)
                {
                    (last as TransitionWrapper).Angle = r.Next(360);
                }
            }
        }

        public override void CopyTo(IGraphWrapper graphWrapper)
        {
            base.CopyTo(graphWrapper);

            MarkedPetriNetGraphWrapper.SetDefaultEventHandlers(graphWrapper as MarkedPetriNetGraphWrapper);
        }

        public override object Clone()
        {
            MarkedPetriNetGraphWrapper mpWrapper = new MarkedPetriNetGraphWrapper();

            this.CopyTo(mpWrapper);

            return mpWrapper;
        }
    }
}
