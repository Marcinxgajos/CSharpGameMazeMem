using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlSharpGame
{
    class KwadratMaterialnyPocisk : kwardratMaterialny
    {
       public int vitality;
        float dlugoscScianyX;
        float dlugoscScianyY;
        float dlugoscScianyZ;
        public KwadratMaterialnyPocisk(Wektor Wektor_polozenia,Wektor Wektor_predkosci,double kat)
        {
            vitality = 6;
            dlugoscScianyX = 5.0f;
            dlugoscScianyY = 6.0f;
            dlugoscScianyZ = 6.0f;
            polozenie = Wektor_polozenia;
            predkosc = Wektor_predkosci;
            grubosci = new Wektor(0.1f,0.1f,0.1f);
            kolor = new Wektor(0.1f, 0.1f, 0.1f);
            waga = 2f;
            angle = kat;
        }
        public KwadratMaterialnyPocisk(Wektor Wektor_polozenia, Wektor Wektor_predkosci, double kat, bool is_Player)
        {
            vitality = 6;
            dlugoscScianyX = 5.0f;
            dlugoscScianyY = 6.0f;
            dlugoscScianyZ = 6.0f;
            polozenie = Wektor_polozenia;
            predkosc = Wektor_predkosci;
            grubosci = new Wektor(0.1f, 0.1f, 0.1f);
            kolor = new Wektor(0.3f, 0.5f, 0.4f);
            waga = 2f;
            angle = kat;
        }

        public KwadratMaterialnyPocisk(Wektor Wektor_polozenia,double kat)
        {
            vitality = 6;
            dlugoscScianyX = 5.0f;
            dlugoscScianyY = 6.0f;
            dlugoscScianyZ = 6.0f;
            polozenie = Wektor_polozenia;
            Random rand;
            rand = new Random();
            double x = rand.NextDouble();
            x -= 0.5;
            double y = rand.NextDouble();
            y = 0;
            double z = rand.NextDouble();
            z -= 0.5;
            Wektor temp;
            temp = new Wektor((float)x, (float)y, (float)z);
            temp = temp * 0.3f;
          
            predkosc = temp;
            grubosci = new Wektor(0.1f, 0.1f, 0.1f);
            kolor = new Wektor(0.1f, 0.1f, 0.1f);
            waga = 2f;

            angle = (double)rand.Next(360);
        }




        public void krok_naprzod()
        {
            if(polozenie.X + predkosc.X > dlugoscScianyX )
            {
                predkosc.X *= -1;
                vitality--;
            }

            if(polozenie.X + predkosc.X < -dlugoscScianyX)
            {
                predkosc.X *= -1;
                vitality--;
            }

            if(polozenie.Y + predkosc.Y > dlugoscScianyY )
            {
                predkosc.Y *= -1;
                vitality--;
            }

            if(polozenie.Y + predkosc.Y < -dlugoscScianyY )
            {
                predkosc.Y *= -1;
                vitality--;
            }


            if(polozenie.Z + predkosc.Z > dlugoscScianyZ)
            {
                predkosc.Z *= -1;
                vitality--;
            }

            if(polozenie.Z + predkosc.Z < -dlugoscScianyZ)
            {
                predkosc.Z *= -1;
                vitality--;
            }

            polozenie = polozenie + predkosc;

          
           

        }

      

    }
}
