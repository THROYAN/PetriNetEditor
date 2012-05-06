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

namespace Petri_Net_Editor.App.Views
{
    public partial class ColouredTransitionModifyForm : Form
    {
        public bool Succesful = false;
        public IVertexWrapper VertexWrapper { get; set; }
        public ColouredTransitionModifyForm(IVertexWrapper vertexWrapper)
        {
            this.VertexWrapper = vertexWrapper.Clone() as IVertexWrapper;

            InitializeComponent();
        }

        private void VertexModifyForm_Load(object sender, EventArgs e)
        {
            vertexNameTextBox.Text = VertexWrapper.Name;
            xTextBox.Text = (VertexWrapper as WFVertexWrapper).Coords.X.ToString();
            yTextBox.Text = (VertexWrapper as WFVertexWrapper).Coords.Y.ToString();
            angleUpDown.Value = Convert.ToDecimal(((VertexWrapper as ColouredTransitionWrapper).Angle % 360 + 360) % 360);
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
            (VertexWrapper as ColouredTransitionWrapper).Angle = Convert.ToDouble(angleUpDown.Value);

            Succesful = true;
            Close();
        }
    }
}
