using System.Collections.Generic;

namespace GraphLibary
{
    public interface IGraph<T,K>
    {
        //add a Vertex
        bool AddVertex(T vertex);

        //add to teh graph the vertices, if vertex already exists then it is skipped
        void AddVertex(IEnumerable<T> vertexSet);

        //Deletes the vertex specified in the graph, if existing - return true
        bool DeleteVertex(T vertex);

        //Deletes every vertex of the set
        void DeleteVertex(IEnumerable<T> vertexSet);

        //add Edge - add a new edge to the graph, starting from v1 and ending in v2, having weight w,
        //return true on success
        bool AddEdge(T v1, T v2, K weight);

        //Returns the weight of the edge starting from v1 and ending in v2
        K GetWeight(T v1, T v2);

        //Deletes the edge starting from v1 and ending in v2, if existing Returns true on success
        bool DeleteEdge(T v1, T v2);

        //Returns true if v1 is adjacent to v2
        bool AreAdjacent(T v1, T v2);

        //Computes the degree of the specified vertex
        int Degree(T vertex);

        //Computes the outgoing degree of the specified vertex
        int OutDegree(T vertex);

        //Computes the ingoing degree of the specified vertex
        int InDegree(T vertex);

        //Retirns the number of vertices in the graph
        int VerticesNumber();

        //Returns the number of edges in the graph
        int EdgesNumber();

        //Returns a set of adjacent vertices to the one specified as argument
        IEnumerable<T> AdjacentVertices(T vertex);

        //Returns an IEnumerable containing the vertex set of the graph
        IEnumerable<T> GetVertexSet();

        //Returns an IEnumerable containing the edge set of the graph,
        // represented by couples of vertices
        IEnumerable<IPairValue<T>> GetEdgeSet();
    }

    // interface to simple data struckture - contain a pair of vertices
    public interface IPairValue<T>
    {
        //Returns the first vertex
        T GetFirst();
        
        //Returns the second vertex
        T GetSecond();

        //Returns true if givin value is storedin the data structure
        bool Contains(T value);
    }
}
