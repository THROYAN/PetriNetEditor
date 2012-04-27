using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using MagicLibrary.MathUtils.PetriNetsUtils.Graphs;
using MagicLibrary.Graphic;

using GraphEditor.App.Models;
using Petri_Net_Editor.App.Views;

namespace Petri_Net_Editor.App.Models.Wrappers
{
    [Serializable]
    public class MarkedPlaceWrapper : PlaceWrapper
    {
        private MarkedPlace mPlace { get { return Vertex as MarkedPlace; } }

        public Size TokenSize { get; set; }

        public MarkedPlaceWrapper(IGraphWrapper graphWrapper, MarkedPlace markedPlace)
            : base(graphWrapper, markedPlace)
        {
            TokenSize = new Size(5, 5);
        }

        public override void Draw(Graphics g, Pen p, MagicLibrary.MathUtils.Matrix m)
        {
            base.Draw(g, p, m);

            #region Вывод фишек
            if (mPlace.TokensCount > 5)
            {
                g.DrawString(
                    mPlace.TokensCount.ToString(),
                    new Font("Arial", 8),
                    Brushes.Blue,
                    m * this.Center,
                    new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    }
                );
            }
            else
            {
                if (mPlace.TokensCount > 0)
                {
                    MGraphic.DrawFillEllipse(
                        g,
                        Brushes.Black,
                        Center.X - TokenSize.Width / 2,
                        Center.Y - TokenSize.Height / 2,
                        TokenSize.Width,
                        TokenSize.Height,
                        m
                    );

                    //g.FillEllipse(
                    //    Brushes.Black,
                    //    Center.X - TokenSize.Width / 2,
                    //    Center.Y - TokenSize.Height / 2,
                    //    TokenSize.Width,
                    //    TokenSize.Height
                    //);
                }
                if (mPlace.TokensCount > 1)
                {
                    MGraphic.DrawFillEllipse(
                        g,
                        Brushes.Black,
                        Rectangle.Left + Rectangle.Width * 2 / 3 - TokenSize.Width / 2,
                        Rectangle.Top + Rectangle.Height * 2 / 3 - TokenSize.Height / 2,
                        TokenSize.Width,
                        TokenSize.Height,
                        m
                    );
                }
                if (mPlace.TokensCount > 2)
                {
                    MGraphic.DrawFillEllipse(
                        g,
                        Brushes.Black,
                        Rectangle.Left + Rectangle.Width / 3 - TokenSize.Width / 2,
                        Rectangle.Top + Rectangle.Height / 3 - TokenSize.Height / 2,
                        TokenSize.Width,
                        TokenSize.Height,
                        m
                    );
                }
                if (mPlace.TokensCount > 3)
                {
                    MGraphic.DrawFillEllipse(
                        g,
                        Brushes.Black,
                        Rectangle.Left + Rectangle.Width / 3 - TokenSize.Width / 2,
                        Rectangle.Top + Rectangle.Height * 2 / 3 - TokenSize.Height / 2,
                        TokenSize.Width,
                        TokenSize.Height,
                        m
                    );
                }
                if (mPlace.TokensCount > 4)
                {
                    MGraphic.DrawFillEllipse(
                        g,
                        Brushes.Black,
                        Rectangle.Left + Rectangle.Width * 2 / 3 - TokenSize.Width / 2,
                        Rectangle.Top + Rectangle.Height / 3 - TokenSize.Height / 2,
                        TokenSize.Width,
                        TokenSize.Height,
                        m
                    );
                }
            }
            #endregion
        }

        public override void Draw(Graphics g, Pen p)
        {
            base.Draw(g, p);
            #region Вывод фишек
            if (mPlace.TokensCount > 5)
            {
                g.DrawString(
                    mPlace.TokensCount.ToString(),
                    new Font("Arial", 8),
                    Brushes.Blue,
                    Rectangle,
                    new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    }
                );
            }
            else
            {
                if (mPlace.TokensCount > 0)
                {
                    g.FillEllipse(
                        Brushes.Black,
                        Center.X - TokenSize.Width / 2,
                        Center.Y - TokenSize.Height / 2,
                        TokenSize.Width,
                        TokenSize.Height
                    );
                }
                if (mPlace.TokensCount > 1)
                {
                    g.FillEllipse(
                        Brushes.Black,
                        Rectangle.Left + Rectangle.Width * 2 / 3 - TokenSize.Width / 2,
                        Rectangle.Top + Rectangle.Height * 2 / 3 - TokenSize.Height / 2,
                        TokenSize.Width,
                        TokenSize.Height
                    );
                }
                if (mPlace.TokensCount > 2)
                {
                    g.FillEllipse(
                        Brushes.Black,
                        Rectangle.Left + Rectangle.Width / 3 - TokenSize.Width / 2,
                        Rectangle.Top + Rectangle.Height / 3 - TokenSize.Height / 2,
                        TokenSize.Width,
                        TokenSize.Height
                    );
                }
                if (mPlace.TokensCount > 3)
                {
                    g.FillEllipse(
                        Brushes.Black,
                        Rectangle.Left + Rectangle.Width / 3 - TokenSize.Width / 2,
                        Rectangle.Top + Rectangle.Height * 2 / 3 - TokenSize.Height / 2,
                        TokenSize.Width,
                        TokenSize.Height
                    );
                }
                if (mPlace.TokensCount > 4)
                {
                    g.FillEllipse(
                        Brushes.Black,
                        Rectangle.Left + Rectangle.Width * 2 / 3 - TokenSize.Width / 2,
                        Rectangle.Top + Rectangle.Height / 3 - TokenSize.Height / 2,
                        TokenSize.Width,
                        TokenSize.Height
                    );
                }
            }
            #endregion
        }

        public override void EditVertex()
        {
            MarkedPlaceModifyForm vm = new MarkedPlaceModifyForm(this);
            vm.ShowDialog();
            if (vm.Succesful)
            {
                vm.VertexWrapper.CopyTo(this);// as MagicLibrary.MathUtils.Graphs.Vertex;
            }
        }

        public override void CopyTo(IVertexWrapper vertexWrapper)
        {
            base.CopyTo(vertexWrapper);
            MarkedPlaceWrapper wrapper = vertexWrapper as MarkedPlaceWrapper;
            wrapper.TokenSize = this.TokenSize;
        }

        public override object Clone()
        {
            MarkedPlaceWrapper m = new MarkedPlaceWrapper(this.graphWrapper, this.mPlace);

            this.CopyTo(m);

            return m;
        }
    }
}
