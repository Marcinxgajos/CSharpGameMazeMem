using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpGL;
using System.Diagnostics;
//using System.Windows.Forms.Cursor;

namespace GlSharpGame
{
    /// <summary>
    /// The main form class.
    /// </summary>
    public partial class SharpGLForm : Form
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        bool KeyA, KeyS, KeyD, KeyW, KeySpace;
        SprawdzaczKolizji Sprawdzacz;
        TrapChecker StraightTrap;
        MazeStruct MyMaze,MyMazeTwo;
        List<int> MazeCellType;
        List<Wektor> ListaKolizji;
        List<float> ListaKolizjiX;
        List<float> ListaKolizjiZ;
        List<int> tempMazeList;
         Wektor da,re;
            kwardratMaterialny cuboPlayer;
            int PlayerLive;
            Wektor PlayerWektor;
            Wektor PlayerWektorSpeed;
            float Angle_of_Player;
        Wektor CursorWektor;
        Wektor CursorWektorAngled;
        Wektor WektorZero;
        int[][] MazeCellsIntTab;
            KwadratBoss Boss;
            List<KwadratMaterialnyPocisk> listaPociskow;
            List<KwadratMaterialnyPocisk> listaPociskowPlayera;
            KwadratMaterialnyPocisk bulletOne;
            Rysownik rysow;
            RysownikMaze rysowM;
            double YAxisCamera;
            bool first_time;
            int Basic_Size;
          //soundtouch
        //
           
      
        

      //  public void DrawCubo(float x1,float y1,float z1,float x2,float y2,float z2);

        public SharpGLForm()
        {
            Basic_Size = 17;
            MazeCellsIntTab= new int[Basic_Size][];
            for (int j = 0; j < Basic_Size;j++ )
            {
                MazeCellsIntTab[j] = new int[Basic_Size];
            }

                ListaKolizji = new List<Wektor>();
            ListaKolizjiX = new List<float>();
            ListaKolizjiZ = new List<float>();
            MazeCellType = new List<int>();
            rysowM =new RysownikMaze();
            StraightTrap = new TrapChecker();
          //  Sprawdzacz = new SprawdzaczKolizji();
            MyMaze = rysowM.DrawMazeSkelethOfSize(25,true);
            MyMazeTwo = rysowM.DrawMazeSkelethOfSize(Basic_Size,false);
            first_time = false;
            tempMazeList = rysowM.ConvertMazeStructToListOfTypes(MyMazeTwo);
     
               for(int i=0;i<Basic_Size*Basic_Size;i++)
               {
                   MazeCellsIntTab[i / Basic_Size][i % Basic_Size] = tempMazeList.ElementAt(i);
               }





                KeyA = false;
             KeyS = false; KeyD = false;
             KeyW=false; KeySpace=false;
            WektorZero = new Wektor(0, 0, 0);
            PlayerWektorSpeed = new Wektor(0, 0, 0);
            PlayerLive = 7;
            YAxisCamera = 5;
            CursorWektor = new Wektor(0, 0, 0);
            CursorWektorAngled = new Wektor(0, 0, 0);
            Debug.WriteLine("j");
            Boss = new KwadratBoss(true);
           // new List<int>();
            listaPociskow = new List<KwadratMaterialnyPocisk>();
            listaPociskowPlayera = new List<KwadratMaterialnyPocisk>();
            listaPociskow.Add(new KwadratMaterialnyPocisk(Boss.polozenie, new Wektor(0.1f, 0.0f, -0.13f), 22));
            listaPociskow.Add(new KwadratMaterialnyPocisk(Boss.polozenie, new Wektor(0.09f, 0.0f, -0.03f), 22));
            listaPociskow.Add(new KwadratMaterialnyPocisk(Boss.polozenie, new Wektor(-0.14f, 0.0f, -0.133f), 22));
            for(int i=0 ; i<13 ; i++)
            {
            listaPociskow.Add(new KwadratMaterialnyPocisk(Boss.polozenie,losowyWektorPredkosci(),20));
            }

            cuboPlayer = new kwardratMaterialny(new Wektor(0.0f,0.0f,0.0f),new Wektor(0.0f,0.0f,0.0f),new Wektor(0.4f,0.4f,0.4f),new Wektor(0.2f,0.2f,0.2f),45);
     //       Wektor temp,temp1;
     //       temp = new Wektor(0.0f,0.0f,0.0f);
       //     temp1 = new Wektor(0.2f,0.0f,-0.1f);
            bulletOne = new KwadratMaterialnyPocisk(new Wektor(0.0f, 0.0f, 0.0f),new Wektor(0.2f, 0.0f, 0.03f), 40);
            bulletOne = new KwadratMaterialnyPocisk(new Wektor(0.0f, 0.0f, 0.0f), 30);
            //bulletOne = new KwadratMaterialnyPocisk(temp, temp1, 30);
           // new KwadratMaterialnyPocisk()

                
           

            da = new Wektor(1.0f, 1.0f, 1.0f);
        //    Wektor re;
            re = new Wektor(2.0f, 1.0f, 1.0f);
       
            InitializeComponent();
            this.Controls.Add(openGLControl);
            
            // this.
            // openGLControl.KeyPress += openGLControl_KeyPress;
            this.openGLControl.KeyPress += new KeyPressEventHandler(keypressed);         
            this.openGLControl.KeyDown += new KeyEventHandler(Form2_KeyDown);
            this.openGLControl.KeyUp += new KeyEventHandler(Form1_KeyUp);
            this.openGLControl.MouseClick += Control1_MouseClick;
  
            
        }

       

