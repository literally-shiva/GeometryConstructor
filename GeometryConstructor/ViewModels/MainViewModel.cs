using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using DynamicData;
using GeometryConstructor.Models.Figures;
using ReactiveUI;
using System.Reactive;

namespace GeometryConstructor.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ReactiveCommand<Canvas, Unit> DrawEllipseCommand { get; }
    public ReactiveCommand<Canvas, Unit> DrawCircleCommand { get; }
    public ReactiveCommand<Canvas, Unit> DrawTriangleCommand { get; }
    public ReactiveCommand<Canvas, Unit> DrawQuadrangleCommand { get; }
    public ReactiveCommand<Canvas, Unit> DrawSquareCommand { get; }
    public ReactiveCommand<Canvas, Unit> ClearCommand { get; }

    public MainViewModel()
    {
        DrawEllipseCommand = ReactiveCommand.Create<Canvas>(DrawEllipse);
        DrawCircleCommand = ReactiveCommand.Create<Canvas>(DrawCircle);
        DrawTriangleCommand = ReactiveCommand.Create<Canvas>(DrawTriangle);
        DrawQuadrangleCommand = ReactiveCommand.Create<Canvas>(DrawQuadrangle);
        DrawSquareCommand = ReactiveCommand.Create<Canvas>(DrawSquare);
        ClearCommand = ReactiveCommand.Create<Canvas>(Clear);
    }

    public void DrawEllipse(Canvas mainCanvas)
    {
        GeometricEllipse ellipse = new(new Point(150, 100), 100, 50);
        AddGeometricFigureToCanvas(ellipse, mainCanvas);
    }

    public void DrawCircle(Canvas mainCanvas)
    {
        GeometricCircle circle = new(new Point(350, 100), 50);
        AddGeometricFigureToCanvas(circle, mainCanvas);
    }

    public void DrawTriangle(Canvas mainCanvas)
    {
        GeometricTriangle triangle = new(new Point(200, 200), new Point(300, 200), new Point(200, 300));
        AddGeometricFigureToCanvas(triangle, mainCanvas);
    }

    public void DrawQuadrangle(Canvas mainCanvas)
    {
        GeometricQuadrangle quadrangle = new (new Point(350, 250), new Point(550, 200), new Point(550, 400), new Point(400, 450));
        AddGeometricFigureToCanvas(quadrangle, mainCanvas);
    }

    public void DrawSquare(Canvas mainCanvas)
    {
        GeometricSquare square = new(new Point(250, 500), 100);
        AddGeometricFigureToCanvas(square, mainCanvas);
    }

    public void Clear (Canvas mainCanvas)
    {
        mainCanvas.Children.Clear();
    }

    public void AddGeometricFigureToCanvas(GeometricFigure figure, Canvas canvas)
    {
        Polyline polyline = new Polyline()
        {
            StrokeThickness = 1,
            Stroke = Brushes.White
        };

        polyline.Points.Add(figure.Points);

        canvas.Children.Add(polyline);
    }
}
