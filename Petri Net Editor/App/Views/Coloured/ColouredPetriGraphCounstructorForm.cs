using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GraphEditor.App.Models;
using GraphEditor.App.Views;

using MagicLibrary.MathUtils.Graphs;
using MagicLibrary.MathUtils.PetriNetsUtils.Graphs;
using MagicLibrary.MathUtils.PetriNetsUtils;
using MagicLibrary.Exceptions;
using Petri_Net_Editor.App.Models.Wrappers;
using MagicLibrary.MathUtils.Functions;

namespace Petri_Net_Editor.App.Views
{
    public partial class ColouredPetriGraphConstructorForm : Form, IGraphConstructor
    {
        private bool _isModified = false;

        public bool Succesful { get; set; }
        public int height;
        public WFGraphWrapper GraphWrapper { get; set; }
        public ColouredPetriGraphWrapper wrapper { get { return this.GraphWrapper as ColouredPetriGraphWrapper; } }

        public ColouredPetriGraphConstructorForm(WFGraphWrapper graphWrapper)
        {
            InitializeComponent();
            this._isModified = false;
            this.Succesful = false;
            GraphWrapper = graphWrapper.Clone() as WFGraphWrapper;
            firstPartVerticesCounter.Value = (graphWrapper.Graph as BiGraph).FirstPartOrder;
            secondPartVerticesCount.Value = (graphWrapper.Graph as BiGraph).SecondPartOrder;
        }

        private void GraphConstructorForm_Resize(object sender, EventArgs e)
        {
            incidentsGrid.Height = this.Height - height;
        }

        private void GraphConstructorForm_Load(object sender, EventArgs e)
        {
            height = this.Height - incidentsGrid.Height;
            RefreshValues();
        }

        public void RefreshValues()
        {
            firstPartVerticesComboBox.Items.Clear();
            firstPartVerticesComboBox.Items.AddRange((GraphWrapper.Graph as BiGraph).FirstPartVerticesValues);
            firstPartVerticesComboBox.SelectedIndex = firstPartVerticesComboBox.Items.Count - 1;
            secondPartVerticesComboBox.Items.Clear();
            secondPartVerticesComboBox.Items.AddRange((GraphWrapper.Graph as BiGraph).SecondPartVerticesValues);
            secondPartVerticesComboBox.SelectedIndex = secondPartVerticesComboBox.Items.Count - 1;

            LoadDataToGrid(
                incidentsGrid,
                GraphWrapper.Graph.IncidentsMatrixTopHeaders,
                GraphWrapper.Graph.IncidentsMatrixLeftHeaders,
                GraphWrapper.Graph.IncidentsMatrix
            );
        }

        public void LoadDataToGrid(DataGridView grid, object[] topHeaders, object[] leftHeaders, MagicLibrary.MathUtils.Matrix values)
        {
            grid.Columns.Clear();
            grid.Rows.Clear();
            if (topHeaders.Length == 0 && leftHeaders.Length == 0)
                return;

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            grid.TopLeftHeaderCell.Value = "\\";
            grid.ShowEditingIcon = false;

            for (int i = 0; i < leftHeaders.Length; i++)
			{
                grid.Columns.Add("", leftHeaders[i].ToString());
                
                for (int j = 0; j < topHeaders.Length; j++)
                {
                    if(i == 0)
                        grid.Rows.Add(new DataGridViewRow() { 
                            HeaderCell = new DataGridViewRowHeaderCell() { 
                                Value = topHeaders[j]
                            } });
                    grid[i, j].Value = values[j, i].ToString();
                }
			}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (firstPartVerticesComboBox.SelectedIndex == -1)
                return;
            //VertexModifyForm vm = new VertexModifyForm(this.GraphWrapper[firstPartVerticesComboBox.SelectedItem.ToString()].Vertex);
            //vm.ShowDialog();
            //if (vm.Succesful)
            //{
            //    this.GraphWrapper[firstPartVerticesComboBox.SelectedItem.ToString()].Vertex = vm.VertexWrapper.Clone() as MagicLibrary.MathUtils.Graphs.Vertex;
            //    RefreshValues();
            //    //vm.Vertex.CopyTo(out this.GraphWrapper[verticesComboBox.SelectedIndex].Vertex);
            //}
            this._isModified = true;
            this.GraphWrapper[firstPartVerticesComboBox.SelectedItem.ToString()].EditVertex();
            this.RefreshValues();
        }

        private void GraphConstructorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this._isModified)
            {
                return;
            }

