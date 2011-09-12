using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using MagicLibrary.MathUtils;
using MagicLibrary.Graphic;

namespace Petri_Net_Editor.App.Models
{
    public class Edge : BaseEdge
    {
        public Size Size { get; set; }

        public Vertex fromVertex { get { return (Vertex)FromVertex; } }
        public Vertex toVertex { get { return (Vertex)ToVertex; } }

        public Edge(IVertex fromVertex, IVertex toVertex, double weight) : base(fromVertex, toVertex, weight) { }

        public List<PointF> Points { get; set; }

        public virtual void Draw(Graphics g, Pen p)
        {
            PointF[] arrow = new PointF[3] {
                                                new PointF(-10,-5),
                                                new PointF(0,0),
                                                new PointF(-10,5)
                                            };
            double angle;
            Matrix dM;
            if (Points != null && Points.Count > 0)
            {
                angle = -Math.Atan2(fromVertex.Position.Y - Points[0].Y, Points[0].X - fromVertex.Position.X);
                PointF popravka = new PointF((float)Math.Cos(angle) * fromVertex.Size.Width / 2,
                                     (float)Math.Sin(angle) * fromVertex.Size.Height / 2);
                g.DrawLine(p, MGraphic.T(popravka.X, popravka.Y) * fromVertex.Position, Points[0]);
                for (int i = 0; i < Points.Count - 1; i++)
                    g.DrawLine(p, Points[i], Points[i + 1]);
                try
                {
                    angle = -Math.Atan2(Points[Points.Count - 1].Y - toVertex.Position.Y, toVertex.Position.X - Points[Points.Count - 1].X);
                    popravka = new PointF((float)Math.Cos(angle) * toVertex.Size.Width / 2,
                                     (float)Math.Sin(angle) * toVertex.Size.Height / 2);
                    g.DrawLine(p, Points[Points.Count - 1], MGraphic.T(-popravka.X, -popravka.Y) * toVertex.Position);
                    dM =
                           MGraphic.T(toVertex.Position.X - popravka.X, toVertex.Position.Y - popravka.Y)
                         * MGraphic.R(angle * 180 / Math.PI)
                    ;
                    g.DrawLines(p, dM * arrow);
                }
                catch { }
            }
            else
            {
                angle = -Math.Atan2(fromVertex.Position.Y - toVertex.Position.Y, toVertex.Position.X - fromVertex.Position.X);
                PointF popravka = new PointF((float)Math.Cos(angle) * toVertex.Size.Width / 2,
                                         (float)Math.Sin(angle) * toVertex.Size.Height / 2);
                g.DrawLine(p, MGraphic.T(popravka.X, popravka.Y) * fromVertex.Position, MGraphic.T(-popravka.X, -popravka.Y) * toVertex.Position);
                dM =
                           MGraphic.T(toVertex.Position.X - popravka.X, toVertex.Position.Y - popravka.Y)
                         * MGraphic.R(angle * 180 / Math.PI)
                 ;
                g.DrawLines(p, dM * arrow);
            }
        }
    }
}
