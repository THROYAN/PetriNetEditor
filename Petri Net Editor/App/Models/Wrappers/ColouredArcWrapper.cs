using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GraphEditor.App.Models;
using MagicLibrary.MathUtils.PetriNetsUtils.Graphs;
using Petri_Net_Editor.App.Views;

namespace Petri_Net_Editor.App.Models.Wrappers
{
    [Serializable]
    public class ColouredArcWrapper : WFArcWrapper
    {
        public ColouredArc Arc { get { return this.Edge as ColouredArc; } }

        public ColouredArcWrapper(ColouredPetriGraphWrapper graphWrapper, ColouredArc arc)
            : base(graphWrapper, arc)
        {

        }

        public override string Text
        {
            get
            {
                return this.Arc.Name;
            }
        }

        public override void EditArc()
        {
            ColouredArcModifyForm am = new ColouredArcModifyForm(this);
            am.ShowDialog();
            if (am.Succesful)
            {
                am.ArcWrapper.CopyTo(this);
            }
        }

        public override void CopyTo(IArcWrapper arcWrapper)
        {
            base.CopyTo(arcWrapper);
            //(arcWrapper as ColouredArcWrapper)
        }

        public override object Clone()
        {
            ColouredArcWrapper c = new ColouredArcWrapper(this.graphWrapper as ColouredPetriGraphWrapper, this.Arc);
            this.CopyTo(c);
            return c;
        }
    }
}
