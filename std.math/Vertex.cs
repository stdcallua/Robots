using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace std.math
{
    public class Vertex
    {
        public Double X, Y, Z;

        //Конструкторы
        public Vertex()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vertex(Double x, Double y)
        {
            X = x;
            Y = y;
            Z = 0;
        }

        public Vertex(Double x, Double y, Double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        //опрераторы

        public Boolean Equal(Vertex V)
        { 
            Double eps = 0.01;
            return ((Math.Abs(X - V.X)<eps)&((Math.Abs(Y - V.Y)<eps)));
        }

        public static Vertex operator +(Vertex A, Vertex B)
        {
            return new Vertex(A.X + B.X, A.Y + B.Y, A.Z + B.Z);
        }
        public static Vertex operator -(Vertex A, Vertex B)
        {
            return new Vertex(A.X - B.X, A.Y - B.Y, A.Z - B.Z);
        }
        public static Vertex operator *(Vertex A, Double B)
        {
            return new Vertex(A.X * B, A.Y * B, A.Z * B);
        }
        public static Vertex operator *(Double B, Vertex A)
        {
            return new Vertex(A.X * B, A.Y * B, A.Z * B);
        }
        public static Vertex operator /(Vertex A, Double B)
        {
            return new Vertex(A.X / B, A.Y / B, A.Z / B);
        }
        public static Vertex operator /(Vertex A, Vertex B)
        {
            return new Vertex(A.X / B.X, A.Y / B.X, A.Z / B.Z);
        }
        public Vertex Normalize()
        {
            return this / Math.Sqrt(X * X + Y * Y + Z * Z);
        }
        public Vertex Normalize(out Double Length)
        {
            Length = Math.Sqrt(X * X + Y * Y + Z * Z);
            return this / Length;
        }

        public Vertex Round()
        {
            return new Vertex(Math.Round(X), Math.Round(Y), Math.Round(Z));
        }

        public Double LengthTo(Vertex V)
        {
            return (this - V).Length();
        }

        public Double Length()
        {
            return System.Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public Vertex Clone()
        {
            return new Vertex(X, Y, Z);
        }

        public Vertex RotateZ(Double Angle)
        { 
            Double S = Math.Sin(Angle);
            Double C = Math.Cos(Angle);
            Vertex Result = new Vertex();  
            Result.X =  X * C + Y * S;
            Result.Y = -X * S + Y * C;
            Result.Z =  Z;
            return Result;
        }


    }
}
