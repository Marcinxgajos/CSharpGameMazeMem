using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace GlSharpGame
{
    class SprawdzaczKolizji
    {
        public Rysownik rysow;
       public SprawdzaczKolizji(Rysownik rys)
        {
           rysow = rys;
        }
      //  public SprawdzaczKolizji
   // public setUpGl()
       public bool CzyNieKoliduje(List<Wektor> ListaKolizji,float margines,Wektor KolidujacyWek)
        {
            margines *= 2;
            for(int i=0;i<ListaKolizji.Count;i++)
            {
                if(ListaKolizji.ElementAt(i).X - margines < KolidujacyWek.X && ListaKolizji.ElementAt(i).X + margines > KolidujacyWek.X)
                {
                  //  Debug.Write("jest w x");
                    
 if (ListaKolizji.ElementAt(i).Z - margines < KolidujacyWek.Z && ListaKolizji.ElementAt(i).Z + margines > KolidujacyWek.Z)
                    {
                        
               //         Debug.Write("jest w X i Y");

                        Wektor temp = ListaKolizji.ElementAt(i);
                        rysow.DrawCubo(ListaKolizji.ElementAt(i).X,
                            ListaKolizji.ElementAt(i).Y,
                            ListaKolizji.ElementAt(i).Z,
                            0.1f, 0.1f, 0.1f);
                        rysow.DrawCubo(temp.X - margines, temp.Y, temp.Z, 0.1f, 0.1f, 0.1f);
                        rysow.DrawCubo(temp.X + margines, temp.Y, temp.Z, 0.1f, 0.1f, 0.1f);
                        rysow.DrawCubo(temp.X , temp.Y, temp.Z+ margines, 0.1f, 0.1f, 0.1f);
                        rysow.DrawCubo(temp.X , temp.Y, temp.Z - margines, 0.1f, 0.1f, 0.1f);

                        return true;
                    }
                }

            }
            return false;
        }

    
       public bool CzyJestW(List<Wektor> ListaWektorow, float margin, Wektor Center)
       {
          // Debug.Write("dsada");
           float Distance; //= sqrt(pow((pointvect[i].y - pointvect[i + 1].y), 2) + pow((pointvect[i].x - pointvect[i + 1].x), 2));
           for (int i = 0; i < ListaWektorow.Count; i++)
           {
         //      Debug.Write("fdfff");
               Distance = (float)Math.Sqrt(Math.Pow((ListaWektorow.ElementAt(i).Z - Center.Z), 2)
                   + (Math.Pow((ListaWektorow.ElementAt(i).X - Center.X), 2)));
               if(Distance < margin)
               {
                   return true;
               }
           }
           return false;

       }
       public bool CzyNieKoliduje(List<float> ListaKolizjiX,List<float> ListaKolizjiZ, float margines, Wektor KolidujacyWek)
       {
           Debug.WriteLine("wpadam?");
           for (int i = 0; i < ListaKolizjiX.Count; i++)
           {
               Debug.Write("x");
               if (ListaKolizjiX.ElementAt(i)- margines < KolidujacyWek.X && ListaKolizjiX.ElementAt(i) + margines > KolidujacyWek.X)
               {
                   if (ListaKolizjiZ.ElementAt(i) - margines < KolidujacyWek.Z && ListaKolizjiZ.ElementAt(i) + margines > KolidujacyWek.Z)
                   {
                       return true;
                   }
               }

           }
           return false;
       }
    }
}
