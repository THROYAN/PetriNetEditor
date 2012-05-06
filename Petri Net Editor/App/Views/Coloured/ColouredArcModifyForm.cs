using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GraphEditor.App.Models;
using MagicLibrary.MathUtils.Graphs;

using Petri_Net_Editor.App.Models.Wrappers;
using MagicLibrary.MathUtils.Functions;

namespace Petri_Net_Editor.App.Views
{
    public partial class ColouredArcModifyForm : Form
    {
        public bool Succesful = false;
        public ColouredArcWrapper ArcWrapper { get; set; }

        public ColouredArcModifyForm(ColouredArcWrapper arcWrapper)
        {
            InitializeComponent();
            this.ArcWrapper = arcWrapper.Clone() as ColouredArcWrapper;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ArcWrapper.Head = this.ArcWrapper.graphWrapper.VertexWrappers.Find(v => v.Vertex.Value.Equals(this.headComboBox.SelectedItem));
            this.ArcWrapper.Tail = this.ArcWrapper.graphWrapper.VertexWrappers.Find(v => v.Vertex.Value.Equals(this.tailComboBox.SelectedItem));

            this.ArcWrapper.Arc.Name = this.funcTextBox.Text;

            this.Succesful = this.ArcWrapper.Head.GetType() != this.ArcWrapper.Tail.GetType();
            Close();
        }

        private void ArcModifyForm_Load(object sender, EventArgs e)
        {
            this.headComboBox.Items.Clear();
            this.tailComboBox.Items.Clear();

            this.headComboBox.Items.AddRange(this.ArcWrapper.graphWrapper.Graph.GetVertices().Select(v => v.Value).ToArray());
            this.tailComboBox.Items.AddRange(this.ArcWrapper.graphWrapper.Graph.GetVertices().Select(v => v.Value).ToArray());

            this.headComboBox.SelectedItem = this.ArcWrapper.Head.Vertex.Value;
            this.tailComboBox.SelectedItem = this.ArcWrapper.Tail.Vertex.Value;

            this.funcTextBox.Text = this.ArcWrapper.Arc.Name;
        }

        private void funcTextBox_TextChanged(object sender, EventArgs e)
        {
            Function f = new Function();
            if (!Function.TryParse(this.funcTextBox.Text, out f))
            {
                this.errorLabel.Text = "Ошибка в описании функции";
            }
            else
            {
                this.errorLabel.Text = "";
            }
        }
    }
}
