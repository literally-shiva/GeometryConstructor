using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.VisualTree;
using DynamicData;
using GeometryConstructor.Models.Figures;
using GeometryConstructor.Views;
using ReactiveUI;
using System.Reactive;
using System.Threading.Tasks;

namespace GeometryConstructor.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ReactiveCommand<MainView, Unit> DrawEllipseCommand { get; }
    public ReactiveCommand<MainView, Unit> DrawCircleCommand { get; }
    public ReactiveCommand<MainView, Unit> DrawTriangleCommand { get; }
    public ReactiveCommand<MainView, Unit> DrawQuadrangleCommand { get; }
    public ReactiveCommand<MainView, Unit> DrawSquareCommand { get; }
    public ReactiveCommand<MainView, Unit> ClearCommand { get; }

    public MainViewModel()
    {
        DrawEllipseCommand = ReactiveCommand.CreateFromTask<MainView>(DrawEllipseAsync);
        DrawCircleCommand = ReactiveCommand.Create<MainView>(DrawCircle);
        DrawTriangleCommand = ReactiveCommand.Create<MainView>(DrawTriangle);
        DrawQuadrangleCommand = ReactiveCommand.Create<MainView>(DrawQuadrangle);
        DrawSquareCommand = ReactiveCommand.Create<MainView>(DrawSquare);
        ClearCommand = ReactiveCommand.Create<MainView>(Clear);
    }

    public async Task DrawEllipseAsync(MainView mainView)
    {
        var ownerWindow = mainView.GetVisualRoot();
        if (ownerWindow != null)
        {
            var dialogWindow = new DrawEllipseWindow() { DataContext = new DrawEllipseViewModel() };
            var ellipsParams = await dialogWindow.ShowDialog<double[]>((Window)ownerWindow);

            if (ellipsParams != null)
            {
                GeometricEllipse ellipse = new(
                    new Point(ellipsParams[0],
                    ellipsParams[1]),
                    ellipsParams[2],
                    ellipsParams[3]);
                AddGeometricFigureToCanvas(ellipse, mainView.MainCanvas);
            }
        }
    }

    public void DrawCircle(MainView mainView)
    {
        GeometricCircle circle = new(new Point(350, 100), 50);
        AddGeometricFigureToCanvas(circle, mainView.MainCanvas);
    }

    public void DrawTriangle(MainView mainView)
    {
        GeometricTriangle triangle = new(new Point(200, 200), new Point(300, 200), new Point(200, 300));
        AddGeometricFigureToCanvas(triangle, mainView.MainCanvas);
    }

    public void DrawQuadrangle(MainView mainView)
    {
        GeometricQuadrangle quadrangle = new (new Point(350, 250), new Point(550, 200), new Point(550, 400), new Point(400, 450));
        AddGeometricFigureToCanvas(quadrangle, mainView.MainCanvas);
    }

    public void DrawSquare(MainView mainView)
    {
        GeometricSquare square = new(new Point(250, 500), 100);
        AddGeometricFigureToCanvas(square, mainView.MainCanvas);
    }

    public void Clear (MainView mainView)
    {
        mainView.MainCanvas.Children.Clear();
    }

    public void AddGeometricFigureToCanvas(GeometricFigure figure, Canvas canvas)
    {
        Polyline polyline = new Polyline()
        {
            StrokeThickness = 3,
            Stroke = Brushes.White
        };

        polyline.Points.Add(figure.Points);

        canvas.Children.Add(polyline);
    }
}
