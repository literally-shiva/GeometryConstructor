using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.VisualTree;
using DynamicData;
using GeometryConstructor.Models.Figures;
using GeometryConstructor.Views;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
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
    public ReactiveCommand<Unit, Unit> HelpCommand { get; }

    public MainViewModel()
    {
        DrawEllipseCommand = ReactiveCommand.CreateFromTask<MainView>(DrawEllipseAsync);
        DrawCircleCommand = ReactiveCommand.CreateFromTask<MainView>(DrawCircleAsync);
        DrawTriangleCommand = ReactiveCommand.CreateFromTask<MainView>(DrawTriangleAsync);
        DrawQuadrangleCommand = ReactiveCommand.Create<MainView>(DrawQuadrangle);
        DrawSquareCommand = ReactiveCommand.Create<MainView>(DrawSquare);
        ClearCommand = ReactiveCommand.Create<MainView>(Clear);
        HelpCommand = ReactiveCommand.CreateFromTask(HelpAsync);
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

    public async Task DrawCircleAsync(MainView mainView)
    {
        var ownerWindow = mainView.GetVisualRoot();
        if (ownerWindow != null)
        {
            var dialogWindow = new DrawCircleWindow() { DataContext = new DrawCircleViewModel() };
            var circleParams = await dialogWindow.ShowDialog<double[]>((Window)ownerWindow);

            if (circleParams != null)
            {
                GeometricCircle circle = new(new Point(circleParams[0], circleParams[1]), circleParams[2]);
                AddGeometricFigureToCanvas(circle, mainView.MainCanvas);
            }
        }
    }

    public async Task DrawTriangleAsync(MainView mainView)
    {
        var ownerWindow = mainView.GetVisualRoot();
        if (ownerWindow != null)
        {
            var dialogWindow = new DrawTriangleWindow() { DataContext = new DrawTriangleViewModel() };
            var triangleVertices = await dialogWindow.ShowDialog<double[]>((Window)ownerWindow);

            if (triangleVertices != null)
            {
                GeometricTriangle triangle = new(
                    new Point(triangleVertices[0], triangleVertices[1]),
                    new Point(triangleVertices[2], triangleVertices[3]),
                    new Point(triangleVertices[4], triangleVertices[5]));
                AddGeometricFigureToCanvas(triangle, mainView.MainCanvas);
            }
        }
    }

    public void DrawQuadrangle(MainView mainView)
    {
        GeometricQuadrangle quadrangle = new(new Point(350, 250), new Point(550, 200), new Point(550, 400), new Point(400, 450));
        AddGeometricFigureToCanvas(quadrangle, mainView.MainCanvas);
    }

    public void DrawSquare(MainView mainView)
    {
        GeometricSquare square = new(new Point(250, 500), 100);
        AddGeometricFigureToCanvas(square, mainView.MainCanvas);
    }

    public void Clear(MainView mainView)
    {
        mainView.MainCanvas.Children.Clear();
    }

    public void AddGeometricFigureToCanvas(GeometricFigure figure, Canvas canvas)
    {
        Polyline polyline = new Polyline()
        {
            StrokeThickness = 5,
            Stroke = Brushes.White,
            StrokeJoin = PenLineJoin.Miter,
            StrokeLineCap = PenLineCap.Round
        };

        polyline.Points.Add(figure.Points);

        canvas.Children.Add(polyline);
    }

    public async Task HelpAsync()
    {
        var box = MessageBoxManager
          .GetMessageBoxStandard("Справка", "Координатная ось начинается в левом верхнем углу и возрастает в направлении правого нижнего",
              ButtonEnum.Ok);

        var result = await box.ShowAsync();
    }
}
