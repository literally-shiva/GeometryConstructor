using Avalonia;
using System.Collections.Generic;

namespace GeometryConstructor.Models.Figures
{
    public class GeometricQuadrangle : GeometricPolygon
    {
        public GeometricQuadrangle(Point a, Point b, Point c, Point d)
        {
            Points = [a, b, c, d, a];
        }
    }
}
