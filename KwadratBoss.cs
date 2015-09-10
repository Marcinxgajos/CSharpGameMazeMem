using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlSharpGame
{
     class KwadratBoss : kwardratMaterialny
    {
        public float waga;
        public int counter;
        public Wektor polozenie;
        public Wektor predkosc;
        public Wektor grubosci;
        public Wektor kolor;
        public double angle;
        public int Live;


        public KwadratBoss(bool czy_losowy)
        {
            Live = 16;
            counter = 0;

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
                Wektor temp;
                temp = new Wektor((float)x, (float)y, (float)z);
                temp = temp * 10.0f;
                polozenie = temp;
                x = rand.NextDouble();
                x -= 0.5;
                y = rand.NextDouble();
                y = 0.0;
                z = rand.NextDouble();
                z -= 0.5;
               // Wektor temp;
                temp = new Wektor((float)x, (float)y, (float)z);
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
            bool on_wall;
            on_wall = false;

            if (polozenie.X + predkosc.X > 5.0f)
            {
                predkosc.X = 0;
                on_wall = true;
             
            }

            if (polozenie.X + predkosc.X < -5.0f)
            {
                predkosc.X = 0;
                on_wall = true;
            }

            if (polozenie.Y + predkosc.Y > 6.0f)
            {
                predkosc.Y = 0;
                on_wall = true;
            }

            if (polozenie.Y + predkosc.Y < -6.0f)
            {
                predkosc.Y = 0;
                on_wall = true;
            }


            if (polozenie.Z + predkosc.Z > 6.0f)
            {
                predkosc.Z = 0;
                on_wall = true;
            }

            if (polozenie.Z + predkosc.Z < -6.0f)
            {
                predkosc.Z = 0;
                on_wall = true;
            }




            polozenie = polozenie + predkosc; 

            if(counter % 30 == 0)
            {
                Random rand;
                rand = new Random();
                double x = rand.NextDouble();
                x -= 0.5;
                double y = rand.NextDouble();
                y = 0.0;
                double z = rand.NextDouble();
                z -= 0.5;
                Wektor temp;
                temp = new Wektor((float)x, (float)y, (float)z);
                temp = temp * 0.1f;
                predkosc = temp;
            }

            counter++;
        }


    }
}
