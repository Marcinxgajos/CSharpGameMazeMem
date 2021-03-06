﻿    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
using System.Drawing;
    using System.Diagnostics;
    using SharpGL;

    namespace GlSharpGame
    {
        class RysownikMaze
        {
            public float[] ArrayVertex;
            public List<Wektor> ListaPointowDoKolizji;
         //   public List<float> ListaXDoKolizji;
        //    public List<float> ListaZDoKolizji;
            public List<Wektor> listaWectorow;
             public OpenGL gl;
            public int count;
            public bool Is_list_fill;
            public EdgeWeightedGraph Maze;
            public RysownikMaze(OpenGL gll)
            {
                ArrayVertex =new float[30000];
                count = 0;
                gl = gll;
                Is_list_fill=false;
                ListaPointowDoKolizji = new List<Wektor>();
                listaWectorow = new List<Wektor>();
             //   ListaXDoKolizji = new List<float>();
              //  ListaZDoKolizji = new List<float>();
            }
            public RysownikMaze()
            {
                count = 0;
                 ArrayVertex =new float[30000];
              //  ListaXDoKolizji = new List<float>();
               // ListaZDoKolizji = new List<float>();
                ListaPointowDoKolizji = new List<Wektor>();
                listaWectorow = new List<Wektor>();
                Is_list_fill = false;
            }


           public void SetUpGl(OpenGL gll)
            {
                gl =gll;
            }
            public void DrawSkelethMaze()
            {
                 EdgeWeightedGraph MazeBasic = new EdgeWeightedGraph(25);
              //  int tab[25];
                Random rand;
                    rand = new Random();
                    int xRand = rand.Next();
                for(int i=0;i<5;i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        //  for(int x=0;x<4;x++)
                        int dest = ((i + 1) * 5) + j;
                        if (i + 1 < 5)
                        {
                            xRand = (rand.Next() % 6) + 1;
                            Edge tempEdge = new Edge(i * 5 + j, dest, xRand);
                            MazeBasic.AddEdge(tempEdge);
                        }

                        dest = ((i - 1) * 5) + j;
                        if (i - 1 >= 0)
                        {
                            xRand = (rand.Next() % 6) + 1;
                            Edge tempEdge = new Edge(i * 5 + j, dest, xRand);
                            MazeBasic.AddEdge(tempEdge);
                        }

                        dest = (i * 5) + (j + 1);
                        if (j + 1 < 5)
                        {
                            xRand = (rand.Next() % 6) + 1;
                            Edge tempEdge = new Edge(i * 5 + j, dest, xRand);
                            MazeBasic.AddEdge(tempEdge);
                        }

                        dest = (i * 5) + (j - 1);
                        if (j - 1 >= 0)
                        {
                            xRand = (rand.Next() % 6) + 1;
                            Edge tempEdge = new Edge(i * 5 + j, dest, xRand);
                            MazeBasic.AddEdge(tempEdge);
                        }

                        dest =( (i + 1) * 5) + (j + 1);
                        if( j + 1 < 5  && i + 1 < 5)
                        {
                            xRand = (rand.Next() % 6) + 1;
                            Edge tempEdge = new Edge(i * 5 + j, dest, xRand);
                            MazeBasic.AddEdge(tempEdge);
                        }


                    }
                }

                    PrimMST MazeBasicTree = new PrimMST(MazeBasic);
                 //   MazeBasicTree.Edges
                        Queue<Edge> MazeDone = new Queue<Edge>(); 
  
                    int sorc,desto;
                    String writelienString;
                   foreach (Edge s in MazeBasicTree.Edges())
        {

           // Debug.WriteLine( s.Target.  +"  ");

                       sorc = s.Source();
                       desto = s.Dest();
                       writelienString = sorc.ToString() + "  " + desto.ToString();

                  //     Debug.WriteLine(writelienString);
                  


        }

            }//draw maze
            public void DrawMazeOfSize(int MazeSize)
            {
                EdgeWeightedGraph MazeBasic = new EdgeWeightedGraph(MazeSize*MazeSize);
                //  int tab[25];
                Random rand;
                rand = new Random();
                int xRand = rand.Next();
                for (int i = 0; i < MazeSize; i++)
                {
                    for (int j = 0; j < MazeSize; j++)
                    {
                        //  for(int x=0;x<4;x++)
                        int dest = ((i + 1) * MazeSize) + j;
                        if (i + 1 < MazeSize)
                        {
                            xRand = (rand.Next() % 6) + 1;
                            Edge tempEdge = new Edge(i * MazeSize + j, dest, xRand);
                            MazeBasic.AddEdge(tempEdge);
                        }

                        dest = ((i - 1) * MazeSize) + j;
                        if (i - 1 >= 0)
                        {
                            xRand = (rand.Next() % 6) + 1;
                            Edge tempEdge = new Edge(i * MazeSize + j, dest, xRand);
                            MazeBasic.AddEdge(tempEdge);
                        }

                        dest = (i * MazeSize) + (j + 1);
                        if (j + 1 < MazeSize)
                        {
                            xRand = (rand.Next() % 6) + 1;
                            Edge tempEdge = new Edge(i * MazeSize + j, dest, xRand);
                            MazeBasic.AddEdge(tempEdge);
                        }

                        dest = (i * MazeSize) + (j - 1);
                        if (j - 1 >= 0)
                        {
                            xRand = (rand.Next() % 6) + 1;
                            Edge tempEdge = new Edge(i * MazeSize + j, dest, xRand);
                            MazeBasic.AddEdge(tempEdge);
                        }

                        dest = ((i + 1) * MazeSize) + (j + 1);
                        if (j + 1 < MazeSize && i + 1 < MazeSize)
                        {
                            xRand = (rand.Next() % 6) + 1;
                            Edge tempEdge = new Edge(i * MazeSize + j, dest, xRand);
                            MazeBasic.AddEdge(tempEdge);
                        }
                        

                    }
                }

                PrimMST MazeBasicTree = new PrimMST(MazeBasic);
                //   MazeBasicTree.Edges
                Queue<Edge> MazeDone = new Queue<Edge>();
                //  MazeDone = MazeBasicTree.Edges();

                //Edge TempEdge = new Edge(Center.Y,)
             //   int sorc, desto;
            //    String writelienString;
              //  foreach (Edge s in MazeBasicTree.Edges())
           //     {
                    // Debug.WriteLine( s.Target.  +"  ");
                //    sorc = s.Source();
             //       desto = s.Dest();
               //     writelienString = sorc.ToString() + "  " + desto.ToString();

               //     Debug.WriteLine(writelienString);



         //       }

            }//d

            public MazeStruct DrawMazeSkelethOfSize(int MazeSize,bool is_fivedirect)
            {
                EdgeWeightedGraph MazeBasic = new EdgeWeightedGraph(MazeSize * MazeSize);
                //  int tab[25];
                Random rand;
                rand = new Random();
                int xRand = rand.Next();
                for (int i = 0; i < MazeSize; i++)
                {
                    for (int j = 0; j < MazeSize; j++)
                    {
                        //  for(int x=0;x<4;x++)
                        int dest = ((i + 1) * MazeSize) + j;
                        if (i + 1 < MazeSize)
                        {
                            xRand = (rand.Next() % 6) + 1;
                            Edge tempEdge = new Edge(i * MazeSize + j, dest, xRand);
                            MazeBasic.AddEdge(tempEdge);
                        }

                        dest = ((i - 1) * MazeSize) + j;
                        if (i - 1 >= 0)
                        {
                            xRand = (rand.Next() % 6) + 1;
                            Edge tempEdge = new Edge(i * MazeSize + j, dest, xRand);
                            MazeBasic.AddEdge(tempEdge);
                        }

                        dest = (i * MazeSize) + (j + 1);
                        if (j + 1 < MazeSize)
                        {
                            xRand = (rand.Next() % 6) + 1;
                            Edge tempEdge = new Edge(i * MazeSize + j, dest, xRand);
                            MazeBasic.AddEdge(tempEdge);
                        }

                        dest = (i * MazeSize) + (j - 1);
                        if (j - 1 >= 0)
                        {
                            xRand = (rand.Next() % 6) + 1;
                            Edge tempEdge = new Edge(i * MazeSize + j, dest, xRand);
                            MazeBasic.AddEdge(tempEdge);
                        }



                        if (is_fivedirect)
                        {
                            dest = ((i + 1) * MazeSize) + (j + 1);
                            if (j + 1 < MazeSize && i + 1 < MazeSize)
                            {
                                xRand = (rand.Next() % 6) + 1;
                                Edge tempEdge = new Edge(i * MazeSize + j, dest, xRand);
                                MazeBasic.AddEdge(tempEdge);
                            }
                        }



                    }
                }

                PrimMST MazeBasicTree = new PrimMST(MazeBasic);
                //   MazeBasicTree.Edges
                Queue<Edge> MazeDone = new Queue<Edge>();
               // Queue<Edge> MazeDone = new Queue<Edge>();

              //  int sorc, desto;
              //  String writelienString;
                MazeStruct MazeToReturn;
                MazeToReturn = new MazeStruct(MazeSize* MazeSize);
                foreach (Edge s in MazeBasicTree.Edges())
                {

                    // Debug.WriteLine( s.Target.  +"  ");

                    MazeToReturn.setUpByEdge(s,true);



                }
                return MazeToReturn;
            }//d

            public void FinalDrawAllMazeByGl(MazeStruct MazeTemp,Wektor Center,float Weight_of_cell)
            {
                int x;
                int target_x;
                int target_y;
                float weight;
                float weight_with_size;
                weight = Weight_of_cell;
                int y;
                Wektor Cursor;
                Wektor DrawableCursor;
                //Cursor = Center;
                weight_with_size = weight * MazeTemp.SizeOfMaze;
                Cursor = new Wektor(Center.X - (weight_with_size / 2), Center.Y - (weight_with_size / 2), Center.Z - (weight_with_size / 2));
                DrawableCursor = Cursor;
                int InitialSize = (int)Math.Sqrt( (double)MazeTemp.SizeOfMaze);
                gl.PushMatrix();
                gl.Begin(OpenGL.GL_LINES);
                gl.Color(0.44f, 0.44f, 0.44f);
                for(int i = 0;i < MazeTemp.SizeOfMaze;i++)
                {
                    x = i / InitialSize;
                    y = i % InitialSize;
                    DrawableCursor.X = Cursor.X+ ( x * weight);
                    DrawableCursor.Z = Cursor.Z + (y * weight);
                    var temp = MazeTemp.TableOfMazes.Find(r => (r.VertexNumber == i));
                //    Debug.Write(i);
                 //   Debug.WriteLine(temp.Neigboors.Count + "  nawet raz nei jest pusty");
                    foreach (int vertex in temp.Neigboors)
                    {
                        
                   //     Debug.Write(" >>>" + vertex);    
                        target_x = vertex / InitialSize;
                      //awesome schiz //  target_y = vertex / InitialSize;
                        target_y = vertex % InitialSize;

                   //     gl.Color(0.57f, 0.52f, 0.59f);
                    //    gl.Vertex(DrawableCursor.X, Center.Y, DrawableCursor.Z);
                 //       gl.Vertex(Cursor.X, Cursor.Y, Cursor.Z);
                     //   gl.Vertex(Cursor.X + (target_x * weight), 0 , Cursor.Z + (target_y * weight));
                        gl.Vertex(Center.X+ (target_x* weight ), Center.Y, Center.Z + (target_y * weight));
                        gl.Vertex(Center.X + (x * weight),Center.Y,Center.Z + (y * weight));





                    }
                 //   Debug.WriteLine(" ");
                    //      temp.Neigboors.Add(TempEdge.Dest());
                }
                gl.End();
                gl.PopMatrix();
            }
            public List<int> ConvertMazeStructToListOfTypes(MazeStruct MazeTemp)
            {
                int x,y;
                List<int> tempList;
                tempList = new List<int>();
                bool up, down, left, right;
                int ofType;
                ofType = 10000;
           
              //  tempString = "0000";
                int target_x= 0;
                int target_y= 0;
                 int InitialSize = (int)Math.Sqrt( (double)MazeTemp.SizeOfMaze);
                // Debug.WriteLine(InitialSize);
                for(int i = 0;i < MazeTemp.SizeOfMaze;i++)
                {
              //                          x = i / InitialSize;
              //      y = i % InitialSize;
                    x = i / InitialSize;
                    y = i % InitialSize;
                     var temp = MazeTemp.TableOfMazes.Find(r => (r.VertexNumber == i));

                    //kurde find nieraz zwraca tempa bez sasiadow ...
             //        Debug.WriteLine(temp.Neigboors.Count);        
                     up = down = left = right = false;
                    //if work is fine
                    foreach (int vertex in temp.Neigboors)
                    {
                        Debug.WriteLine(i + " >>" + vertex);
                     //   target_x = vertex / InitialSize;
                 //       target_y = vertex % InitialSize;
                        target_x = vertex / InitialSize;
                        target_y = vertex % InitialSize;

                        if(target_x == x)
                        {
                            if(target_y > y)
                            {
                                up = true;
                              //  tempString[0] = '1';
                                ofType += 1000;               
                            }
                            else
                            {
                                down = true;
                               // tempString[2] = '1';
                                ofType += 10;
                            }


                        }
                        else
                        {
                            if(target_x > x)
                            {
                                right = true;
                                ofType += 100;
                             //   tempString[1] = '1';
                            }
                            else
                            {
                                left = true;
                                ofType += 1;
                              //  tempString[3] = '1';
                            }
                        }
                       
                      //awesome schiz //  target_y = vertex / InitialSize;
                      

                    } //foreach

                 //   Debug.WriteLine(ofType);

                    if (ofType != 10000)
                    {
                        tempList.Add(ofType);
                       // Debug.WriteLine("sasiaz z" + ofType + " o numerze " + i);
                    }
             
                    
                    ofType = 10000;
                    

                    //      temp.Neigboors.Add(TempEdge.Dest());
                }


                return tempList;
            }


            public void DrawMazyByListToSpeedUp(List<int> tempList, Wektor Center, float Weight_of_cell)
            {
                float weight;
                float weight_with_size;
                weight = Weight_of_cell;
                Wektor Cursor;
                Wektor DrawableCursor;
                //Cursor = Center;
              //  weight_with_size = weight * tempList.Count;
                float Xx;
                float Yy;
               
                
            
                int InitialSize = (int)Math.Sqrt((double)tempList.Count);
                weight_with_size = weight * InitialSize;
                Cursor = new Wektor(Center.X - (weight_with_size / 2), Center.Y, Center.Z - (weight_with_size / 2));
             //   Debug.WriteLine(InitialSize);
                Xx = Center.X - (weight_with_size / 2);
                Yy = Center.Z - (weight_with_size / 2);
                DrawableCursor = Cursor;
                weight *= 2;
                gl.PushMatrix();
                gl.Begin(OpenGL.GL_LINES);
                gl.Color(0.44f, 0.44f, 0.44f);
                int i = 0;
                //   for (int i = 0; i < tempList.Count; i++ )
                foreach (int prime in tempList)             
             {
                    //tempList.ElementAt(i)
                    Cursor.X = Xx + ((weight) * (i / InitialSize));

                    Cursor.Z = Yy + ((weight) * (i % InitialSize));

                    //  Debug.Write(prime);
                    switch (tempList.ElementAt(i))
                    {
                        case 11111:
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X, Center.Y ,Cursor.Z + weight);
                           // ListaPointowDoKolizji.Add(new Point(Cursor.X, Cursor.Z + weight));
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X + weight, Center.Y, Cursor.Z);
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X, Center.Y, Cursor.Z - weight);
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X - weight, Center.Y, Cursor.Z);
                            break;
                        case 10111:

                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X + weight, Center.Y, Cursor.Z);
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X, Center.Y, Cursor.Z - weight);
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X - weight, Center.Y, Cursor.Z);
                            //Debug.Write("in 10111");
                            break;

                        case 11011:
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X, Center.Y, Cursor.Z + weight);

                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X, Center.Y, Cursor.Z - weight);
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X - weight, Center.Y, Cursor.Z);
                            // Debug.WriteLine(prime);
                            break;
                        case 11101:
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X, Center.Y, Cursor.Z + weight);
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X + weight, Center.Y, Cursor.Z);

                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X - weight, Center.Y, Cursor.Z);
                            break;
                        case 11110:
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X, Center.Y, Cursor.Z + weight);
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X + weight, Center.Y, Cursor.Z);
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X, Center.Y, Cursor.Z - weight);

                            break;
                        case 10011:

                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X, Center.Y, Cursor.Z - weight);
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X - weight, Center.Y, Cursor.Z);
                            break;
                        case 11001:
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X, Center.Y, Cursor.Z + weight);

                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X - weight, Center.Y, Cursor.Z);
                            break;
                        case 11100:
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X, Center.Y, Cursor.Z + weight);
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X + weight, Center.Y, Cursor.Z);

                            break;
                        case 10110:
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X + weight, Center.Y, Cursor.Z);
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X, Center.Y, Cursor.Z - weight);
                            break;
                        case 11010:
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X, Center.Y, Cursor.Z + weight);

                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X, Center.Y, Cursor.Z - weight);

                            break;
                        case 10101:
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X + weight, Center.Y, Cursor.Z);
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X - weight, Center.Y, Cursor.Z);
                            break;
                        case 10001:
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X - weight, Center.Y, Cursor.Z);
                            break;
                        case 10010:
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X, Center.Y, Cursor.Z - weight);

                            break;
                        case 10100:

                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X + weight, Center.Y, Cursor.Z);

                            break;
                        case 11000:
                            drawVertex(Cursor);
                            gl.Vertex(Cursor.X, Center.Y, Cursor.Z + weight);
                            break;

                    }//switch prime
                    //  gl.Vertex(DrawableCursor.X, Center.Y, DrawableCursor.Z);
                    //      Debug.WriteLine(DrawableCursor.X + " "  + DrawableCursor.Y + "   " + DrawableCursor.Z);


                    //   drawVertex(new Wektor(Center.Y, Center.Y, 0));



                
             //      Cursor.Y += 0.05f; 
                    //    Debug.WriteLine(i / InitialSize);
                   //  Debug.WriteLine(Cursor.X + " " + Cursor.Z);
                   //   Debug.WriteLine(Xx + " "+ Yy);
                   
                    i++;
                }
                gl.End();
                gl.PopMatrix();
