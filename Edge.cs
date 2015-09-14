using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlSharpGame
{
 public class Edge : IComparable<Edge> 
{ 
    private readonly int _v; 
    private readonly int _w; 
    private readonly double _weight; 

    public Edge(int v, int w, double weight) {
        this._v = v;
        this._w = w;
        this._weight = weight;
    }

    public double Weight() {
        return _weight;
    }

  
    public int CompareTo(Edge that) {
        if      (this.Weight() < that.Weight()) return -1;
        else if (this.Weight() > that.Weight()) return +1;
        else                                    return  0;
    }


    public int Source() {
        return _v;
    }

    public int Dest()
    {
        return _w;
    }

    public int Target(int vertex) {
        if      (vertex == _v) return _w;
        else if (vertex == _w) return _v;
        else throw new Exception("Illegal endpoint");
    }

    public String toString()
    {
        return String.Format("{0:d}-{1:d} {2:f5}", _v, _w, _weight);
    }
}
 public class EdgeWeightedGraph
 {
     private readonly int _v; 
     private int _e; 
     private LinkedList<Edge>[] _adj;

     public EdgeWeightedGraph(int V)
     {
         if (V < 0) throw new Exception("Number of vertices in a Graph must be nonnegative");
         this._v = V;
         this._e = 0;
         _adj = new LinkedList<Edge>[V];
         for (int v = 0; v < V; v++)
         {
             _adj[v] = new LinkedList<Edge>();
         }
     }

     public int V()
     {
         return _v;
     }

     public int E()
     {
         return _e;
     }

     public void AddEdge(Edge e)
     {
         int v = e.Source();
         int w = e.Target(v);
         _adj[v].AddFirst(e);
         _adj[w].AddFirst(e);
         _e++;
     }

   
     public IEnumerable<Edge> Adj(int v)
     {
         return _adj[v];
     }

  
     public IEnumerable<Edge> Edges()
     {
         LinkedList<Edge> list = new LinkedList<Edge>();
         for (int v = 0; v < _v; v++)
         {
             int selfLoops = 0;
             foreach (Edge e in Adj(v))
             {
                 if (e.Target(v) > v)
                 {
                     list.AddFirst(e);
                 }
                 else if (e.Target(v) == v)
                 {
                     if (selfLoops % 2 == 0) list.AddFirst(e);
                     selfLoops++;
                 }
             }
         }
         return list;
     }

     public String toString()
     {
         String NEWLINE = Environment.NewLine;
         StringBuilder s = new StringBuilder();
         s.Append(_v + " " + _e + NEWLINE);
         for (int v = 0; v < _v; v++)
         {
             s.Append(v + ": ");
             foreach (Edge e in _adj[v])
             {
                 s.Append(e.toString() + "  ");
             }
             s.Append(NEWLINE);
         }
         return s.ToString();
     }
 }
}
