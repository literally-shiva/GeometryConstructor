using Avalonia;

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
    }
}
