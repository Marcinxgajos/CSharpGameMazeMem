using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;

namespace GlSharpGame
{
    class Rysownik
    {
        public OpenGL gl;
        public Rysownik()
        {
 
        }
        public Rysownik(OpenGL gll)
        {
            gl = gll;
        }

        public void DrawCubo(float x1, float y1, float z1, float x2, float y2, float z2)
        {
            
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

        public void DrawCubo(float x1, float y1, float z1, float x2, float y2, float z2,float angle)
        {

            gl.PushMatrix();
           
            gl.Translate(x1, y1, z1);
            gl.Rotate(angle, 0.0f, 1.0f, 0.0f);
            gl.Translate(-x1, -y1, -z1);
           // gl.r
            gl.Begin(OpenGL.GL_QUADS);
            float halfX;
            float halfY;
            float halfZ;
            halfX = x2 / 2;
            halfY = y2 / 2;
            halfZ = z2 / 2;
            gl.Color(0.17f, 0.22f, 0.19f);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            //

            gl.Color(0.19f, 0.22f, 0.22f);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);


            gl.Color(0.21f, 0.18f, 0.22f);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 - halfZ);


            gl.Color(0.25f, 0.16f, 0.18f);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 - halfZ);


            gl.Color(0.22f, 0.22f, 0.19f);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);


            //spodu nima

            gl.End();

          //  gl.Rotate(angle, 0.0f, 1.0f, 0.0f);

            gl.PopMatrix();
        }


        public void DrawCubo_with_alpha(float x1, float y1, float z1, float x2, float y2, float z2, float angle,float alpha)
        {
            gl.DepthMask(0);
            gl.PushMatrix();

            gl.Translate(x1, y1, z1);
            gl.Rotate(angle, 0.0f, 1.0f, 0.0f);
            gl.Translate(-x1, -y1, -z1);
            // gl.r
            gl.Begin(OpenGL.GL_QUADS);
            float halfX;
            float halfY;
            float halfZ;
            halfX = x2 / 2;
            halfY = y2 / 2;
            halfZ = z2 / 2;
            gl.Color(0.17f, 0.22f, 0.19f,alpha);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            //

            gl.Color(0.19f, 0.22f, 0.22f, alpha);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);


            gl.Color(0.21f, 0.18f, 0.22f, alpha);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 - halfZ);


            gl.Color(0.25f, 0.16f, 0.18f, alpha);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 - halfZ);


            gl.Color(0.22f, 0.22f, 0.19f, alpha);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);


            //spodu nima

            gl.End();

            //  gl.Rotate(angle, 0.0f, 1.0f, 0.0f);

            gl.PopMatrix();
            gl.DepthMask(1);
        }



        public void DrawPlayer(Wektor polozenie,Wektor grubosci,float Angle)
        {
            DrawCubo(polozenie.X, polozenie.Y, polozenie.Z, grubosci.X, grubosci.Y, grubosci.Z, Angle);
            gl.PushMatrix();
          //  gl.Translate(polozenie.X + grubosci.X, 0, 0);
            DrawCubo(polozenie.X + grubosci.X, polozenie.Y, polozenie.Z,
                grubosci.X / 2, grubosci.Y / 2, grubosci.Z / 2, Angle);
            gl.PopMatrix();

        }
        public void DrawCubo(float x1, float y1, float z1, float x2, float y2, float z2, double angle)
        {

            gl.PushMatrix();

            gl.Translate(x1, y1, z1);
            gl.Rotate(angle, 0.0f, 1.0f, 0.0f);
            gl.Translate(-x1, -y1, -z1);
            // gl.r
            DrawCubo(x1-x2, y1, z1, x2 / 2, y2 / 2, z2 / 3, 0);
            gl.Begin(OpenGL.GL_QUADS);
            float halfX;
            float halfY;
            float halfZ;
            halfX = x2 / 2;
            halfY = y2 / 2;
            halfZ = z2 / 2;
            gl.Color(0.17f, 0.22f, 0.19f);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            //

            gl.Color(0.19f, 0.22f, 0.22f);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);


            gl.Color(0.21f, 0.18f, 0.22f);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 - halfZ);


            gl.Color(0.25f, 0.16f, 0.18f);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 - halfZ);


            gl.Color(0.22f, 0.22f, 0.19f);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);


            //spodu nima

            gl.End();

            //  gl.Rotate(angle, 0.0f, 1.0f, 0.0f);

            gl.PopMatrix();
        }
     //   rysow.DrawCubo(cuboPlayer.polozenie.X, cuboPlayer.polozenie.Y, cuboPlayer.polozenie.Z,
     //           cuboPlayer.grubosci.X, cuboPlayer.grubosci.Y, cuboPlayer.grubosci.Z,
     //           Angle_of_Player);
        public void DrawPlayer(Wektor polozenie, Wektor grubosci, double angle)
        {
            float x2, y2, z2;
            x2 = grubosci.X;
            y2 = grubosci.Y;
            z2 = grubosci.Z;
            gl.PushMatrix();

            gl.Translate(polozenie.X, polozenie.Y, polozenie.Z);
            gl.Rotate(angle, 0.0f, 1.0f, 0.0f);
            gl.Translate(-polozenie.X, -polozenie.Y, -polozenie.Z);
            // gl.r
            DrawCubo(polozenie.X - grubosci.X, polozenie.Y, polozenie.Z, grubosci.X / 2, grubosci.Y / 2, grubosci.Z / 3, 0);

            gl.Begin(OpenGL.GL_QUADS);
            float halfX,x1;
            float halfY,y1;
            float halfZ,z1;
            x1 = polozenie.X;
            y1 = polozenie.Y;
            z1 = polozenie.Z;
            halfX = x2 / 2;
            halfY = y2 / 2;
            halfZ = z2 / 2;
            gl.Color(0.17f, 0.22f, 0.19f);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            //

            gl.Color(0.19f, 0.22f, 0.22f);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);


            gl.Color(0.21f, 0.18f, 0.22f);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 - halfZ);


            gl.Color(0.25f, 0.16f, 0.18f);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 - halfZ);


            gl.Color(0.22f, 0.22f, 0.19f);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);


            //spodu nima

            gl.End();

            //  gl.Rotate(angle, 0.0f, 1.0f, 0.0f);

            gl.PopMatrix();
        }
        public void DrawCubo(float x1, float y1, float z1, float x2, float y2, float z2, float angle,bool czy_pocisk)
        {
            if (czy_pocisk) { }
            gl.PushMatrix();

            gl.Translate(x1, y1, z1);
            gl.Rotate(angle, 0.0f, 1.0f, 0.0f);
            gl.Translate(-x1, -y1, -z1);
            // gl.r
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

            //  gl.Rotate(angle, 0.0f, 1.0f, 0.0f);

            gl.PopMatrix();
        }
        public void DrawCubo(float x1, float y1, float z1, float x2, float y2, float z2, float angle, bool czy_pocisk,float alpha)
        {
            if (czy_pocisk) { }
            gl.PushMatrix();

            gl.Translate(x1, y1, z1);
            gl.Rotate(angle, 0.0f, 1.0f, 0.0f);
            gl.Translate(-x1, -y1, -z1);
            // gl.r
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

            gl.Color(0.65f, 0.22f, 0.0f, alpha);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);


            gl.Color(0.62f, 0.18f, 0.0f, alpha);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 - halfZ);


            gl.Color(0.55f, 0.16f, 0.0f, alpha);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 - halfZ);


            gl.Color(0.72f, 0.22f, 0.0f, alpha);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);


            //spodu nima

            gl.End();

            //  gl.Rotate(angle, 0.0f, 1.0f, 0.0f);

            gl.PopMatrix();
        }


        public void DrawLive(Wektor polozenie,Wektor grubosci,int Live)
        {
            gl.PushMatrix();
            gl.Begin(OpenGL.GL_QUADS);
            Wektor Cursor;
            float halfX;
            float halfY;
            float halfZ;
            halfX = grubosci.X / 2;
            halfY = grubosci.Y / 2;
            halfZ = grubosci.Z / 2;
            Cursor = polozenie;
            for (int i = 0; i < Live; i++)
            {
                gl.Color(0.65f, 0.01f*i, 0.0f);
                gl.Vertex(Cursor.X - halfX, Cursor.Y - halfY, Cursor.Z + halfZ);
                gl.Vertex(Cursor.X + halfX, Cursor.Y - halfY, Cursor.Z + halfZ);
                gl.Vertex(Cursor.X + halfX, Cursor.Y + halfY, Cursor.Z + halfZ);
                gl.Vertex(Cursor.X - halfX, Cursor.Y + halfY, Cursor.Z + halfZ);
                Cursor.Y += grubosci.Y+ grubosci.Y/12;
            }
            gl.End();
            gl.PopMatrix();
        }


        public void DrawCubo(float x1, float y1, float z1, float x2, float y2, float z2, float angle, int czy_boss)
        {
            //if (czy_pocisk) { }
            gl.PushMatrix();

            gl.Translate(x1, y1, z1);
            gl.Rotate(angle, 0.0f, 1.0f, 0.0f);
            gl.Translate(-x1, -y1, -z1);
            // gl.r
            gl.Begin(OpenGL.GL_QUADS);
            float halfX;
            float halfY;
            float halfZ;
            halfX = x2 / 2;
            halfY = y2 / 2;
            halfZ = z2 / 2;
            gl.Color(0.7f, 0.8f, 0.0f);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            //

            gl.Color(0.65f, 0.72f, 0.0f);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);


            gl.Color(0.62f, 0.65f, 0.0f);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 - halfY, z1 - halfZ);


            gl.Color(0.55f, 0.61f, 0.0f);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 + halfZ);
            gl.Vertex(x1 - halfX, y1 - halfY, z1 - halfZ);


            gl.Color(0.72f, 0.62f, 0.0f);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 - halfZ);
            gl.Vertex(x1 - halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 + halfZ);
            gl.Vertex(x1 + halfX, y1 + halfY, z1 - halfZ);


            //spodu nima

            gl.End();

            //  gl.Rotate(angle, 0.0f, 1.0f, 0.0f);

            gl.PopMatrix();
        }
        public void draw_floor()
        {
            gl.PushMatrix();

          //     gl.DepthMask(0);
            // gl.r
            gl.Begin(OpenGL.GL_LINES);
            float halfX;
            float halfY;
            float halfZ;
            halfX = 0.25f;
            halfY = 0.25f;
            halfZ = 0.25f;
            Wektor kursor;
            kursor = new Wektor(-5.0f,-0.5f,-6.0f);
            for (int i = 0; i < 40; i++)
            {

                if (i % 2 == 0)
                {
                    gl.Color(0.6f, 0.6f, 0.6f,0.5f);
                }
                else
                {
                    gl.Color(0.4f, 0.4f, 0.4f,0.5f);
                }
                gl.Vertex(kursor.X, kursor.Y, kursor.Z);
                gl.Vertex(kursor.X, kursor.Y, kursor.Z + 12.0f);
                kursor.X += halfX;
            }
          
            gl.Vertex(kursor.X, kursor.Y, kursor.Z);
            gl.Vertex(kursor.X, kursor.Y, kursor.Z + 12.0f);

            kursor = new Wektor(-5.0f, -0.5f, -6.0f);


            for (int i = 0; i < 48; i++)
            {

                if (i % 2 == 0)
                {
                    gl.Color(0.6f, 0.6f, 0.6f,0.5f);
                }
                else
                {
                    gl.Color(0.4f, 0.4f, 0.4f,0.5f);
                }
                gl.Vertex(kursor.X, kursor.Y, kursor.Z);
                gl.Vertex(kursor.X+10.0f, kursor.Y, kursor.Z);
                kursor.Z += halfZ;
            }
         
            gl.Vertex(kursor.X, kursor.Y, kursor.Z);
            gl.Vertex(kursor.X + 10.0f, kursor.Y, kursor.Z);
       //        gl.DepthMask(0);
            gl.End();
            gl.PopMatrix();
        }

    }
}
