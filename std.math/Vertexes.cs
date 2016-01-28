using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace std.math
{
    public class Vertexes
    {
        private Vertex[] m_Items;

        public Vertex this[Int32 Index]
        {
            get { return m_Items[Index]; }
            set { m_Items[Index] = value; }
        }
        public Int32 Count
        {
            set { Array.Resize(ref m_Items, value); }
            get { return m_Items.Length; }
        }

        public Int32 Add(Vertex vertex)
        {
            Int32 C = Count;
            Count++;
            m_Items[C] = vertex;
            return C;
        }

        public Vertexes Clone()
        {
            Vertexes Result = new Vertexes();
            Result.Count = Count;
            for (Int32 i = 0; i < Count; i++)
                Result[i] = this[i].Clone();
            return Result;
        }

        public Vertexes GetRange2d(Double BeginLen, Double EndLen)
        {
            Vertexes Res = new Vertexes();
            Double SumLen = 0.0;
            Double Begin = Math.Min(BeginLen, EndLen);
            Double End = Math.Max(BeginLen, EndLen);
            Double CurL;
            Boolean BeginUsed = false;
            for (Int32 i = 0; i < Count - 1; i++)
            {
                if (BeginUsed) Res.Add(this[i]);
                Vertex Vect = (this[i + 1] - this[i]).Normalize(out CurL);
                if (!BeginUsed && (CurL + SumLen > Begin))
                {
                    BeginUsed = true;
                    Res.Add(this[i] + Vect * (CurL + SumLen - Begin));
                }
                if (BeginUsed && (CurL + SumLen > End))
                {
                    Res.Add(this[i] + Vect * (CurL + SumLen - End));
                    break;
                }
                SumLen += CurL;
            }
            if (!BeginUsed) return null;
            return Res;
        }

        public Vertexes DeleteDuplicates()
        {
            Int32 n = 0;
            Vertexes Result = new Vertexes();
            Result.Count = Count;
            Boolean[] B = new Boolean[Count];
            for (Int32 i = 0; i < Count; i++)
                if (!B[i])
                {
                    for (Int32 j = i + 1; j < Count; j++)
                       if (this[i].Equal(this[j])) B[j] = true;
                    Result[n] = this[i];
                    n++;
                }
            Result.Count = n;
            return Result;
        }

        public Vertexes Smooth(Double step)
        {
            Vertexes Result = new Vertexes();
            List<Double> Dists = new List<Double>();
            Dists.Add(0);
            for (Int32 i = 1; i < Count; i++)
               Dists.Add(Dists[i-1]+this[i-1].LengthTo(this[i]));
            Int32 m = (Int32)(Dists[Dists.Count-1]/step) + 1;
            for (Int32 i = 1; i <= m; i++)
            {
                Double Len = i * step;
                for (Int32 j = 1; j < Count; j++)
                {
                    if (Dists[j] < Len) continue;
                    Vertex Vect = (this[j] - this[j-1]).Normalize();
                    Result.Add(this[j-1] + Vect * (Len - Dists[j-1]));
                    break;
                }
            }
           return Result;
        }

        public Vertexes Offset(Double Dist)
        {
            Vertexes Result = new Vertexes();
            Line PrevLine = null;
            for (Int32 i = 0; i < Count; i++)
            {
                Line Line = null;
                if (i == Count - 1)
                {
                    Vertex Vector = (this[i] - this[i-1]).Normalize();
                    Vector = Vector.RotateZ(Math.PI / 2) * Dist;
                    Result.Add(this[i] + Vector);
                    break;
                }
                if (i == 0)
                {
                    Vertex Vector = (this[i + 1] - this[i]).Normalize();
                    Vector = Vector.RotateZ(Math.PI/2) * Dist;
                    Result.Add(this[i] + Vector);
                    Line = new Line((this[i + 1] - this[i]).Normalize(), this[i] + Vector);
                }
                else
                {
                    Vertex Vector = (this[i + 1] - this[i]).Normalize();
                    Vector = Vector.RotateZ(Math.PI / 2) * Dist;
                    Line = new Line((this[i + 1] - this[i]).Normalize(), this[i] + Vector);
                    Vertex point = new Vertex();
                    if (Line.Cross2d(PrevLine, ref point))
                    {
                        Result.Add(point);
                    }
                }
                PrevLine = new Line(Line.Direction, Line.Point);
            }
            return Result;
        }

        public Double Length()
        {
            Double Result = 0;
            for (Int32 i = 0; i < Count - 1; i++)
                Result += this[i].LengthTo(this[i + 1]);
            return Result;
        }

        public Vertexes()
        {
            m_Items = new Vertex[0];
        }

        public Vertexes(Int32 count)
        {
            m_Items = new Vertex[count];
        }

    }
}
