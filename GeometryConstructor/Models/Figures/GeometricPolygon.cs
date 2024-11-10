using Avalonia;
using System.Collections.Generic;
using System.Linq;

namespace GeometryConstructor.Models.Figures
{
    public class GeometricPolygon : GeometricFigure
    {
        public GeometricPolygon()
        {

        }
        public GeometricPolygon(params Point[] points)
        {
            Points = points.ToList();
            Points.Add(points[0]);
        }
        public GeometricPolygon(List<Point> points)
        {
            Points = points;
            Points.Add(points[0]);
        }
    }
}
