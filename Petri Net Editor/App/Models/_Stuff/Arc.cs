using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using MagicLibrary.Graphic;
using MagicLibrary.MathUtils;

namespace Petri_Net_Editor.App.Models
{
    public class Arc : Edge
    {
        ///// <summary>
        ///// Точки, чтобы эта арка могла быть поломанной
        ///// </summary>
        //private List<PointF> Points;

        ///// <summary>
        ///// Вес линии
        ///// </summary>
        //private double _weight;

        ///// <summary>
        ///// Откуда и куда
        ///// </summary>
        //private Place _fromVertex, _toVertex;

        ///// <summary>
        ///// Как кстати семья?
        ///// </summary>
        //public Place fromVertex
        //{
        //    get
        //    {
        //        return FromVertex as Place;
        //    }
        //    set
        //    {
        //        FromVertex = value;
        //    }
        //}

        ///// <summary>
        ///// Не лень читать?
        ///// Оно же впринцыпи не нада...так глазами пробежался
        ///// и все понял...
        ///// </summary>
        //public Place toVertex
        //{
        //    get
        //    {
        //        return ToVertex as Place;
        //    }
        //    set
        //    {
        //        ToVertex = value;
        //    }
        //}

        ///// <summary>
        ///// Впринцыпи зная англ язык и кусочки программирования можно понять
        ///// и - Да! - писать мне это реально лень, но я просто хочу спать, а писать что-то надо
        ///// вы же все хотите, чтобы я писал комменты, вот получайте!
        ///// довольно информативные
        ///// это, например, свойство, которое возвращает или устанавливает вес ребра
        ///// </summary>
        //public double Weight
        //{
        //    get
        //    {
        //        return _weight;
        //    }
        //    set
        //    {
        //        _weight = value;
        //    }
        //}

        /// <summary>
        /// Кондуктор!
        /// </summary>
        /// <param name="fromVertex"></param>
        /// <param name="toVertex"></param>
        /// <param name="weight"></param>
        public Arc(Vertex from, Vertex to, double weight) : base(from, to, weight) { }

        /// <summary>
        /// Помошник кондуктора!
        /// </summary>
        /// <param name="fromVertex"></param>
        /// <param name="toVertex"></param>
        /// <param name="weight"></param>
        ///// <param name="Points"></param>
        //public Arc(Transition from,Place to, double weight) : base(from, to, weight) { }
        ///*
        // *   Третий коструктор.
        // *   Открытие 30.02.2012
        // */

        /// <summary>
        /// Нарисуй!
        /// Приказываю!
        /// </summary>
        /// <param name="g">На что нарисовать</param>
        //public override void Draw(Graphics g, Pen p)
        //{
        //    PointF[] arrow = new PointF[3] {
        //                                        new PointF(-10,-5),
        //                                        new PointF(0,0),
        //                                        new PointF(-10,5)
        //                                    };

        //    double angle;
        //    Matrix dM;
        //    if (Points != null && Points.Count > 0)
        //    {
        //        angle = -Math.Atan2(fromVertex.Position.Y - Points[0].Y, Points[0].X - fromVertex.Position.X);
        //        PointF popravka = new PointF((float)Math.Cos(angle) * PetriGraph.PlaceSize.Width / 2,
        //                             (float)Math.Sin(angle) * PetriGraph.PlaceSize.Height / 2);
        //        g.DrawLine(p, MGraphic.T(popravka.X, popravka.Y) * fromVertex.Position, Points[0]);
        //        for (int i = 0; i < Points.Count - 1; i++)
        //            g.DrawLine(p, Points[i], Points[i + 1]);
        //        try
        //        {
        //            angle = -Math.Atan2(Points[Points.Count - 1].Y - toVertex.Position.Y, toVertex.Position.X - Points[Points.Count - 1].X);
        //            popravka = new PointF((float)Math.Cos(angle) * PetriGraph.PlaceSize.Width / 2,
        //                             (float)Math.Sin(angle) * PetriGraph.PlaceSize.Height / 2);
        //            g.DrawLine(p, Points[Points.Count - 1], MGraphic.T(-popravka.X, -popravka.Y) * toVertex.Position);
        //            dM =
        //                   MGraphic.T(toVertex.Position.X - popravka.X, toVertex.Position.Y - popravka.Y)
        //                 * MGraphic.R(angle * 180 / Math.PI)
        //            ;
        //            g.DrawLines(p, dM * arrow);
        //        }
        //        catch { }
        //    }
        //    else
        //    {
        //        angle = -Math.Atan2(fromVertex.Position.Y - toVertex.Position.Y, toVertex.Position.X - fromVertex.Position.X);
        //        PointF popravka = new PointF((float)Math.Cos(angle) * PetriGraph.PlaceSize.Width / 2,
        //                                 (float)Math.Sin(angle) * PetriGraph.PlaceSize.Height / 2);
        //        g.DrawLine(p, MGraphic.T(popravka.X, popravka.Y) * fromVertex.Position, MGraphic.T(-popravka.X, -popravka.Y) * toVertex.Position);
        //        dM =
        //                   MGraphic.T(toVertex.Position.X - popravka.X, toVertex.Position.Y - popravka.Y)
        //                 * MGraphic.R(angle * 180 / Math.PI)
        //         ;
        //        g.DrawLines(p, dM * arrow);
        //    }
             
            
        //}

        /*
         *   Приползайте еще
         */
    }
}
