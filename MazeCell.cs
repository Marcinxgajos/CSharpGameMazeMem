using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using System.Diagnostics;

namespace GlSharpGame
{
    class MazeCell
    {
       public List<int> Neigboors;
       public int VertexNumber;
        public float x;
        public float y;
        public MazeCell(int Vertex)
        {
            Neigboors = new List<int>();
            //Neigboors.Add(1);
            VertexNumber = Vertex;
        }


    }
    class MazeStruct
    {
        public  List<MazeCell> TableOfMazes;
        public int SizeOfMaze;
        public MazeStruct(int Size)
        {
            SizeOfMaze = Size;
            TableOfMazes = new List<MazeCell>();
            for(int i=0;i<Size;i++)
            {
                TableOfMazes.Add(new MazeCell(i));
            }
        }
        public void setUpByEdge(Edge TempEdge,bool isBothWay)
        {
            
            var result = TableOfMazes.Select(i =>
            {
                if (i.VertexNumber == TempEdge.Source()) i.Neigboors.Add(TempEdge.Dest());
                return i;
            }).ToList();
            if (isBothWay)
            {
                var resultTwo = TableOfMazes.Select(i =>
                    {
                        if (i.VertexNumber == TempEdge.Dest()) i.Neigboors.Add(TempEdge.Source());
                        return i;
                    }).ToList();
            }
         //   var temp = TableOfMazes.FirstOrDefault(c => c.VertexNumber == TempEdge.Source());
          //  if (temp != null)
          //  {
              //  Debug.WriteLine("kjhjkhjkhjk");
             //  // temp.Neigboors.Add(TempEdge.Dest());
         ////   }
         //   var temp = TableOfMazes.Find(r => (r.VertexNumber == TempEdge.Source()));
      //      temp.Neigboors.Add(TempEdge.Dest());
        //    TableOfMazes.ElementAt(r => (r.VertexNumber == TempEdge.Source())).Neigboors.Add(TempEdge.Dest());
  

           // TableOfMazes.ElementAtOrDefault(TempEdge.Source()); 
          //  TableOfMazes
        }
        public void viewByDebug()
        {
           // Debug.WriteLine("das");
            foreach (MazeCell prime  in TableOfMazes)
            {
                Debug.WriteLine("hghf");
               foreach (int vertex in prime.Neigboors)
               {
                  // Debug.WriteLine("jhkjh");
                    //   int vertds=0;
                      // vertds += vertex;
                       Debug.WriteLine(vertex);
                   
               }
            }
        }
    }
}
