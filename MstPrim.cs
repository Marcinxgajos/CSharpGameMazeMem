using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlSharpGame
{
    public class PrimMST
    {
        private Edge[] _edgeTo; //Keep track of the edges in our minimum spanning tree      
        private double[] _distTo; //Keep track of the weights to each edge in our minimum spanning tree   
        private Boolean[] _marked; //Keep track of which vertex we've looked
        private MinPriorityQueue<Double> _pq;  //the [vertex number]|[weight] key value pairs in our minimum spanning tree

        public PrimMST(EdgeWeightedGraph G)
        {
            //initialize the various arrays and the minimum priority queue
            _edgeTo = new Edge[G.V()];
            _distTo = new double[G.V()];
            _marked = new Boolean[G.V()];
            _pq = new IndexMinPriorityQueue<Double>(G.V());
           
            for (int v = 0; v < G.V(); v++) _distTo[v] = Double.PositiveInfinity;

            for (int v = 0; v < G.V(); v++)
                if (!_marked[v]) Prim(G, v);
        }

        private void Prim(EdgeWeightedGraph G, int s)
        {
            
            _distTo[s] = 0.0;
          
            _pq.Insert(s, _distTo[s]);
            while (!_pq.IsEmpty())
            {
               
                int v = _pq.DeleteMin();
                Scan(G, v);
            }
        }

        
        private void Scan(EdgeWeightedGraph G, int v)
        {
            
            _marked[v] = true;
        
            foreach (Edge e in G.Adj(v))
            {
                int w = e.Target(v);
                if (_marked[w]) continue;
                if (e.Weight() < _distTo[w])
                {
                    _distTo[w] = e.Weight();
                    _edgeTo[w] = e;
                    if (_pq.Contains(w)) _pq.ChangeKey(w, _distTo[w]);
                    else _pq.Insert(w, _distTo[w]);
                }
            }
        }

        //Return all the edges in the MST
        public IEnumerable<Edge> Edges()
        {
            Queue<Edge> mst = new Queue<Edge>();
            for (int v = 0; v < _edgeTo.Length; v++)
            {
                Edge e = _edgeTo[v];
                if (e != null)
                {
                    mst.Enqueue(e);
                }
            }
            return mst;
        }

        public double Weight()
        {
            double weight = 0.0;
            foreach (Edge e in Edges())
                weight += e.Weight();
            return weight;
        }
    }

 
}