/*
                for(int ii=0;ii<14;ii++)
                {
                    Debug.WriteLine("  ");
                }
 */
            }


        public void drawVertex(Wektor temp)
         {
             gl.Vertex(temp.X, temp.Y, temp.Z);
         }



            public void drawQuadFloor(Wektor center,float weight)
        {
           // Wektor Cursor;
            gl.PushMatrix();
            if (!Is_list_fill)
            {
                ListaPointowDoKolizji.Add(center);
                listaWectorow.Add(center);
                ListaPointowDoKolizji.Add(new Wektor(center.X + weight / 2,center.Y,center.Z));
                ListaPointowDoKolizji.Add(new Wektor(center.X - weight / 2, center.Y, center.Z));
                ListaPointowDoKolizji.Add(new Wektor(center.X, center.Y, center.Z + weight / 2));
                ListaPointowDoKolizji.Add(new Wektor(center.X, center.Y, center.Z - weight / 2));
               // ListaXDoKolizji.Add(center.X);
              //  ListaZDoKolizji.Add(center.Z);
            }
            //     gl.DepthMask(0);
            // gl.r
            gl.Begin(OpenGL.GL_LINES);
            float halfX;
            float halfY;
            float halfZ;
              //  int count;
                count=0;
            halfX = weight/5;
            halfY = weight/5;
            halfZ = weight/5;
            Wektor kursor;
            kursor = new Wektor(center.X-weight, center.Y-0.5f, center.Z-weight);
            for (int i = 0; i < 10; i++)
            {

                if (i % 2 == 0)
                {
                    gl.Color(0.6f, 0.6f, 0.6f, 0.5f);
                }
                else
                {
                    gl.Color(0.4f, 0.4f, 0.4f, 0.5f);
                }
                gl.Vertex(kursor.X, kursor.Y, kursor.Z);
          //      ArrayVertex[0]= kursor.X;

                gl.Vertex(kursor.X, kursor.Y, kursor.Z + weight*2);
                kursor.X += halfX;
            }

            gl.Vertex(kursor.X, kursor.Y, kursor.Z);
            gl.Vertex(kursor.X, kursor.Y, kursor.Z + weight*2);

            kursor = new Wektor(center.X-weight, center.Y-0.5f, center.Z-weight);


            for (int i = 0; i < 10; i++)
            {

                if (i % 2 == 0)
                {
                    gl.Color(0.6f, 0.6f, 0.6f, 0.5f);
                }
                else
                {
                    gl.Color(0.4f, 0.4f, 0.4f, 0.5f);
                }
                gl.Vertex(kursor.X, kursor.Y, kursor.Z);
                gl.Vertex(kursor.X + weight*2, kursor.Y, kursor.Z);
                kursor.Z += halfZ;
            }

            gl.Vertex(kursor.X, kursor.Y, kursor.Z);
            gl.Vertex(kursor.X + weight*2, kursor.Y, kursor.Z);
            //        gl.DepthMask(0);
            gl.End();
            gl.PopMatrix();
        }

            public void drawQuadFloor_withoutPut(Wektor center, float weight)
            {
                // Wektor Cursor;
                gl.PushMatrix();
              

                gl.Begin(OpenGL.GL_LINES);
                float halfX;
                float halfY;
                float halfZ;
                halfX = weight / 5;
                halfY = weight / 5;
                halfZ = weight / 5;
                Wektor kursor;
                kursor = new Wektor(center.X - weight, center.Y - 0.5f, center.Z - weight);
                for (int i = 0; i < 10; i++)
                {

                    if (i % 2 == 0)
                    {
                        gl.Color(0.6f, 0.6f, 0.6f, 0.5f);
                    }
                    else
                    {
                        gl.Color(0.4f, 0.4f, 0.4f, 0.5f);
                    }
                    gl.Vertex(kursor.X, kursor.Y, kursor.Z);
               //     ArrayVertex[count++] = kursor.X;
                 //   ArrayVertex[count++] = kursor.Y;
                 //   ArrayVertex[count++] = kursor.Z;
                    gl.Vertex(kursor.X, kursor.Y, kursor.Z + weight * 2);
                //    ArrayVertex[count++] = kursor.X;
                 //   ArrayVertex[count++] = kursor.Y;
                //    ArrayVertex[count++] = kursor.Z + weight * 2;
                    kursor.X += halfX;
                }

                gl.Vertex(kursor.X, kursor.Y, kursor.Z);
              //  ArrayVertex[count++] = kursor.X;
               // ArrayVertex[count++] = kursor.Y;
               // ArrayVertex[count++] = kursor.Z;
                gl.Vertex(kursor.X, kursor.Y, kursor.Z + weight * 2);
               // ArrayVertex[count++] = kursor.X;
               // ArrayVertex[count++] = kursor.Y;
               // ArrayVertex[count++] = kursor.Z + weight * 2;

                kursor = new Wektor(center.X - weight, center.Y - 0.5f, center.Z - weight);


                for (int i = 0; i < 10; i++)
                {

                    if (i % 2 == 0)
                    {
                        gl.Color(0.6f, 0.6f, 0.6f, 0.5f);
                    }
                    else
                    {
                        gl.Color(0.4f, 0.4f, 0.4f, 0.5f);
                    }
                    gl.Vertex(kursor.X, kursor.Y, kursor.Z);
                  //  ArrayVertex[count++] = kursor.X;
                  //  ArrayVertex[count++] = kursor.Y;
                 //   ArrayVertex[count++] = kursor.Z;
                    gl.Vertex(kursor.X + weight * 2, kursor.Y, kursor.Z);
               //     ArrayVertex[count++] = kursor.X + weight * 2;
               //     ArrayVertex[count++] = kursor.Y;
                //    ArrayVertex[count++] = kursor.Z;
                    kursor.Z += halfZ;
                }

                gl.Vertex(kursor.X, kursor.Y, kursor.Z);
            //    ArrayVertex[count++] = kursor.X;
            //    ArrayVertex[count++] = kursor.Y;
            //    ArrayVertex[count++] = kursor.Z;
                gl.Vertex(kursor.X + weight * 2, kursor.Y, kursor.Z);
            //    ArrayVertex[count++] = kursor.X + weight * 2;
            //    ArrayVertex[count++] = kursor.Y;
            //    ArrayVertex[count++] = kursor.Z;
                //        gl.DepthMask(0);
                gl.End();
                gl.PopMatrix();
            }

            public void drawQuadFloorL(Wektor center, float weight)
            {
                // Wektor Cursor;
                gl.PushMatrix();


                gl.Begin(OpenGL.GL_LINES);
                float halfX;
                float halfY;
                float halfZ;
                halfX = weight / 5;
                halfY = weight / 5;
                halfZ = weight / 5;
                Wektor kursor;
                kursor = new Wektor(center.X - weight, center.Y - 0.5f, center.Z - weight);
                for (int i = 0; i < 10; i++)
                {

                    if (i % 2 == 0)
                    {
                        gl.Color(0.6f, 0.6f, 0.6f, 0.5f);
                    }
                    else
                    {
                        gl.Color(0.4f, 0.4f, 0.4f, 0.5f);
                    }
                 //   gl.Vertex(kursor.X, kursor.Y, kursor.Z);
                    ArrayVertex[count++] = kursor.X;
                    ArrayVertex[count++] = kursor.Y;
                    ArrayVertex[count++] = kursor.Z;
                 //   gl.Vertex(kursor.X, kursor.Y, kursor.Z + weight * 2);
                    ArrayVertex[count++] = kursor.X;
                    ArrayVertex[count++] = kursor.Y;
                    ArrayVertex[count++] = kursor.Z + weight * 2;
                    kursor.X += halfX;
                }

             //   gl.Vertex(kursor.X, kursor.Y, kursor.Z);
                ArrayVertex[count++] = kursor.X;
                ArrayVertex[count++] = kursor.Y;
                ArrayVertex[count++] = kursor.Z;
             //   gl.Vertex(kursor.X, kursor.Y, kursor.Z + weight * 2);
                ArrayVertex[count++] = kursor.X;
                ArrayVertex[count++] = kursor.Y;
                ArrayVertex[count++] = kursor.Z + weight * 2;

                kursor = new Wektor(center.X - weight, center.Y - 0.5f, center.Z - weight);


                for (int i = 0; i < 10; i++)
                {

                    if (i % 2 == 0)
                    {
                        gl.Color(0.6f, 0.6f, 0.6f, 0.5f);
                    }
                    else
                    {
                        gl.Color(0.4f, 0.4f, 0.4f, 0.5f);
                    }
              //      gl.Vertex(kursor.X, kursor.Y, kursor.Z);
                    ArrayVertex[count++] = kursor.X;
                    ArrayVertex[count++] = kursor.Y;
                    ArrayVertex[count++] = kursor.Z;
                 //   gl.Vertex(kursor.X + weight * 2, kursor.Y, kursor.Z);
                    ArrayVertex[count++] = kursor.X + weight * 2;
                    ArrayVertex[count++] = kursor.Y;
                    ArrayVertex[count++] = kursor.Z;
                    kursor.Z += halfZ;
                }

            //    gl.Vertex(kursor.X, kursor.Y, kursor.Z);
                ArrayVertex[count++] = kursor.X;
                ArrayVertex[count++] = kursor.Y;
                ArrayVertex[count++] = kursor.Z;
            //    gl.Vertex(kursor.X + weight * 2, kursor.Y, kursor.Z);
                ArrayVertex[count++] = kursor.X + weight * 2;
                ArrayVertex[count++] = kursor.Y;
                ArrayVertex[count++] = kursor.Z;
                //        gl.DepthMask(0);
                gl.End();
                gl.PopMatrix();
            }

            
            
            public void DrawMazeFloor(List<int> CellTypeList,float weight,Wektor Centrum)
            {
                int x;
                int y;
                int InitialSize = (int)Math.Sqrt((double)CellTypeList.Count);
                Wektor Cursor;
                Cursor = Centrum;
               // Cursor = new Wektor(Centrum.X - weight * 2 * InitialSize, Centrum.Y, Centrum.Z - weight * 2 * InitialSize);
                Wektor CursorMoved;
                CursorMoved = Cursor;
                
                for(int i=0;i<CellTypeList.Count;i++)
                {
                 
                    CursorMoved = Cursor;
                    drawQuadFloor(CursorMoved, weight);
                    x = i / InitialSize;
                    y = i % InitialSize;
                    CursorMoved.X = x*6*weight;
                    CursorMoved.Z = y*6*weight;
                    Cursor.Y = 0.5f;

                    switch(CellTypeList.ElementAt(i))
                    {
                        case 11111:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X ,CursorMoved.Y,CursorMoved.Z + 2 * weight),weight);
                            drawQuadFloor(new Wektor(CursorMoved.X + 2*weight,CursorMoved.Y,CursorMoved.Z),weight);
                            drawQuadFloor(new Wektor(CursorMoved.X ,CursorMoved.Y,CursorMoved.Z - 2 * weight),weight);
                            drawQuadFloor(new Wektor(CursorMoved.X - 2*weight,CursorMoved.Y,CursorMoved.Z),weight);
                            
                            break;

                        case 10111:
                            drawQuadFloor(CursorMoved, weight);
                          
                            drawQuadFloor(new Wektor(CursorMoved.X + 2*weight,CursorMoved.Y,CursorMoved.Z),weight);
                            drawQuadFloor(new Wektor(CursorMoved.X ,CursorMoved.Y,CursorMoved.Z - 2 * weight),weight);
                            drawQuadFloor(new Wektor(CursorMoved.X - 2*weight,CursorMoved.Y,CursorMoved.Z),weight);
                            break;
                        case 11011:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            break;
                        case 11101:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            break;
                        case 11110:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            break;
                        case 10011:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            break;
                        case 11001:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            break;
                        case 11100:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            break;
                        case 11010:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            break;
                        case 10110:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            break;
                        case 10101:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            break;
                        case 11000:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            break;
                        case 10100:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            break;
                        case 10010:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            break;
                        case 10001:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            break;
                    }

                        drawQuadFloor(CursorMoved, weight);
                    

                }
                 
                //drawQuadFloor(new Wektor(Cursor.X, Cursor.Y, Cursor.Z + weight * 2 ), weight);
                //drawQuadFloor(new Wektor(Cursor.X + weight * 2, Cursor.Y, Cursor.Z + weight * 2), weight);
                Is_list_fill = true;
           //     Debug.WriteLine(ListaPointowDoKolizji.Count);

            }
            public void DrawMazeFloorL(List<int> CellTypeList, float weight, Wektor Centrum)
            {
                int x;
                int y;
                int InitialSize = (int)Math.Sqrt((double)CellTypeList.Count);
                Wektor Cursor;
                Cursor = Centrum;
                // Cursor = new Wektor(Centrum.X - weight * 2 * InitialSize, Centrum.Y, Centrum.Z - weight * 2 * InitialSize);
                Wektor CursorMoved;
                CursorMoved = Cursor;

                for (int i = 0; i < CellTypeList.Count; i++)
                {

                    CursorMoved = Cursor;
                    drawQuadFloor(CursorMoved, weight);
                    drawQuadFloorL(CursorMoved, weight);
                    x = i / InitialSize;
                    y = i % InitialSize;
                    CursorMoved.X = x * 6 * weight;
                    CursorMoved.Z = y * 6 * weight;
                    Cursor.Y = 0.5f;

                    switch (CellTypeList.ElementAt(i))
                    {
                        case 11111:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloorL(CursorMoved, weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);


                            break;

                        case 10111:
                            drawQuadFloor(CursorMoved, weight);

                            drawQuadFloor(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloorL(CursorMoved, weight);

                            drawQuadFloorL(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            break;
                        case 11011:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);

                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                              drawQuadFloorL(CursorMoved, weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);

                            drawQuadFloorL(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            break;
                        case 11101:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloorL(CursorMoved, weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            break;
                        case 11110:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            drawQuadFloorL(CursorMoved, weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            break;
                        case 10011:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloorL(CursorMoved, weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            break;
                        case 11001:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloorL(CursorMoved, weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            break;
                        case 11100:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloorL(CursorMoved, weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            break;
                        case 11010:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            drawQuadFloorL(CursorMoved, weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            break;
                        case 10110:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            drawQuadFloorL(CursorMoved, weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            
                            break;
                        case 10101:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloor(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloorL(CursorMoved, weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            break;
                        case 11000:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            drawQuadFloorL(CursorMoved, weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z + 2 * weight), weight);
                            break;
                        case 10100:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            drawQuadFloorL(CursorMoved, weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X + 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                            break;
                        case 10010:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            drawQuadFloorL(CursorMoved, weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X, CursorMoved.Y, CursorMoved.Z - 2 * weight), weight);
                            break;
                        case 10001:
                            drawQuadFloor(CursorMoved, weight);
                            drawQuadFloor(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                              drawQuadFloorL(CursorMoved, weight);
                            drawQuadFloorL(new Wektor(CursorMoved.X - 2 * weight, CursorMoved.Y, CursorMoved.Z), weight);
                          
                            break;
                    }

                    drawQuadFloor(CursorMoved, weight);
                    drawQuadFloorL(CursorMoved, weight);

                }

                //drawQuadFloor(new Wektor(Cursor.X, Cursor.Y, Cursor.Z + weight * 2 ), weight);
                //drawQuadFloor(new Wektor(Cursor.X + weight * 2, Cursor.Y, Cursor.Z + weight * 2), weight);
                Is_list_fill = true;
                //     Debug.WriteLine(ListaPointowDoKolizji.Count);

            }
        }

    }
