using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidsemesterProject_ShaiMaytav
{
    public struct Vector2
    {
        public float x { get; set; }
        public float y { get; set; }

        public Vector2(float X, float Y)
        {
            x = X;
            y = Y;
        }

        public Vector2(Vector2 v)
        {
            x = v.x;
            y = v.y;
        }
        void Add(Vector2 toAdd)
        {
            x += toAdd.x;
            y += toAdd.y;
        }
        
        void Subtract(Vector2 toSub)
        {
            x -= toSub.x;
            y -= toSub.y;
        }  

        void DotProduct(Vector2 toSub)
        {
            x *= toSub.x;
            y *= toSub.y;
        }

        Vector2 Normalize()
        {
            double angle = Math.Atan(y / x);
            double a = Math.Sin(angle);
            double b = Math.Cos(angle);

            return new Vector2((float)b , (float)a);
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
    }
}
