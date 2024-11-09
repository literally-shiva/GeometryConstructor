using Avalonia;
using System.Collections.Generic;

namespace GeometryConstructor.Models.Figures
{
    public class GeometricTriangle : GeometricPolygon
    {
        public GeometricTriangle(Point a, Point b, Point c)
        {
            Points = [a, b, c, a];
        }
    }
}
