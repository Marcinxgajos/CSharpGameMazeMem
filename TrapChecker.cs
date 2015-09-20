using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlSharpGame
{

    class TrapChecker
    {
        public Coord in_what_coord(float x_cord, float z_cord, float basic_weight)
        {
            Coord intssa;
            intssa = new Coord();
            x_cord /= 6;
            x_cord = (float)Math.Round(x_cord);
            z_cord /= 6;
            z_cord = (float)Math.Round(z_cord);

            intssa.x = (int)x_cord;
            intssa.y = (int)z_cord;

            return intssa;
        }


        

        public bool is_three_cell_far(int[][] tab,int x,int y)
        {
            int i;
            for(i=1;i<4;)
            {
                if((tab[x][y+i]%100)/10==1)
                {
                    i++;
                }
                else
                {
                    return false;
                }



            }
            return true;
        }

        
        
    }

}
