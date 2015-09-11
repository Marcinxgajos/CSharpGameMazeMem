using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GlSharpGame
{
    class kwardratMaterialny
    {
        public float waga;
        
       public Wektor polozenie;
       public Wektor predkosc;
       public Wektor grubosci;
        public Wektor kolor;
       public double angle;



       public kwardratMaterialny()
        {
            polozenie = new Wektor();
            predkosc = new Wektor();
            grubosci = new Wektor(0.2f, 0.2f, 0.2f);
            kolor = new Wektor(0.5f, 0.5f, 0.5f);
            waga = 2f;
            angle = 0.0;
        }

       public kwardratMaterialny(Wektor Wektor_polozenia,Wektor Wektor_predkosci,Wektor wektor_grubosci,Wektor wektor_kolor,double kat)
        {
            polozenie = Wektor_polozenia;
            predkosc = Wektor_predkosci;
            grubosci = wektor_grubosci;
            kolor = wektor_kolor;
            waga = 2f;
            angle = kat;
        }
        public void setUpWektorPredkosci(float a)
        {
            predkosc.X *= a;
            predkosc.Y *= a;
            predkosc.Z *= a;
        }
        public void setUpToWektor(Wektor p)
        {
            predkosc = p;
        }

        public void inverseWekOfSpeed()
        {
            predkosc.X *= -1;
            predkosc.Y *= -1;
            predkosc.Z *= -1;
        }

        public kwardratMaterialny(bool czy_losowy)
       {
           if (czy_losowy)
           {
               Random rand;
               rand = new Random();
               double x = rand.NextDouble();
               x -= 0.5;
               double y = rand.NextDouble();
               y = 0.0;
               double z = rand.NextDouble();
               z -= 0.5;
               polozenie = new Wektor((float)x, (float)y, (float)z);
               x = rand.NextDouble();
               x -= 0.5;
               y = rand.NextDouble();
               y = 0.0;
               z = rand.NextDouble();
               z -= 0.5;
               Wektor temp;
               temp =   new Wektor((float)x, (float)y, (float)z);
               temp = temp * 0.1f;
               predkosc = temp;
               x = rand.NextDouble();
               y = rand.NextDouble();
               z = rand.NextDouble();
               temp = new Wektor((float)x, (float)y, (float)z);
               temp = temp * 2.1f;
               grubosci = temp;
               x = rand.NextDouble();
               kolor = new Wektor((float)x, (float)x, (float)x);
               waga = 2f;
           }
            else
           {
               polozenie = new Wektor();
               predkosc = new Wektor();
               grubosci = new Wektor(0.2f, 0.2f, 0.2f);
               kolor = new Wektor(0.5f, 0.5f, 0.5f);
               waga = 2f;
           }



       }


       public void krok_naprzod()
        {
            polozenie = polozenie + predkosc;

        }

        public void wycisz_predkosc()
       {
           if (predkosc.X < 0)
           {
               predkosc.X += 0.1f;
           }
           else
           {
               if (predkosc.X > 0)
               {
                   predkosc.X -= 0.1f;
               }
           }

           if (predkosc.Z < 0)
           {
               predkosc.Z += 0.1f;
           }
           else
           {
               if (predkosc.Z > 0)
               {
                   predkosc.Z -= 0.1f;
               }
           }
        


           
          
       }

        public void wycisz_predkosc_o(float wyciszacz)
        {
            float pom;
            if (predkosc.X < 0)
            {
                if (predkosc.X + wyciszacz > 0)
                {
                    pom = predkosc.X + wyciszacz;
                    predkosc.X += wyciszacz - pom;
                }
                else
                {
                    predkosc.X += wyciszacz;
                }
            }
            else
            {
                if (predkosc.X > 0)
                {
                    if(predkosc.X - wyciszacz < 0)
                    {
                        pom = predkosc.X - wyciszacz;
                        predkosc.X -= wyciszacz + pom;
                    }
                    else
                    {
                        predkosc.X -= wyciszacz;
                    }
                                   }
            }

            if (predkosc.Y < 0)
            {
                if (predkosc.Y + wyciszacz > 0)
                {
                    pom = predkosc.Y + wyciszacz;
                    predkosc.Y += wyciszacz - pom;
                }
                else
                {
                    predkosc.Y += wyciszacz;
                }
            }
            else
            {
                if (predkosc.Y > 0)
                {
                    if (predkosc.Y - wyciszacz < 0)
                    {
                        pom = predkosc.Y - wyciszacz;
                        predkosc.Y -= wyciszacz + pom;
                    }
                    else
                    {
                        predkosc.Y -= wyciszacz;
                    }
                }
            }
            if (predkosc.Z < 0)
            {
                if (predkosc.Z + wyciszacz > 0)
                {
                    pom = predkosc.Z + wyciszacz;
                    predkosc.Z += wyciszacz - pom;
                }
                else
                {
                    predkosc.Z += wyciszacz;
                }
            }
            else
            {
                if (predkosc.Z > 0)
                {
                    if (predkosc.Z - wyciszacz < 0)
                    {
                        pom = predkosc.Z - wyciszacz;
                        predkosc.Z -= wyciszacz + pom;
                    }
                    else
                    {
                        predkosc.Z -= wyciszacz;
                    }
                }
            }




        }

        public void wycisz_predkosc_only_XZ_o(float wyciszacz)
        {
            float pom;
            if (predkosc.X < 0)
            {
                if (predkosc.X + wyciszacz > 0)
                {
                    pom = predkosc.X + wyciszacz;
                    predkosc.X += wyciszacz - pom;
                }
                else
                {
                    predkosc.X += wyciszacz;
                }
            }
            else
            {
                if (predkosc.X > 0)
                {
                    if (predkosc.X - wyciszacz < 0)
                    {
                        pom = predkosc.X - wyciszacz;
                        predkosc.X -= wyciszacz + pom;
                    }
                    else
                    {
                        predkosc.X -= wyciszacz;
                    }
                }
            }

            if (predkosc.Z < 0)
            {
                if (predkosc.Z + wyciszacz > 0)
                {
                    pom = predkosc.Z + wyciszacz;
                    predkosc.Z += wyciszacz - pom;
                }
                else
                {
                    predkosc.Z += wyciszacz;
                }
            }
            else
            {
                if (predkosc.Z > 0)
                {
                    if (predkosc.Z - wyciszacz < 0)
                    {
                        pom = predkosc.Z - wyciszacz;
                        predkosc.Z -= wyciszacz + pom;
                    }
                    else
                    {
                        predkosc.Z -= wyciszacz;
                    }
                }
            }
        }



       public double daj_kat_kwadrata()
       {
       //    predkosc.X = 1.0f;
     //      predkosc.Y = -0.01f;
           double tangens = ( predkosc.Y /  predkosc.X );
          
         Debug.WriteLine("tangens kwadrata" + RadianToDegree(Math.Tan(tangens)).ToString());
         Debug.WriteLine("x i y kw" + predkosc.X.ToString() + " " + predkosc.Y.ToString());
         Debug.WriteLine("arc tang" + RadianToDegree(Math.Atan2(predkosc.Y,predkosc.X)).ToString());
         return RadianToDegree(Math.Atan2(predkosc.Y, predkosc.X));
       }


       private double RadianToDegree(double angle)
       {
           return angle * (180.0 / Math.PI);
       }



    }
}
