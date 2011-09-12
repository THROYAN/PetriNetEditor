using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Petri_Net_Editor.App.Models
{
    public class Graph : BaseGraph
    {
        private static int vertexesCount = 0;
        protected List<Vertex> GraphVertexes
        {
            get { return Vertexes.OfType<Vertex>().ToList(); }
        }
        protected List<Edge> GraphEdges
        {
            get { return Edges.OfType<Edge>().ToList(); }
        }

        public new Vertex this[int vertexIndex]
        {
            get
            {
                return GraphVertexes[vertexIndex];
            }
            set
            {
                base[vertexIndex] = value;
            }
        }

        public Graph() : base()
        {
            OnEdgeAdded += Graph_OnEdgeAdded;
        }

        void Graph_OnEdgeAdded(object sender, EventArgs e)
        {
            //if(e.
        }

        public virtual void Draw(Graphics g,Pen p)
        {
            GraphEdges.ForEach(edge => edge.Draw(g, p));
            GraphVertexes.ForEach(vertex => vertex.Draw(g, p));
        }
        
        public Graph AddVertex(Point coords)
        {
            AddVertex(
                new Vertex("P" + (vertexesCount + 1).ToString())
                        {Position = coords}
            );
            vertexesCount++;
            return this;
        }

        public Graph AddEdge(Vertex vIn, Vertex vOut, double weight, PointF[] points)
        {
            AddEdge(
                new Edge(vIn, vOut, weight) { Points = points.ToList() }
                );
            return this;
        }

        public Graph AddEdge(int vInIndex, int vOutIndex, double weight, PointF[] points)
        {
            AddEdge(
                new Edge(this[vInIndex], this[vOutIndex], weight) { Points = points.ToList() }
                );
            return this;
        }

        #region ГАВНО

        //public Graph()
        //{
        //    _vertexes = new List<Vertex>();
        //    _edges = new List<Edge>();
        //}

        //public double this[int vIn ,int vOut]
        //{
        //    get
        //    {
        //        Edge e = GetEdge(_vertexes[vIn], _vertexes[vOut]);
        //        if (e != null)
        //            return e.Weight;
        //        else
        //            return 0;
        //    }
        //    set
        //    {
        //        _edges.Add(new Edge(_vertexes[vIn], _vertexes[vOut], value));
        //    }
        //}

        //public int VertexCount
        //{
        //    get
        //    {
        //        return _vertexes.Count;
        //    }
        //}

        //public string this[int vI]
        //{
        //    get
        //    {
        //        return _vertexes[vI].Name;
        //    }
        //    set
        //    {
        //        _vertexes[vI].Name = value;
        //    }
        //}

        //public Graph AddVertex(Vertex v)
        //{
        //    _vertexes.Add(v);
        //    return this;
        //}

        //public Graph AddVertex(string VertexName)
        //{
        //    _vertexes.Add(new Vertex(VertexName));
        //    return this;
        //}

        //public Graph RemoveVertex(Vertex v)
        //{
        //    _vertexes.Remove(v);
        //    return this;
        //}

        //public bool ExistsVertex(Vertex v)
        //{
        //    return _vertexes.Exists(delegate(Vertex vert) { return v == vert; });
        //}

        //public Graph AddEdge(Edge e)
        //{
        //    if (ExistsVertex(e.VIn) && ExistsVertex(e.vOut))
        //    _edges.Add(e);
        //    return this;
        //}

        //public Graph AddEdge(Vertex vIn,Vertex vOut,double Weight)
        //{
        //    if(ExistsVertex(vIn) && ExistsVertex(vOut))
        //        _edges.Add(new Edge(vIn,vOut,Weight));
        //    return this;
        //}

        //public Graph AddEdge(string vInName, string vOutName, double Weight)
        //{
        //    Vertex vIn = new Vertex(vInName);
        //    Vertex vOut = new Vertex(vOutName);
        //    if (ExistsVertex(vIn) && ExistsVertex(vOut))
        //        _edges.Add(new Edge(vIn, vOut, Weight));
        //    return this;
        //}

        //public Graph RemoveEdge(Edge e)
        //{
        //    _edges.Remove(e);
        //    return this;
        //}

        //public Edge GetNotOrientedEdge(Vertex v1, Vertex v2)
        //{
        //    return _edges.Find(delegate(Edge e) { return (e.vIn == v1 && e.vOut == v2) || (e.vIn == v2 && e.vOut == v1); }); 
        //}

        //public Edge GetEdge(Vertex v1, Vertex v2)
        //{
        //    return _edges.Find(delegate(Edge e) { return (e.vIn == v1 && e.vOut == v2); });
        //}

        #endregion

    }
}
