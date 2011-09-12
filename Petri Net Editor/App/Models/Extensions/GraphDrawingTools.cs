//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Drawing;

//using Petri_Net_Editor.App.Models;
//using GraphEditor.App.Models;
//using MagicLibrary.MathUtils;
//using MagicLibrary.Graphic;

//namespace Petri_Net_Editor.App.Extensions
//{
//    public static class GraphDrawingTools
//    {
//        public static void DrawMarkedPlace(this Graphics g, Pen p, MarkedPlace v)
//        {
//            g.DrawVertex(p,v);

//            #region Вывод фишек
//            if (v.TokenCount > 5)
//            {
//                g.DrawString(
//                    v.TokenCount.ToString(),
//                    new Font("Arial", 8),
//                    Brushes.Blue,
//                    v.Rectangle,
//                    new StringFormat()
//                    {
//                        Alignment = StringAlignment.Center,
//                        LineAlignment = StringAlignment.Center
//                    }
//                );
//            }
//            else
//            {
//                if (v.TokenCount > 0)
//                {
//                    g.FillEllipse(
//                        Brushes.Black,
//                        v.Center.X - v.TokenSize.Width / 2,
//                        v.Center.Y - v.TokenSize.Height / 2,
//                        v.TokenSize.Width,
//                        v.TokenSize.Height
//                    );
//                }
//                if (v.TokenCount > 1)
//                {
//                    g.FillEllipse(
//                        Brushes.Black,
//                        v.Rectangle.Left + v.Rectangle.Width * 2 / 3 - v.TokenSize.Width / 2,
//                        v.Rectangle.Top + v.Rectangle.Height * 2 / 3 - v.TokenSize.Height / 2,
//                        v.TokenSize.Width,
//                        v.TokenSize.Height
//                    );
//                }
//                if (v.TokenCount > 2)
//                {
//                    g.FillEllipse(
//                        Brushes.Black,
//                        v.Rectangle.Left + v.Rectangle.Width / 3 - v.TokenSize.Width / 2,
//                        v.Rectangle.Top + v.Rectangle.Height / 3 - v.TokenSize.Height / 2,
//                        v.TokenSize.Width,
//                        v.TokenSize.Height
//                    );
//                }
//                if (v.TokenCount > 3)
//                {
//                    g.FillEllipse(
//                        Brushes.Black,
//                        v.Rectangle.Left + v.Rectangle.Width / 3 - v.TokenSize.Width / 2,
//                        v.Rectangle.Top + v.Rectangle.Height * 2 / 3 - v.TokenSize.Height / 2,
//                        v.TokenSize.Width,
//                        v.TokenSize.Height
//                    );
//                }
//                if (v.TokenCount > 4)
//                {
//                    g.FillEllipse(
//                        Brushes.Black,
//                        v.Rectangle.Left + v.Rectangle.Width * 2 / 3 - v.TokenSize.Width / 2,
//                        v.Rectangle.Top + v.Rectangle.Height / 3 - v.TokenSize.Height / 2,
//                        v.TokenSize.Width,
//                        v.TokenSize.Height
//                    );
//                }
//            }
//            #endregion
//        }

//        public static void DrawTransition(this Graphics g, Pen p, Transition t)
//        {
//            g.FillRectangle(
//                            Brushes.White,
//                            t.Rectangle
//                         );
//            g.DrawRectangle(
//                            p,
//                            t.Rectangle
//                         );
//            g.DrawString(t.Name, new Font("Arial", 8), Brushes.Blue, t.Center.X, t.Rectangle.Bottom);
//        }

//        public static void DrawGraph(this Graphics g, Pen p, PetriNetGraph graph)
//        {
//            graph.GetEdges(e => true).ForEach(edge => g.DrawArc(p, edge as WFArc));
//            graph.GetVertices(v => true).ForEach(vertex => g.DrawVertex(p, vertex as WFVertex));
//        }
//    }
//}
