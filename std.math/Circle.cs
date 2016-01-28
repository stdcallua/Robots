using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace std.math
{
    public class Circle: Vertexes
    {
        private Double m_Radius;

        public Double Radius
        {
            get { return m_Radius; }
        }

        public Circle(Double radius, Int32 PointCount): base(PointCount)
        {
            m_Radius = radius;
            Double AngleStep = 2*Math.PI / PointCount;
            Double Angle = 0;
            for (Int32 i = 0; i < PointCount; i++)
            {
                this[i] = new Vertex(Radius * Math.Cos(Angle), Radius * Math.Sin(Angle));
                Angle += AngleStep;
            }
        }
    }


}
