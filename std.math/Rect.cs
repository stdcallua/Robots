using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace std.math
{
    public class Rect
    {
        public Vertex A { get; set; }
        public Vertex B { get; set; }

        public Boolean VertexesIn(Vertexes V)
        { 
            for (Int32 i = 0; i < V.Count; i++)
                if (VertexIn(V[i])) return true;
            return false;
        }
        public Boolean VertexIn(Vertex V)
        {
            return ((A.X <= V.X) & (B.X >= V.X) & (A.Y >= V.Y) & (B.Y <= V.Y));
        }

        public Rect(Vertex a, Vertex b)
        {
            A = a;
            B = b;
        }
    }
}
