using System;
using System.Collections.Generic;
public interface IGraph
{
    int V { get; }
    int E { get; }
    bool RemoveEdge(int u, int v);
    bool ContainsEdge(int u, int v);
    IEnumerable<int> GetAdjacent(int vertex);
}

public interface IGraph<TEdge> : IGraph
{
    bool AddOrUpdateEdge(int u, int v, TEdge edge);
    TEdge GetEdge(int u, int v);
}

public class Graph<TEdge> : IGraph<TEdge> 
{
    private readonly int _n;
    private readonly int _v;
    private readonly TEdge[][] _adj;
    private int _edgeCount;

    public Graph(int V){
        _v = V;
        _adj = new TEdge[V][];
        for(int i = 0; i < V; i++){
            _adj[i] = new TEdge[V];
        }
    }

    public int V => _v;
    public int E => _edgeCount;

    public virtual bool AddOrUpdateEdge(int u, int v, TEdge edge){
        bool contained = ContainsEdge(u,v);
        _adj[u][v] = edge;
        if(contained)
        {
            _edgeCount++;
            return false;
        }
        return true;
    }
    
    public virtual bool RemoveEdge(int u, int v){
        if(ContainsEdge(u,v)){
            _edgeCount--;
            _adj[u][v] = default;
            return true;
        }
        return false;
    }

    public TEdge GetEdge(int u, int v){
        return _adj[u][v];
    }
    
    public bool ContainsEdge(int u, int v){
        return !Equals(_adj[u][v], (default(TEdge)));
    }
    
    public IEnumerable<int> GetAdjacent(int u){
        for(int i = 0; i < V; i++){
            if(ContainsEdge(u,i)){
                yield return i;
            }
        }
    }
}