        /// <summary>
        /// Handles the OpenGLDraw event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RenderEventArgs"/> instance containing the event data.</param>
        /// 
        public double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        public double ConvertToDegree(double angle)
        {
            return angle * Math.PI / 180.0;
        }

        private Wektor RotateWektorOnZero(Wektor wek,float angle)
        {
            Wektor Pom;
            Pom = new Wektor(0, 0, 0);
            Pom.X = (float)(((wek.X ) * Math.Cos(ConvertToRadians(angle))) - (( wek.Z) * Math.Sin(ConvertToRadians(angle))));
            Pom.Z = (float)(((  wek.X) * Math.Sin(ConvertToRadians(angle))) + ((wek.Z ) * Math.Cos(ConvertToRadians(angle))));
            return Pom;
 

        }

        private double Angle_between_wektor_X_Z(Wektor first,Wektor secend)
        {
            //i x1 = 200, y1 = 150, x2 = 250, y2 = 170;

            //distance b/w them
            double X = first.X - secend.X;
            double Z = first.Z - secend.Z;

       //     double X = Math.Pow((double)X, 2);
         //   double Z = Math.Pow((double)Z, 2);

       //     double d = Math.Abs(Math.Sqrt((double)X + (double)Z));

            double angleInRadian = Math.Atan2((double)Z, (double)X); //angle in radian

            double angleInDegree = (angleInRadian * 180 / Math.PI);
            if (angleInDegree < 0) { angleInDegree += 360; }
          //  Debug.WriteLine(angleInDegree);
            return angleInDegree;
        }

        private Wektor rotate_wektor(float centerX, float centerZ, float angle_in_degree, Wektor p)
        {
            float s = (float)Math.Sin(angle_in_degree);
            float c = (float)Math.Cos(angle_in_degree);

            // translate point back to origin:
            p.X-= centerX;
            p.Z -= centerZ;

            // rotate point
            float xnew = p.X * c - p.Z * s;
            float ynew = p.X * s + p.Z * c;

            // translate point back:
            p.X = xnew + centerX;
            p.Z = ynew + centerZ;
            return p;
        }

        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
          
            CursorWektor.X =-1 * ((float)Cursor.Position.X - 680) / 50;
            CursorWektor.Z = -1 * ((float)Cursor.Position.Y - 374) / 50;
         //   double Angle = Math.Atan2(CursorWektor.Z, CursorWektor.X);
            double Angle = -45;
            CursorWektorAngled = rotate_wektor(0, 0, (float)Angle, CursorWektor);
         //   CursorWektorAngled.X = CursorWektor.X * (float)Math.Sin(Angle -ConvertToRadians(90));
         //   CursorWektorAngled.Z = CursorWektor.Z * (float)Math.Cos(Angle -ConvertToRadians(90));
         
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            rysow = new Rysownik(gl);
            rysowM.SetUpGl(gl);
            