            DialogResult d = MessageBox.Show("Сохранить изменения?", "Внимание!", MessageBoxButtons.YesNoCancel);
            if (d == System.Windows.Forms.DialogResult.Cancel)
                e.Cancel = true;
            Succesful = d == System.Windows.Forms.DialogResult.Yes;
        }

        private void incidentsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            List<PointF> points = new List<PointF>();

            double res = 0;

            Double.TryParse(incidentsGrid[e.ColumnIndex, e.RowIndex].Value.ToString(), out res);

            incidentsGrid[e.ColumnIndex, e.RowIndex].Value = res;

            string tailName = incidentsGrid.Rows[e.RowIndex].HeaderCell.Value.ToString();
            string headName = incidentsGrid.Columns[e.ColumnIndex].HeaderText;

            if (tailName == headName)
            {
                Random r = new Random();
                PointF p = (GraphWrapper[tailName] as WFVertexWrapper).Center;
                PointF[] ps = new PointF[]{
                    MagicLibrary.Graphic.MGraphic.T(0, GraphWrapper.DefaultVertexSize.Height * 2) * p,
                    MagicLibrary.Graphic.MGraphic.T(GraphWrapper.DefaultVertexSize.Width * 2, 0) * p,
                    MagicLibrary.Graphic.MGraphic.T(0, GraphWrapper.DefaultVertexSize.Height * -2) * p,
                };
                points.AddRange(
                    MagicLibrary.Graphic.MGraphic.T(p) * 
                    MagicLibrary.Graphic.MGraphic.R(r.Next(360)) *
                    MagicLibrary.Graphic.MGraphic.T(-p.X, -p.Y) * 
                    ps);
            }

            if (GraphWrapper[tailName, headName] == null)
            {
                if(res != 0)
                    GraphWrapper.AddArc(tailName, headName, res, points.ToArray());
            }
            else
            {
                GraphWrapper[tailName, headName].Weight = res;
            }
            res = GraphWrapper[tailName, headName] == null ? 0 : GraphWrapper[tailName, headName].Weight;
            incidentsGrid[e.ColumnIndex, e.RowIndex].Value = res;
            this._isModified = true;
        }

        private void fitstPartVerticesCounter_ValueChanged(object sender, EventArgs e)
        {
            this._isModified = true;
            BiGraph graph = this.GraphWrapper.Graph as BiGraph;
            int newVerticesCount = Convert.ToInt32((sender as NumericUpDown).Value);
            int oldVerticesCount = graph.FirstPartOrder;
            if (oldVerticesCount < newVerticesCount)
            {
                Random r = new Random();
                for (int i = oldVerticesCount; i < newVerticesCount; i++)
                {
                    PointF p = new PointF(r.Next(500), r.Next(500));
                    while (GraphWrapper.VertexWrappers.Any(
                            v =>
                                (v as WFVertexWrapper).RectangleF.IntersectsWith(
                                    new RectangleF(p, GraphWrapper.DefaultVertexSize)
                                )))
                    {
                        p.X += 10;
                        if (p.X >= 500)
                        {
                            p.Y += 10;
                            p.X = 0;
                        }
                    }
                    int c = graph.FirstPartOrder;
                    graph.AddVertexToFirstPart("P" + (c + 1));
                    this.GraphWrapper["P" + (c + 1)].Center = MagicLibrary.Graphic.MGraphic.T(GraphWrapper.DefaultVertexSize.Width, GraphWrapper.DefaultVertexSize.Height) * p;
                    //GraphWrapper.AddVertex(MagicLibrary.Graphic.MGraphic.T(GraphWrapper.DefaultVertexSize.Width, GraphWrapper.DefaultVertexSize.Height) * p);
                }
            }
            if (oldVerticesCount > newVerticesCount)
            {
                for (int i = newVerticesCount; i < oldVerticesCount; i++)
                {
                    GraphWrapper.Graph.RemoveVertex(graph.FirstPartVerticesValues.Last());
                }
            }
            RefreshValues();
        }

        private void secondPardVerticesCount_ValueChanged(object sender, EventArgs e)
        {
            this._isModified = true;
            BiGraph graph = this.GraphWrapper.Graph as BiGraph;
            int newVerticesCount = Convert.ToInt32((sender as NumericUpDown).Value);
            int oldVerticesCount = graph.SecondPartOrder;
            if (oldVerticesCount < newVerticesCount)
            {
                Random r = new Random();
                for (int i = oldVerticesCount; i < newVerticesCount; i++)
                {
                    PointF p = new PointF(r.Next(500), r.Next(500));
                    while (GraphWrapper.VertexWrappers.Any(
                            v =>
                                (v as WFVertexWrapper).RectangleF.IntersectsWith(
                                    new RectangleF(p, GraphWrapper.DefaultVertexSize)
                                )))
                    {
                        p.X += 10;
                        if (p.X >= 500)
                        {
                            p.Y += 10;
                            p.X = 0;
                        }
                    }
                    int c = graph.SecondPartOrder;
                    graph.AddVertexToSecondPart("T" + (c + 1));
                    this.GraphWrapper["T" + (c + 1)].Center = MagicLibrary.Graphic.MGraphic.T(GraphWrapper.DefaultVertexSize.Width, GraphWrapper.DefaultVertexSize.Height) * p;
                }
            }
            if (oldVerticesCount > newVerticesCount)
            {
                for (int i = newVerticesCount; i < oldVerticesCount; i++)
                {
                    GraphWrapper.Graph.RemoveVertex(graph.SecondPartVerticesValues.Last());
                }
            }
            RefreshValues();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (secondPartVerticesComboBox.SelectedIndex == -1)
                return;

            this.GraphWrapper[secondPartVerticesComboBox.SelectedItem.ToString()].EditVertex();
            this.RefreshValues();
        }

        private void colorsEditButton_Click(object sender, EventArgs e)
        {
            var f = new ColorsEditForm(this.wrapper.ColorsDescription, this.wrapper.VariablesDescription, this.wrapper.FunctionsDescription);
            f.ShowDialog();

            if (f.Succesful)
            {
                this._isModified = true;
                this.wrapper.ColorsDescription = new List<Tuple<string, string, string>>(f.ColorsDescriptions);
                this.wrapper.VariablesDescription = new List<Tuple<string, string>>(f.VarsDescriptions);
                this.wrapper.FunctionsDescription = new List<string>(f.FunctionsDescriptions);
                var cGraph = this.wrapper.Graph as ColouredPetriGraph;
                cGraph.Colors.ClearColors();
                cGraph.Colors.ClearFunctions();
                Function.ResetMathFunctions();
                
                foreach (var color in f.Colors)
                {
                    cGraph.Colors.AddColorSet(color);
                }

                foreach (var var in f.Colors.ColorVariables)
                {
                    cGraph.Colors.AddVariable(var.Name, var.ColorSet.Name);
                }

                foreach (var func in f.Colors.FunctionsDescription)
                {
                    cGraph.Colors.AddFunction(func);
                }
            }
        }
    }
}
