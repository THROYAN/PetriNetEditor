using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MagicLibrary.MathUtils.PetriNetsUtils.Graphs;
using MagicLibrary.MathUtils.Graphs;
using GraphEditor.App.Models;
using GraphEditor.App.Views;
using System.Windows.Forms;

using Petri_Net_Editor.App.Views;

namespace Petri_Net_Editor.App.Models.Wrappers
{
    public class ColouredPetriGraphWrapper : PetriNetGraphWrapper
    {
        public ColouredPetriGraphWrapper()
            : base()
        {
            this.Graph = new ColouredPetriGraph();
            DefaultPlaceSize = base.DefaultVertexSize;
            DefaultTransitionSize = base.DefaultVertexSize;

            ColouredPetriGraphWrapper.SetDefaultEventHandlers(this);
        }

        public static void SetDefaultEventHandlers(ColouredPetriGraphWrapper graphWrapper)
        {
            PetriNetGraphWrapper.SetDefaultEventHandlers(graphWrapper);

            graphWrapper.Graph.OnVertexAdded += new EventHandler<VerticesModifiedEventArgs>(graphWrapper.Graph_OnVertexAdded);
        }

        private void Graph_OnVertexAdded(object sender, VerticesModifiedEventArgs e)
        {
            WFVertexWrapper last = VertexWrappers.Last() as WFVertexWrapper;
            if (e.Vertex is Transition)
            {
                VertexWrappers.Add(new TransitionWrapper(this, e.Vertex as Transition) { Coords = last.Coords, SizeF = DefaultTransitionSize });
            }
            if (e.Vertex is ColouredPlace)
            {
                VertexWrappers.Add(new ColouredPlaceWrapper(this, e.Vertex as ColouredPlace) { Coords = last.Coords, SizeF = DefaultPlaceSize });
            }
            VertexWrappers.Remove(last);
        }

        public override void EditGraph()
        {
            IGraphConstructor gc;
            if (this.Graph is BiGraph)
                gc = new ColouredPetriGraphConstructorForm(this);
            else
                gc = new GraphConstructorForm(this);
            (gc as Form).ShowDialog();

            if (gc.Succesful)
            {
                //gc.GraphWrapper.CopyTo(this.selectedGraph.graphWrapper);
                //this.selectedGraph.graphWrapper = gc.GraphWrapper.Clone() as WFGraphWrapper;
                gc.GraphWrapper.CopyTo(this);
            }
        }

        public override void CopyTo(IGraphWrapper graphWrapper)
        {
            base.CopyTo(graphWrapper);

            (graphWrapper as PetriNetGraphWrapper).DefaultPlaceSize = this.DefaultPlaceSize;
            (graphWrapper as PetriNetGraphWrapper).DefaultTransitionSize = this.DefaultTransitionSize;

            ColouredPetriGraphWrapper.SetDefaultEventHandlers(graphWrapper as ColouredPetriGraphWrapper);
        }

        public override object Clone()
        {
            ColouredPetriGraphWrapper wrapper = new ColouredPetriGraphWrapper();
            this.CopyTo(wrapper);
            return wrapper;
        }
    }
}