            if (!first_time)
            {
                rysowM.DrawMazeFloor(tempMazeList, 1.0f, new Wektor(0, 0, 0));
                if (rysowM.ListaPointowDoKolizji != null)
                {
                    //   Debug.Write("wwrsdsfsafasfa");
                    ListaKolizji = rysowM.ListaPointowDoKolizji;
                    //   ListaKolizjiX = rysowM.ListaXDoKolizji;
                    //  ListaKolizjiZ = rysowM.ListaZDoKolizji;
                }
                first_time = true;
            }
            Sprawdzacz = new SprawdzaczKolizji(rysow);
         //   rysowM = new RysownikMaze(gl);
            //  Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
          //  (x > 0 ? x : (2*PI + x)) * 360 / (2*PI)
                double AngleX;
                AngleX = CursorWektor.X;
           //     if(CursorWektor.X<0){AngleX = (2*Math.PI + CursorWektor.X) * 360 / (2*Math.PI) ;}

                double AngleY;
                AngleY = CursorWektor.Z;
            //    if (CursorWektor.Z < 0) { AngleY = (2 * Math.PI + CursorWektor.Z) * 360 / (2 * Math.PI); }


                Angle_between_wektor_X_Z(WektorZero, CursorWektor);

                     //  Load the identity matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gl.LoadIdentity();
            gl.Perspective(60.0f, 0, 0, 0);
            rysow.DrawLive(new Wektor(0.9f, -0.7f, 0), new Wektor(0.05f, 0.03f, 0f), PlayerLive);
            rysow.DrawLive(new Wektor(-0.9f, -0.7f, 0), new Wektor(0.05f, 0.04f, 0f), Boss.Live);




         //   gl.DepthMask(0);
        //    rysow.DrawCubo(0, 0, 0, 0.33f, 0.33f, 0.33f,0.0f,true,0.6f);
        //    gl.DepthMask(1);
            gl.Enable(SharpGL.OpenGL.GL_SMOOTH);
            gl.Enable(SharpGL.OpenGL.GL_FLAT);
           
        //    gl.Enable(SharpGL.OpenGL.GL_LINE_SMOOTH);
            //  Create a perspective transformation.
            gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);
            
            //  Use the 'look at' helper function to position and aim the camera.
            gl.LookAt(cuboPlayer.polozenie.X - 5, YAxisCamera, cuboPlayer.polozenie.Z - 5, cuboPlayer.polozenie.X, cuboPlayer.polozenie.Y, cuboPlayer.polozenie.Z, 0, 1, 0);

            //  Rotate around the Y axis.
          
           
            float samesize= 2.3f;
           
            // =new Wektor(1.0, 1.0, 1.0);
            //Wektor re(1.0,1.0,1.0);

     /*       for (int i = 0; i < listaPociskow.Count; i++) // Loop with for.
     {
                
                 rysow.DrawCubo(listaPociskow[i].polozenie.X, listaPociskow[i].polozenie.Y, listaPociskow[i].polozenie.Z,
                       listaPociskow[i].grubosci.X, listaPociskow[i].grubosci.Y, listaPociskow[i].grubosci.Z, (float)listaPociskow[i].angle + rotation, true,1.0f);
                
           } */
          //  list
        /*    for (int i = 0; i < listaPociskowPlayera.Count; i++) // Loop with for.
            {

                rysow.DrawCubo(listaPociskowPlayera[i].polozenie.X, listaPociskowPlayera[i].polozenie.Y, listaPociskowPlayera[i].polozenie.Z,
                      listaPociskowPlayera[i].grubosci.X, listaPociskowPlayera[i].grubosci.Y, listaPociskowPlayera[i].grubosci.Z, (float)listaPociskowPlayera[i].angle + rotation, true, 1.0f);

            }
            */


         //   rysow.DrawCubo(Boss.polozenie.X, Boss.polozenie.Y, Boss.polozenie.Z,
          //      Boss.grubosci.X, Boss.grubosci.Y, Boss.grubosci.Z, 20,2);

           // rysow.draw_floor();
         //   rysowM.FinalDrawAllMazeByGl(MyMaze, new Wektor(0, 0, 0),(float)cuboPlayer.angle/15);
          //  rysowM.FinalDrawAllMazeByGl(MyMazeTwo, new Wektor(-2, 0, -3), 0.5f);

          





      //     rysowM.DrawMazyByListToSpeedUp(tempMazeList,new Wektor(2,0,0),0.02f);
       //    rysowM.drawQuadFloor(new Wektor(1, 0, 1), 1f);
       

     //      rysowM.drawQuadFloor(new Wektor(0,0,0),1.0f);
    
           
               rysowM.DrawMazeFloor(tempMazeList, 1.0f, new Wektor(0, 0, 0));
               int Xo;
               int Yo;
               Coord tempCo = StraightTrap.in_what_coord(cuboPlayer.polozenie.X, cuboPlayer.polozenie.Z, 1.0f);

               Debug.Write(tempCo.x);
            Debug.Write("   y>");
            Debug.WriteLine(tempCo.y);
           if( StraightTrap.is_three_cell_far(MazeCellsIntTab, tempCo.x, tempCo.y))
           {
               Debug.WriteLine("buuummm");
           }
      //      + "  y>" + cuboPlayer.polozenie.Z-1.0f);
      //      gl.EnableClientState(OpenGL.GL_VERTEX_ARRAY);
      
       //     gl.VertexPointer(0,3,rysowM.ArrayVertex);
          
          //  gl.VertexPointer()
