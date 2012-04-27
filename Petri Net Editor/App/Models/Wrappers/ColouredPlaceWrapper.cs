using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using GraphEditor.App.Models;

using MagicLibrary.MathUtils.PetriNetsUtils.Graphs;

using Petri_Net_Editor.App.Views;

namespace Petri_Net_Editor.App.Models.Wrappers
{
    [Serializable]
    public class ColouredPlaceWrapper : PlaceWrapper
    {
        public ColouredPlaceWrapper(IGraphWrapper graphWrapper, ColouredPlace place) : base(graphWrapper, place) { }
        public ColouredPlace ColouredPlace { get { return this.Vertex as ColouredPlace; } }

        public override void EditVertex()
        {
            ColouredPlaceModifyForm vm = new ColouredPlaceModifyForm(this);
            vm.ShowDialog();
            if (vm.Succesful)
            {
                vm.VertexWrapper.CopyTo(this);// as MagicLibrary.MathUtils.Graphs.Vertex;
            }
        }

        public override void Draw(Graphics g, Pen p)
        {
            base.Draw(g, p);

            var r = this.RectangleF;

            var sText = g.MeasureString(this.ColouredPlace.InitFunction, new Font("Arial", 8));
            g.FillRectangle(Brushes.Gray, r.Right, r.Top, sText.Width, sText.Height);

            g.DrawString(
                this.ColouredPlace.InitFunction,
                new Font("Arial", 8),
                Brushes.Blue,
                r.Right,
                r.Top
            );
#warning Нарисовать токены позиции
        }
    }
}
