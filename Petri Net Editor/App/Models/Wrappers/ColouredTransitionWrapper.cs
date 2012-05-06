using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GraphEditor.App.Models;
using MagicLibrary.MathUtils.PetriNetsUtils.Graphs;
using System.Drawing;
using GraphEditor.App.Views;
using Petri_Net_Editor.App.Views;

namespace Petri_Net_Editor.App.Models.Wrappers
{
    [Serializable]
    public class ColouredTransitionWrapper : WFVertexWrapper
    {
        public ColouredTransition Transition { get { return this.Vertex as ColouredTransition; } }
        public ColouredPetriGraphWrapper cGraphWrapper { get { return this.graphWrapper as ColouredPetriGraphWrapper; } }

        public ColouredTransitionWrapper(ColouredPetriGraphWrapper graphWrapper, ColouredTransition transition)
            : base(graphWrapper, transition)
        {
        }

        public override Rectangle SelectionRectangle
        {
            get
            {
                RectangleF r = RectangleF;

                List<PointF> ps =
                                (MagicLibrary.Graphic.MGraphic.T(Center)
                                * MagicLibrary.Graphic.MGraphic.R(Angle)
                                * MagicLibrary.Graphic.MGraphic.T(-Center.X, -Center.Y)
                                * r).ToList();
                return Rectangle.Inflate(new Rectangle((int)ps.Min(p => p.X),
                                      (int)ps.Min(p => p.Y),
                                      (int)ps.Max(p => p.X) - (int)ps.Min(p => p.X),
                                      (int)ps.Max(p => p.Y) - (int)ps.Min(p => p.Y)
                                      ), 4, 4);
            }
        }

        public double Angle { get; set; }

        public override void Draw(Graphics g, Pen p)
        {
            Rectangle r = Rectangle;

            PointF[] ps =
                            MagicLibrary.Graphic.MGraphic.T(Center)
                            * MagicLibrary.Graphic.MGraphic.R(Angle)
                            * MagicLibrary.Graphic.MGraphic.T(-Center.X, -Center.Y)
                            * r;

            g.FillPolygon(new SolidBrush(p.Color),ps);
            
            g.DrawString(
                this.Name,
                new Font("Arial", 8),
                Brushes.Blue,
                r.Left,
                r.Bottom
            );
        }

        public override void Draw(Graphics g, Pen p, MagicLibrary.MathUtils.Matrix m)
        {
            Rectangle r = Rectangle;

            PointF[] ps =
                            m
                            * MagicLibrary.Graphic.MGraphic.T(Center)
                            * MagicLibrary.Graphic.MGraphic.R(Angle)
                            * MagicLibrary.Graphic.MGraphic.T(-Center.X, -Center.Y)
                            * r;

            g.FillPolygon(new SolidBrush(p.Color), ps);

            g.DrawString(
                Name,
                new Font("Arial", 8),
                Brushes.Blue,
                m * new PointF(r.Left, r.Bottom)
            );
        }

        public override bool Hit(float x, float y)
        {
            return RectangleF.Inflate(RectangleF, 6, 6).Contains(x, y);
        }

        public override void EditVertex()
        {
            ColouredTransitionModifyForm vm = new ColouredTransitionModifyForm(this);
            vm.ShowDialog();
            if (vm.Succesful)
            {
                vm.VertexWrapper.CopyTo(this);// as MagicLibrary.MathUtils.Graphs.Vertex;
            }
        }

        public override void CopyTo(IVertexWrapper vertexWrapper)
        {
            base.CopyTo(vertexWrapper);
            ColouredTransitionWrapper wrapper = vertexWrapper as ColouredTransitionWrapper;
            wrapper.Angle = this.Angle;
        }

        public override object Clone()
        {
            ColouredTransitionWrapper t = new ColouredTransitionWrapper(this.cGraphWrapper, this.Transition);

            this.CopyTo(t);

            return t;
        }
    }
}
