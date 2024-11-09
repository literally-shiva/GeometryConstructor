using Avalonia;
using System.Collections.Generic;
using static System.Math;

namespace GeometryConstructor.Models.Figures
{
    public class GeometricCircle : GeometricEllipse
    {
        public double Radius { get; set; }

        public GeometricCircle(Point center, int radius) : base (center, radius / 2, radius / 2)
        {
            Radius = radius;
            Points = GetPoints();
        }

        public override List<Point> GetPoints()
        {
            List<Point> points = new List<Point>();

            for (double t = 0; t <= 2 * PI; t += 2.0 * PI / Smoothness)
            {
                points.Add(new Point(Center.X - Radius * Cos(t), Center.Y - Radius * Sin(t)));
            }

            return points;
        }
    }
}
