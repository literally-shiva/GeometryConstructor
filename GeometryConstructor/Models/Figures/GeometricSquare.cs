using Avalonia;

namespace GeometryConstructor.Models.Figures
{
    internal class GeometricSquare : GeometricQuadrangle
    {
        public Point Center { get; set; }
        public double SideLength;

        public GeometricSquare(Point center, double sideLength) : base(
            new Point(center.X - sideLength / 2, center.Y + sideLength / 2),
            new Point(center.X + sideLength / 2, center.Y + sideLength / 2),
            new Point(center.X + sideLength / 2, center.Y - sideLength / 2),
            new Point(center.X - sideLength / 2, center.Y - sideLength / 2))
        {
            Center = center;
            SideLength = sideLength;
        }
    }
}
