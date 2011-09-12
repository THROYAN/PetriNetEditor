using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GraphEditor.App.Models;

using Petri_Net_Editor.App.Models.Wrappers;
using Petri_Net_Editor.App.Models;

using MagicLibrary.MathUtils.PetriNetsUtils.Graphs;

namespace Petri_Net_Editor.App.Views
{
    public partial class MarkedPlaceModifyForm : Form
    {
        public bool Succesful = false;
        public IVertexWrapper VertexWrapper { get; set; }
        public MarkedPlaceModifyForm(IVertexWrapper vertexWrapper)
        {
            this.VertexWrapper = vertexWrapper.Clone() as IVertexWrapper;

            InitializeComponent();
        }

        private void VertexModifyForm_Load(object sender, EventArgs e)
        {
            vertexNameTextBox.Text = VertexWrapper.Name;
            xTextBox.Text = (VertexWrapper as WFVertexWrapper).Coords.X.ToString();
            yTextBox.Text = (VertexWrapper as WFVertexWrapper).Coords.Y.ToString();
            tokensCounter.Value = (VertexWrapper.Vertex as MarkedPlace).TokenCount;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VertexWrapper.Name = vertexNameTextBox.Text;
            float x;
            float y;
            if (!float.TryParse(xTextBox.Text, out x))
            {
                x = (VertexWrapper as WFVertexWrapper).Coords.X;
            }
            if (!float.TryParse(yTextBox.Text, out y))
            {
                y = (VertexWrapper as WFVertexWrapper).Coords.Y;
            }

            (VertexWrapper as WFVertexWrapper).Coords = new PointF(x, y);
            (VertexWrapper.Vertex as MarkedPlace).TokenCount = Convert.ToInt32(tokensCounter.Value);
            Succesful = true;
            Close();
        }
    }
}