//glVertexPointer(3, GL_FLOAT, 0, vertices);

// draw a cube
       //     gl.DrawArrays(OpenGL.GL_LINES,0,rysowM.count/2);
//glDrawArrays(GL_TRIANGLES, 0, 36);

// deactivate vertex arrays after drawing
//glDisableClientState(GL_VERTEX_ARRAY);
    //        gl.EnableClientState(OpenGL.GL_VERTEX_ARRAY);
  //          gl.DrawArrays()
          //  Debug.WriteLine(ListaKolizji.Count + " <out  ");



       //mapka//    rysowM.DrawMazyByListToSpeedUp(tempMazeList, cuboPlayer.polozenie, 0.22f);










        //   Debug.Write(tempMazeList.Count.ToString() + " ");

        //    rysowM.FinalDrawAllMazeByGl(MyMazeTwo, new Wektor(-5, 0, -5),1+(float)Math.Sin(rotation/10));
       
          gl.Enable(SharpGL.OpenGL.GL_BLEND);
            gl.BlendFunc(SharpGL.OpenGL.GL_SRC_ALPHA,SharpGL.OpenGL.GL_ONE_MINUS_SRC_ALPHA);

//           glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
            CursorWektor += cuboPlayer.polozenie;
            rysow.DrawCubo_with_alpha(CursorWektor.X, CursorWektor.Y, CursorWektor.Z,
                cuboPlayer.grubosci.X,
                cuboPlayer.grubosci.Y, cuboPlayer.grubosci.Z, rotation * 2,0.3f);
            CursorWektorAngled += cuboPlayer.polozenie;
           // rysow.DrawCubo_with_alpha(CursorWektorAngled.X, CursorWektorAngled.Y, CursorWektorAngled.Z,
       ////         cuboPlayer.grubosci.X,
      //          cuboPlayer.grubosci.Y * 3, cuboPlayer.grubosci.Z, (float)(1.5 * -1) * rotation, 0.3f);


            cuboPlayer.angle = -1f * Angle_between_wektor_X_Z(cuboPlayer.polozenie, CursorWektor);

            rysow.DrawPlayer(cuboPlayer.polozenie, cuboPlayer.grubosci, cuboPlayer.angle);
        
          //  rysow.DrawCubo_with_alpha(CursorWektorAngled.X,CursorWektorAngled.Y,CursorWektorAngled.Z,
          //      cuboPlayer.grubosci.X,
        //        cuboPlayer.grubosci.Y*3, cuboPlayer.grubosci.Z,  (float)(1.5 * -1) * rotation ,0.3f);


            Wektor AngleZeto;
            AngleZeto = new Wektor(120, 31200, 2130);
            //
         //   trete

            //player config
            int hour_0_to_7;
            hour_0_to_7 = 900000;



            if (KeyW && !KeyA && !KeyD && !KeyS)
            {
                hour_0_to_7 = -1;
            }
            if (!KeyW && !KeyA && !KeyD && KeyS)
            {
                hour_0_to_7 = 4;
            }

            if (!KeyW && KeyA && !KeyD && !KeyS)
            {
                hour_0_to_7 = 6;
            }
            if (!KeyW && !KeyA && KeyD && !KeyS)
            {
                hour_0_to_7 = 2;
            }

            if (KeyA && KeyS && !KeyW)
            {
                hour_0_to_7 = 5;
            }
            if (KeyS && KeyD && !KeyW)
            {
                hour_0_to_7 = 3;
            }
            if (KeyD && KeyW)
            {
                hour_0_to_7 = 1;
            }
            if (KeyW && KeyA)
            {
                hour_0_to_7 = 7;
            }

            Wektor temp;
            temp = new Wektor(0.0f, 0.0f, 0.2f);
            if (Math.Abs(cuboPlayer.predkosc.X) < 0.2f && Math.Abs(cuboPlayer.predkosc.Z) < 0.2f)
            {

                switch (hour_0_to_7)
                {
                    case -1:

                        cuboPlayer.predkosc = RotateWektorOnZero(temp, 315);
                        break;
                    case 1:

                        cuboPlayer.predkosc = temp;
                        //      cuboPlayer.predkosc.Z += 0.21f;
                //        Debug.WriteLine(RotateWektorOnZero(temp, 45).X + "   " + RotateWektorOnZero(temp, 45).Z);
                        break;
                    case 2:
                        cuboPlayer.predkosc = RotateWektorOnZero(temp, 45);
                        //cuboPlayer.predkosc.Z += RotateWektorOnZero(temp, 90).Z;
                    //    Debug.WriteLine(RotateWektorOnZero(temp, 90).X + "   " + RotateWektorOnZero(temp, 90).Z);
                        break;

                    case 3:
                        cuboPlayer.predkosc = RotateWektorOnZero(temp, 90);
                        break;
                    case 4:
                        cuboPlayer.predkosc = RotateWektorOnZero(temp, 135);
                        break;
                    case 5:
                        cuboPlayer.predkosc = RotateWektorOnZero(temp, 180);
                        break;
                    case 6:
                        cuboPlayer.predkosc = RotateWektorOnZero(temp, 225);
                        break;
                    case 7:
                        cuboPlayer.predkosc = RotateWektorOnZero(temp, 270);
                        break;
                    // default:
                    //        cuboPlayer.wycisz_predkosc_only_XZ_o(0.1f);



                }
            }

      
            cuboPlayer.wycisz_predkosc_only_XZ_o(0.01f);
         //   if(Sprawdzacz.CzyNieKoliduje(ListaKolizji,1.0f,cuboPlayer.polozenie + cuboPlayer.predkosc)){

            if (ListaKolizji != null)
            {
          //      Debug.Write(ListaKolizji.Count);
             //   Debug.Write("nie pusty");
               if(Sprawdzacz.CzyNieKoliduje(ListaKolizji,0.5f,cuboPlayer.polozenie+cuboPlayer.predkosc))
               {
                    cuboPlayer.krok_naprzod();
               }
            }
       
            //esle









            if (bulletOne != null) { bulletOne.krok_naprzod(); }

            Boss.krok_naprzod();
      //      foreach (KwadratMaterialnyPocisk prime in listaPociskow) // Loop through List with foreach.
     //       {
    //           prime.krok_naprzod();
    //        }
            for (int i = 0; i < listaPociskow.Count; i++) // Loop with for.
            {
                if (listaPociskow[i].vitality < 1)
                {
                    listaPociskow.RemoveAt(i);
                }
                else
                {
                    listaPociskow[i].krok_naprzod();
                }


            }

            //foreach (KwadratMaterialnyPocisk prime in listaPociskowPlayera) // Loop through List with foreach.
            //{
            //    if (prime.vitality < 3)
            //    {
            //        listaPociskowPlayera.Remove(prime);
            //    }
            //    else
            //    {
            //        prime.krok_naprzod();
            //    }
            //}

            for (int i = 0; i < listaPociskowPlayera.Count; i++) // Loop with for.
            {
                if(czy_nachodza(listaPociskowPlayera[i].polozenie,Boss.polozenie,Boss.grubosci.X))
                {
                    Boss.Live--;
                  //  Debug.WriteLine("nachodza");
                }

                if (listaPociskowPlayera[i].vitality < 3)
                {
                    listaPociskowPlayera.RemoveAt(i);
                }
                else
                {
                    listaPociskowPlayera[i].krok_naprzod();
                }
               

            }

            if (cuboPlayer.polozenie.X < 2.0f * 16 * 3 && -5.5f + (2.0f * 16 * 3) < cuboPlayer.polozenie.Z && -5.5f + (2.0f * 16 * 3) < cuboPlayer.polozenie.X                )
            {
                ListaKolizji = new List<Wektor>();
                ListaKolizjiX = new List<float>();
                ListaKolizjiZ = new List<float>();
                MazeCellType = new List<int>();
                rysowM = new RysownikMaze();
             //   Sprawdzacz = new SprawdzaczKolizji();
                MyMaze = rysowM.DrawMazeSkelethOfSize(25, true);
                MyMazeTwo = rysowM.DrawMazeSkelethOfSize(16, false);
                //
                tempMazeList = rysowM.ConvertMazeStructToListOfTypes(MyMazeTwo);
            
                cuboPlayer.polozenie = new Wektor(0, 0, 0);
            }

            if( cuboPlayer.polozenie.X > 2.0f * 16)
            {

            }

            if(Boss.counter%100  == 0)
            {
                Boss.Live--;
                if(Boss.Live==0)
                {
                    cuboPlayer.polozenie = new Wektor(0, 0, 0);
                }
                listaPociskow = new List<KwadratMaterialnyPocisk>();
                for (int i = 0; i < 13; i++)
                {
                    listaPociskow.Add(new KwadratMaterialnyPocisk(Boss.polozenie, losowyWektorPredkosci(), 20));
                }

            }


           // cuboOne.daj_kat_kwadrata();
            //  Nudge the rotation.
            rotation += 3.0f;
            Wektor inc;
            inc = new Wektor(0.01f, 0.0f, 0.0f);
            da += inc;
           re= re * 1.01f;
           if (bulletOne != null)
           {
               if (bulletOne.vitality < 0)
               {
                   bulletOne = null;
               }
           }



        } 

        private bool czy_nachodza(Wektor first,Wektor secend,float margines)
        {
            if( secend.X < first.X + margines && secend.X > first.X - margines)
            {
                if( secend.Z < first.Z + margines && secend.Z > first.Z - margines)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Handles the OpenGLInitialized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            //  TODO: Initialise OpenGL here.

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
      //      Sprawdzacz.rysow.gl = gl;
            //DrawCubo(0, 0, 0, 1, 1, 1);
          // gl.LookAt( -5, YAxisCamera, -5, 0, 0, 0, 0, 1, 0);
            //  Set the clear color.
            gl.ClearColor(0, 0, 0, 0);
        }



        private void keypressed(Object o, KeyPressEventArgs e)
        {
            // The keypressed method uses the KeyChar property to check 
            // whether the ENTER key is pressed. 
          //  Debug.WriteLine("dsadsadas");

            // If the ENTER key is pressed, the Handled property is set to true, 
            // to indicate the event is handled.
            /*
          

            if (e.KeyChar == (char)Keys.W)
            {
                e.Handled = true;
                Debug.WriteLine("WWWWW");
            }
            if((char)e.KeyChar == 'w')
            {
                Debug.WriteLine("wwwwww");
                cuboPlayer.predkosc.X = 0.2f;
               // cuboPlayer.predkosc.Z = 0.0f;
            }

            if ((char)e.KeyChar == 's')
            {
                Debug.WriteLine("sss");
                cuboPlayer.predkosc.X = -0.2f;
               // cuboPlayer.predkosc.Z = 0.0f;
            }


            if ((char)e.KeyChar == 'a')
            {
                Debug.WriteLine("aaaaa");
                cuboPlayer.predkosc.Z = -0.2f;
           //     cuboPlayer.predkosc.X = 0.0f;
            }


            if ((char)e.KeyChar == 'd')
            {
                Debug.WriteLine("ddddd");
                cuboPlayer.predkosc.Z = 0.2f;
           
            }
            */
         //   ContextStaticAttribute double yAxisCamera;
         //   double yAxisCamera;
        

            if ((char)e.KeyChar == 'p')
            {

                //rysowM.DrawMaze();
                //rysowM.DrawMazeOfSize(1009);
       //         Wektor POP;
       //         Wektor temp;
       //         POP = new Wektor(2, 2, 2);
       //         temp = POP;
           //     Debug.WriteLine(POP.X + ":x " + POP.Z +":z ");
             //   POP = rotate_wektor(0, 0, 180, POP);
            //    POP = RotateWektorOnZero(POP, 180);
          ///      Debug.WriteLine(POP.X + ":x after " + POP.Z + ":z af");
         //       POP = RotateWektorOnZero(POP, 90);
         ///       Debug.WriteLine(POP.X + ":x after " + POP.Z + ":z af");
         ///       POP = RotateWektorOnZero(POP, 45);
        ///        Debug.WriteLine(POP.X + ":x after " + POP.Z + ":z af");
        ///        POP = RotateWektorOnZero(POP, 45);
         ///       Debug.WriteLine(POP.X + ":x after " + POP.Z + ":z af");

                
                Debug.WriteLine("PPPPPP");
                cuboPlayer.predkosc.Z = 0.1f;
                cuboPlayer.predkosc.X = 0.0f;
                cuboPlayer = new kwardratMaterialny(new Wektor(0.0f, 0.0f, 0.0f), new Wektor(0.0f, 0.0f, 0.0f), new Wektor(0.4f, 0.4f, 0.4f), new Wektor(0.2f, 0.2f, 0.2f), 45);
                bulletOne = new KwadratMaterialnyPocisk(new Wektor(0.0f, 0.0f, 0.0f), new Wektor(0.1f, 0.0f, 0.03f), 40);
                bulletOne = new KwadratMaterialnyPocisk(new Wektor(0.0f, 0.0f, 0.0f), 30);
                OpenGL gl = openGLControl.OpenGL;
                YAxisCamera += 0.4;
              //  gl.LookAt(-5, YAxisCamera, -5, 0, 0, 0, 0, 1, 0);
            }
            if ((char)e.KeyChar == 'l')
            {
            
            //    MazeStruct TestMaze;
            //    TestMaze = new MazeStruct(5);
            //    TestMaze.setUpByEdge(new Edge(1, 2, 55));
            //    TestMaze.setUpByEdge(new Edge(2, 1, 674));
            //    TestMaze.setUpByEdge(new Edge(4, 5, 674));

               // TestMaze.setUpByEdge(new)
            //    TestMaze.viewByDebug();
          //      Debug.WriteLine("PPPPPP");
              //  cuboPlayer.predkosc.Z = 0.1f;
              //  cuboPlayer.predkosc.X = 0.0f;
             //   cuboPlayer = new kwardratMaterialny(new Wektor(0.0f, 0.0f, 0.0f), new Wektor(0.0f, 0.0f, 0.0f), new Wektor(0.4f, 0.4f, 0.4f), new Wektor(0.2f, 0.2f, 0.2f), 45);
              //  bulletOne = new KwadratMaterialnyPocisk(new Wektor(0.0f, 0.0f, 0.0f), new Wektor(0.1f, 0.0f, 0.03f), 40);
              //  bulletOne = new KwadratMaterialnyPocisk(new Wektor(0.0f, 0.0f, 0.0f), 30);
              //  OpenGL gl = openGLControl.OpenGL;
                YAxisCamera -= 0.4;
                //  gl.LookAt(-5, YAxisCamera, -5, 0, 0, 0, 0, 1, 0);
            }
          //  YAxisCamera += 0.05;
            if (e.KeyChar == (char)Keys.E)
            {
                e.Handled = true;
         //       Debug.WriteLine("WWWWEEEEEEEW");
            }
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
           //     Debug.WriteLine("returndsdas presed");
            }
           
        }
        private void Control1_MouseClick(Object sender, MouseEventArgs e)
        {
            Wektor Temp;
            Temp = new Wektor(0.3f,0,0);
            float AngleTemp;
            AngleTemp = (float)Angle_between_wektor_X_Z(CursorWektor, cuboPlayer.polozenie);
            Temp = RotateWektorOnZero(Temp, AngleTemp);
           
                     
            listaPociskowPlayera.Add(new KwadratMaterialnyPocisk(cuboPlayer.polozenie,
               Temp,cuboPlayer.angle,true));
           
        }
      
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                KeyA = true;
            }
            else if (e.KeyCode == Keys.S)
            {
                KeyS = true;
            }

            if (e.KeyCode == Keys.D)
            {
                KeyD = true;
            }

            if (e.KeyCode == Keys.W)
            {
                KeyW = true;
            }

            if (e.KeyCode == Keys.Space)
            {
                KeySpace = true;
            }


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                KeyA = true;
            }
            else if (e.KeyCode == Keys.S)
            {
                KeyS = true;
            }

            if(e.KeyCode == Keys.D)
            {
                KeyD = true;
            }

            if(e.KeyCode == Keys.W)
            {
                KeyW = true;
            }

            if(e.KeyCode == Keys.Space)
            {
                KeySpace = true;
            }




            if (KeyW && !KeyA && !KeyD && !KeyS)
            {
                cuboPlayer.predkosc.Z = 2f;
                cuboPlayer.predkosc.X = 0f;
            }
            if (!KeyW && !KeyA && !KeyD && KeyS)
            {
                cuboPlayer.predkosc.Z = -2f;
                cuboPlayer.predkosc.X = 0f;
            }

            if (!KeyW && KeyA && !KeyD && !KeyS)
            {
                cuboPlayer.predkosc.Z = 0f;
                cuboPlayer.predkosc.X = 2.0f;
            }
            if (!KeyW && !KeyA && KeyD && !KeyS)
            {
                cuboPlayer.predkosc.Z = 0f;
                cuboPlayer.predkosc.X = -2.0f;
            }

            if (KeyA && KeyS)
            {
                //Debug.WriteLine("AAAAAAAAAAAAAARRRRRRRRRRRRRRRRRRr");
              //  Console.Beep(234, 589);
                cuboPlayer.predkosc.X = 1.4f;
                cuboPlayer.predkosc.Z = -1.4f;
            }
            if(KeyS && KeyD)
            {
                cuboPlayer.predkosc.X = -1.4f;
                cuboPlayer.predkosc.Z = -1.4f;
            }
            if(KeyD &&  KeyW)
            {
                cuboPlayer.predkosc.X = -1.4f;
                cuboPlayer.predkosc.Z = 1.4f;
            }
            if(KeyW && KeyA)
            {
                cuboPlayer.predkosc.X = 1.4f;
                cuboPlayer.predkosc.Z = 1.4f;
            }


            
            cuboPlayer.setUpWektorPredkosci(0.1f);
            cuboPlayer.setUpToWektor(RotateWektorOnZero(cuboPlayer.predkosc, 315));
          //  cuboPlayer.setUpToWektor(rotate_wektor(0,0,(float)ConvertToRadians(315),cuboPlayer.predkosc));
          //  cuboPlayer.inverseWekOfSpeed();

        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                KeyA = false;
            }
            else if (e.KeyCode == Keys.S)
            {
                KeyS = false;
            }
           
            if (e.KeyCode == Keys.D)
            {
                KeyD = false;
            }

            if (e.KeyCode == Keys.W)
            {
                KeyW = false;
            }

            if (e.KeyCode == Keys.Space)
            {
                KeySpace = false;
            }



        }


        /// <summary>
        /// Handles the Resized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            //  TODO: Set the projection matrix here.

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gl.LoadIdentity();

            //  Create a perspective transformation.
            gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);

            //  Use the 'look at' helper function to position and aim the camera.
            gl.LookAt(-5, YAxisCamera, -5, 0, 0, 0, 0, 1, 0);

            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        /// <summary>
        /// The current rotation.
        /// </summary>
        private float rotation = 0.0f;


        public void DrawCubo(float x1,float y1,float z1,float x2,float y2,float z2)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.PushMatrix();
            gl.Begin(OpenGL.GL_QUADS);
            float halfX;
            float halfY;
            float halfZ;
            halfX = x2 / 2;
            halfY = y2 / 2;
            halfZ = z2 / 2;
            gl.Color(0.7f, 0.2f, 0.0f);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            //

            gl.Color(0.65f, 0.22f, 0.0f);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);


            gl.Color(0.62f, 0.18f, 0.0f);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 - halfZ);


            gl.Color(0.55f, 0.16f, 0.0f);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 - halfZ);


            gl.Color(0.72f, 0.22f, 0.0f);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);

          
            //spodu nima

            gl.End();
           
 

            gl.PopMatrix();
        }
        public void DrawCubo(float x1, float y1, float z1, float x2, float y2, float z2,float alpha)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.PushMatrix();
            gl.Begin(OpenGL.GL_QUADS);
            float halfX;
            float halfY;
            float halfZ;
            halfX = x2 / 2;
            halfY = y2 / 2;
            halfZ = z2 / 2;
            gl.Color(0.7f, 0.2f, 0.0f,alpha);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            //

            gl.Color(0.65f, 0.22f, 0.0f,alpha);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);


            gl.Color(0.62f, 0.18f, 0.0f,alpha);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 - halfZ);


            gl.Color(0.55f, 0.16f, 0.0f,alpha);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 - halfZ);


            gl.Color(0.72f, 0.22f, 0.0f,alpha);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);


            //spodu nima

            gl.End();



            gl.PopMatrix();
        }

        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
        private Wektor losowyWektorPredkosci()
        {
            Wektor temp;
            lock (syncLock)
            {
                double x = random.NextDouble();
                x -= 0.5;
                double y = random.NextDouble();
                y = 0.0;
                double z = random.NextDouble();
                z -= 0.5;
               
                temp = new Wektor((float)x, (float)y, (float)z);
                temp = temp * 0.5f;
            }
            return temp;
        }

    }
}
