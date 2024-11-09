using Avalonia;
using System.Collections.Generic;

namespace GeometryConstructor.Models.Figures
{
    public abstract class GeometricFigure
    {
        public Point Center { get; set; }
        public List<Point> Points { get; set; } = new List<Point>();
    }
}
