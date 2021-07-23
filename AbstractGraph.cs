using System;
using System.Collections.Generic;

namespace GraphLibary
{
    //Abstract Graph - not directed
    public abstract class AbstractGraph<T, K> : IGraph<T, K>
    {
        protected readonly List<T> VertexSet = new List<T>();// list of the vertices
        protected readonly List<IPairValue<T>> EdgeSet = new List<IPairValue<T>>();// list of the edges
        //dictionary in order to associate for each edge a weight.
        //- keyset : PairValues ; Value - weight
        protected readonly Dictionary<IPairValue<T>, K> Weights = new Dictionary<IPairValue<T>, K>();

        //add Edge - add a new edge to the graph, starting from v1 and ending in v2, having weight w,
        //return true on success
        public abstract bool AddEdge(T v1, T v2, K weight);

        //add a Vertex
        public bool AddVertex(T vertex)
        {
            if (vertex == null)
                throw new ArgumentNullException();
            if (VertexSet.Contains(vertex))
                return false;
            VertexSet.Add(vertex);
            return true;
        }

        //add to teh graph the vertices, if vertex already exists then it is skipped
        public void AddVertex(IEnumerable<T> vertexSet)
        {
            if (vertexSet == null)
                throw new ArgumentNullException();
            using (var it = vertexSet.GetEnumerator())
            {
                while (it.MoveNext())
                {
                    if (it.Current != null && !VertexSet.Contains(it.Current))
                        VertexSet.Add(it.Current);
                }
            }
        }

        //Returns a set of adjacent vertices to the one specified as argument
        public abstract IEnumerable<T> AdjacentVertices(T vertex);

        //Returns true if v1 is adjacent to v2
        public abstract bool AreAdjacent(T v1, T v2);

        //Computes the degree of the specified vertex
        public abstract int Degree(T vertex);

        //Deletes the edge starting from v1 and ending in v2, if existing Returns true on success
        public abstract bool DeleteEdge(T v1, T v2);

        //Deletes the vertex specified in the graph, if existing - return true
        public bool DeleteVertex(T vertex)
        {
            if (vertex == null)
                throw new ArgumentNullException();
            if (!VertexSet.Contains(vertex))
                return false;
            VertexSet.Remove(vertex);
            return true;
        }

        //Deletes every vertex of the set
        public void DeleteVertex(IEnumerable<T> vertexSet)
        {
            if (vertexSet == null)
                throw new ArgumentNullException();
            using (var it = vertexSet.GetEnumerator())
            {
                while (it.MoveNext())
                    if (it.Current != null)
                        VertexSet.Remove(it.Current);
            }
        }

        //Returns the number of edges in the graph
        public int EdgesNumber()
        {
            return EdgeSet.Count;
        }

        //Returns an IEnumerable containing the edge set of the graph,
        // represented by couples of vertices
        public IEnumerable<IPairValue<T>> GetEdgeSet()
        {
            return EdgeSet;
        }

        //Returns an IEnumerable containing the vertex set of the graph
        public IEnumerable<T> GetVertexSet()
        {
            return VertexSet;
        }

        //Returns the weight of the edge starting from v1 and ending in v2
        public abstract K GetWeight(T v1, T v2);

        //Computes the ingoing degree of the specified vertex
        public abstract int InDegree(T vertex);

        //Computes the outgoing degree of the specified vertex
        public abstract int OutDegree(T vertex);

        //Retirns the number of vertices in the graph
        public int VerticesNumber()
        {
            return VertexSet.Count;
        }
    }
}
