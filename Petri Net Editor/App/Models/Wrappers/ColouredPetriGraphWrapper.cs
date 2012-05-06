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
    [Serializable]
    public class ColouredPetriGraphWrapper : PetriNetGraphWrapper
    {
        public List<Tuple<string, string, string>> ColorsDescription { get; set; }
        public List<Tuple<string, string>> VariablesDescription { get; set; }
        public List<string> FunctionsDescription { get; set; }

        public ColouredPetriGraphWrapper()
            : base()
        {
            this.Graph = new ColouredPetriGraph();
            DefaultPlaceSize = base.DefaultVertexSize;
            DefaultTransitionSize = base.DefaultVertexSize;
            this.ColorsDescription = new List<Tuple<string,string,string>>();
            this.VariablesDescription = new List<Tuple<string, string>>();
            this.FunctionsDescription = new List<string>();

            ColouredPetriGraphWrapper.SetDefaultEventHandlers(this);
        }

        public static void SetDefaultEventHandlers(ColouredPetriGraphWrapper graphWrapper)
        {
            PetriNetGraphWrapper.SetDefaultEventHandlers(graphWrapper);

            graphWrapper.Graph.OnVertexAdded += new EventHandler<VerticesModifiedEventArgs>(graphWrapper.Graph_OnVertexAdded);
            graphWrapper.Graph.OnEdgeAdded += new EventHandler<EdgesModifiedEventArgs>(graphWrapper.Graph_OnEdgeAdded);
        }

        private void Graph_OnEdgeAdded(object sender, EdgesModifiedEventArgs e)
        {
            if (e.Status == ModificationStatus.Successful)
            {
                WFArcWrapper last = this.ArcWrappers.Last() as WFArcWrapper;
                this.ArcWrappers.Add(new ColouredArcWrapper(this, e.Edge as ColouredArc) { Points = this.currentPoints });
                this.ArcWrappers.Remove(last);
            }
        }

        private void Graph_OnVertexAdded(object sender, VerticesModifiedEventArgs e)
        {
            if (e.Status == ModificationStatus.Successful)
            {
                WFVertexWrapper last = VertexWrappers.Last() as WFVertexWrapper;
                if (e.Vertex is ColouredTransition)
                {
                    VertexWrappers.Add(new ColouredTransitionWrapper(this, e.Vertex as ColouredTransition) { Coords = last.Coords, SizeF = DefaultTransitionSize });
                }
                if (e.Vertex is ColouredPlace)
                {
                    VertexWrappers.Add(new ColouredPlaceWrapper(this, e.Vertex as ColouredPlace) { Coords = last.Coords, SizeF = DefaultPlaceSize });
                }
                VertexWrappers.Remove(last);
            }
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
            (graphWrapper as ColouredPetriGraphWrapper).ColorsDescription = new List<Tuple<string, string, string>>(this.ColorsDescription);
            (graphWrapper as ColouredPetriGraphWrapper).VariablesDescription = new List<Tuple<string, string>>(this.VariablesDescription);
            (graphWrapper as ColouredPetriGraphWrapper).FunctionsDescription = new List<string>(this.FunctionsDescription);

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
