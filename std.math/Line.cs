using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace std.math
{
    public class Line
    {
        public static Double Eps = 1e-3;
        public Vertex Direction;
        public Vertex Point;

        public Line(Vertex direction, Vertex point)
        {
            Direction = direction;
            Point = point;
        }

        public Vertex Proj2d(Vertex v)
        {
            double vx = (v.X - Point.X);
            double vy = (v.Y - Point.Y);
            double bq = (Direction.X * vx + Direction.Y * vy) / ((Direction.X * Direction.X) + (Direction.Y * Direction.Y));
            return new Vertex(Point.X + bq * Direction.X, Point.Y + bq * Direction.Y, Point.Z + bq * Direction.Z);
        }

        public Boolean Cross2d(Line L, ref Vertex Res)
        {
            Vertex d1 = new Vertex(Direction.X, Direction.Y);
            Vertex d2 = new Vertex(-L.Direction.X, -L.Direction.Y);
            Double Dv = d2.Y * d1.X - d2.X * d1.Y;
            if (Math.Abs(Dv) < Eps * Eps) return false;
            Double Ml = (d2.Y * (L.Point.X - Point.X) - d2.X * (L.Point.Y - Point.Y)) / Dv;
            Res = new Vertex();
            Res.X = Point.X + d1.X * Ml;
            Res.Y = Point.Y + d1.Y * Ml;
            Res.Z = Point.Z + Direction.Z * Ml;
            return true;
        }
    }
}
