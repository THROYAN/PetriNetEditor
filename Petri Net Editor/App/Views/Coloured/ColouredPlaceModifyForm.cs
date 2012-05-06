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
    public partial class ColouredPlaceModifyForm : Form
    {
        public int ValidatedItems = 5;
        public bool Succesful = false;
        private string startName;
        public IVertexWrapper VertexWrapper { get; set; }
        private ColouredPlace place { get { return this.VertexWrapper.Vertex as ColouredPlace; } }

        public ColouredPlaceModifyForm(IVertexWrapper vertexWrapper)
        {
            this.VertexWrapper = vertexWrapper.Clone() as IVertexWrapper;
            this.startName = VertexWrapper.Name;

            InitializeComponent();
        }

        private void VertexModifyForm_Load(object sender, EventArgs e)
        {
            vertexNameTextBox.Text = VertexWrapper.Name;
            xTextBox.Text = (VertexWrapper as WFVertexWrapper).Coords.X.ToString();
            yTextBox.Text = (VertexWrapper as WFVertexWrapper).Coords.Y.ToString();
            placeColorTextBox.Text = this.place.ColorSetName;
            placeInitFunctionTextBox.Text = this.place.InitFunction;
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
            this.place.ColorSetName = this.placeColorTextBox.Text;
            this.place.InitFunction = this.placeInitFunctionTextBox.Text;

            Succesful = true;
            Close();
        }

        private void vertexNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!this.startName.Equals(vertexNameTextBox.Text)
                && VertexWrapper.graphWrapper.Graph[vertexNameTextBox.Text] != null)
            {
                vertexNameTextBox.BackColor = Color.Red;
            }
            else
            {
                vertexNameTextBox.BackColor = SystemColors.Window;
            }
        }

        private void placeColorTextBox_TextChanged(object sender, EventArgs e)
        {
            this.place.ColorSetName = placeColorTextBox.Text;
            if (!this.place.IsLegalColor())
            {
                placeColorTextBox.BackColor = Color.Red;
            }
            else
            {
                placeColorTextBox.BackColor = SystemColors.Window;
            }
        }
   } 
}
