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
    public class TransitionWrapper : WFVertexWrapper
    {
        Transition Transition { get { return Vertex as Transition; } set { Vertex = value; } }

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

        public TransitionWrapper(IGraphWrapper graphWrapper, Transition transition) : base(graphWrapper, transition) { }

        public override void Draw(Graphics g, Pen p)
        {
            Rectangle r = Rectangle;

            PointF[] ps =
                            MagicLibrary.Graphic.MGraphic.T(Center)
                            * MagicLibrary.Graphic.MGraphic.R(Angle)
                            * MagicLibrary.Graphic.MGraphic.T(-Center.X, -Center.Y)
                            * r;

            //g.FillRectangle(
            //                Brushes.White,
            //                r
            //             );
            //g.DrawRectangle(
            //                p,
            //                r
            //             );
            g.FillPolygon(new SolidBrush(p.Color),ps);
            //g.DrawLines(p, ps);
            //g.DrawLine(p, ps[3], ps[0]);

            g.DrawString(
                Name,
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
                m * new PointF(r.Right, r.Bottom)
            );
        }

        public void Draw(Graphics g, Pen p, double animationPercents)
        {
            Draw(g, p);
            if (animationPercents <= 50)
            {
                //Transition.GetEnters().ToList().ForEach(
            }
        }

        public override bool Hit(float x, float y)
        {
            return RectangleF.Inflate(RectangleF, 6, 6).Contains(x, y);
        }

        public override void EditVertex()
        {
            TransitionModifyForm vm = new TransitionModifyForm(this);
            vm.ShowDialog();
            if (vm.Succesful)
            {
                vm.VertexWrapper.CopyTo(this);// as MagicLibrary.MathUtils.Graphs.Vertex;
            }
        }

        public override void CopyTo(IVertexWrapper vertexWrapper)
        {
            base.CopyTo(vertexWrapper);
            TransitionWrapper wrapper = vertexWrapper as TransitionWrapper;
            wrapper.Angle = this.Angle;
        }

        public override object Clone()
        {
            TransitionWrapper t = new TransitionWrapper(this.graphWrapper, this.Transition);

            this.CopyTo(t);

            return t;
        }
    }
}
