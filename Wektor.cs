using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GlSharpGame
{
    class Wektor
    {
        
        //pola
        public float X,Y,Z,W;
        public Wektor()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
            this.W = 1;
        }
        public Wektor(float X,float Y,float Z)           
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            this.W = 1;
        }

        public static bool operator == (Wektor lhs, Wektor rhs)
            {
         bool status = false;
         if (lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z)
         {
            status = true;
         }
         return status;
        }


        public static bool operator !=(Wektor lhs, Wektor rhs)
        {
            bool status = false;
            if (lhs.X != rhs.X || lhs.Y != rhs.Y || lhs.Z != rhs.Z)
            {
                status = true;
            }
            return status;
        }
      
        public override int GetHashCode()
    {
       return 0;
    }
        public override bool Equals(object obj)
        {
            //1. sprawdzenie czy obiekt nie jest nullem
            if (obj == null)
            {
                return false;
            }

            //2. sprawdzenie czy porównujemy obiekty tego samego typu
            var point = obj as Wektor;
            if (point == null)
            {
                return false;
            }

            //3. porównanie zawartości obiektu
            return point.X == X && point.Y == Y  && point.Z == Z;
        }

        
        public static Wektor operator+ (Wektor b, Wektor c)
      {
         Wektor box = new Wektor();
         box.X = b.X + c.X;
         box.Y = b.Y + c.Y;
         box.Z = b.Z + c.Z;
         return box;
      }

        public static Wektor operator- (Wektor b, Wektor c)
        {
            Wektor box = new Wektor();
            box.X = b.X - c.X;
            box.Y = b.Y - c.Y;
            box.Z = b.Z - c.Z;
            return box;
        }


         public Wektor Clone()
    {
        MemoryStream ms = new MemoryStream();
        BinaryFormatter bf = new BinaryFormatter();

        bf.Serialize(ms, this);

        ms.Position = 0;
        object obj = bf.Deserialize(ms);
        ms.Close();

        return obj as Wektor;
    }


       public static Wektor operator *(Wektor m1, float c)
    {
    //not sure what your "copy" method is
           m1.X *= c;
           m1.Y *= c;
           m1.Z *= c;
    //do the multiplication on ret

    return m1;
    }

       public static Wektor operator *(Wektor b, Wektor c)
       {
           Wektor box = new Wektor();

           box.X = b.X * c.X;
           box.Y = b.Y * c.Y;
           box.Z = b.Z * c.Z;
           return box;
       }


       








    }//class wektor
}
