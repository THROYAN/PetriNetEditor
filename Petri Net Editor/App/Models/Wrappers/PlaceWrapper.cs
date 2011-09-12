using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

using GraphEditor.App.Models;
using MagicLibrary.MathUtils.PetriNetsUtils.Graphs;

namespace Petri_Net_Editor.App.Models.Wrappers
{
    [Serializable]
    public class PlaceWrapper : WFVertexWrapper
    {
        public PlaceWrapper(IGraphWrapper graphWrapper, Place place) : base(graphWrapper, place) { }
    }
}
