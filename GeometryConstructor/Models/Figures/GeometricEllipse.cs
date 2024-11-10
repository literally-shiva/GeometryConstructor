using Avalonia;
using System.Collections.Generic;
using static System.Math;

namespace GeometryConstructor.Models.Figures
{
    public class GeometricEllipse : GeometricFigure
    {
        public Point Center { get; set; }
        public double XSemiAxis { get; set; }
        public double YSemiAxis { get; set; }
        public int Smoothness { get; set; } = 36;

        public GeometricEllipse(Point center, double xSemiAxis, double ySemiAxis)
        {
            Center = center;
            XSemiAxis = xSemiAxis;
            YSemiAxis = ySemiAxis;
            Points = GetPoints();
        }

        protected virtual List<Point> GetPoints()
        {
            List<Point> points = new List<Point>();

            for (double t = 0; t <= 2 * PI; t += 2.0 * PI / Smoothness)
            {
                points.Add(new Point(Center.X - XSemiAxis * Cos(t), Center.Y - YSemiAxis * Sin(t)));
            }

            return points;
        }
    }
}
