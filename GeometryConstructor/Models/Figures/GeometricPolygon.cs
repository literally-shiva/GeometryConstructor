using Avalonia;
using System.Collections.Generic;
using System.Linq;

namespace GeometryConstructor.Models.Figures
{
    public abstract class GeometricPolygon : GeometricFigure
    {
        public GeometricPolygon(params Point[] points)
        {
            Points = points.ToList();
        }
        public GeometricPolygon(List<Point> points)
        {
            Points = points;
        }
    }
}
