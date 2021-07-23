using System;
using System.Collections.Generic;

namespace GraphLibary
{
    //DIracted grapg - extands abstract graph
    public class DirectedGraph<T, K> : AbstractGraph<T, K>
    {
        //add Edge - add a new edge to the graph, starting from v1 and ending in v2, having weight w,
        //return true on success
        public override bool AddEdge(T v1, T v2, K weight)
        {
            if (v1 == null || v2 == null || weight == null)
                throw new ArgumentNullException();
            if (!VertexSet.Contains(v1) || !VertexSet.Contains(v2))
                return false;
            IPairValue<T> pair = new PairValueImplementation<T>(v1, v2);
            if (EdgeSet.Contains(pair))
                return false;
            EdgeSet.Add(pair);
            Weights[pair] = weight;
            return true;
        }

        //Returns a set of adjacent vertices to the one specified as argument
        public override IEnumerable<T> AdjacentVertices(T vertex)
        {
            foreach (IPairValue<T> p in EdgeSet)
                if (p.GetFirst().Equals(vertex))
                    yield return p.GetSecond();
        }

        //Returns true if v1 is adjacent to v2
        public override bool AreAdjacent(T v1, T v2)
        {
            if (v1 == null || v2 == null)
                throw new ArgumentNullException();
            if (!VertexSet.Contains(v1) || !VertexSet.Contains(v2))
                throw new ArgumentException();
            return EdgeSet.Contains(new PairValueImplementation<T>(v1, v2));
        }

        //Computes the degree of the specified vertex
        public override int Degree(T vertex)
        {
            if (vertex == null)
                throw new ArgumentNullException();
            if (!VertexSet.Contains(vertex))
                throw new ArgumentException();
            return InDegree(vertex) + OutDegree(vertex);
        }

        //Deletes the edge starting from v1 and ending in v2, if existing Returns true on success
        public override bool DeleteEdge(T v1, T v2)
        {
            if (v1 == null || v2 == null)
                throw new ArgumentNullException();
            IPairValue<T> pair = new PairValueImplementation<T>(v1, v2);
            if(EdgeSet.Contains(pair))
            {
                EdgeSet.Remove(pair);
                Weights.Remove(pair);
                return true;
            }
            return false;
        }

        //Returns the weight of the edge starting from v1 and ending in v2
        public override K GetWeight(T v1, T v2)
        {
            if (v1 == null || v2 == null)
                throw new ArgumentNullException();
            IPairValue<T> pair = new PairValueImplementation<T>(v1, v2);
            if (!Weights.ContainsKey(pair))
                throw new ArgumentException();
            return Weights[pair];
        }

        //Computes the ingoing degree of the specified vertex
        public override int InDegree(T vertex)
        {
            if (vertex == null)
                throw new ArgumentNullException();
            if (!VertexSet.Contains(vertex))
                throw new ArgumentException();
            int counter = 0;
            foreach (var pair in EdgeSet)
                if (pair.GetSecond().Equals(vertex))
                    counter++;
            return counter;
        }

        //Computes the outgoing degree of the specified vertex
        public override int OutDegree(T vertex)
        {
            if (vertex == null)
                throw new ArgumentNullException();
            if (!VertexSet.Contains(vertex))
                throw new ArgumentException();
            int counter = 0;
            foreach (var pair in EdgeSet)
                if (pair.GetFirst().Equals(vertex))
                    counter++;
            return counter;
        }
    }
}
