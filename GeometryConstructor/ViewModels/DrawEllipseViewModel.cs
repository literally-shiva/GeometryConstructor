using ReactiveUI;
using System.Reactive;

namespace GeometryConstructor.ViewModels
{
    internal class DrawEllipseViewModel : ViewModelBase
    {
        public ReactiveCommand<DrawEllipseWindow, Unit> GetEllipseParamsCommand { get; }

        public DrawEllipseViewModel()
        {
            GetEllipseParamsCommand = ReactiveCommand.Create<DrawEllipseWindow>(GetEllipseParams);
        }

        void GetEllipseParams(DrawEllipseWindow drawEllipseWindow)
        {
            double xCenter = double.TryParse(drawEllipseWindow.XCenter.Text, out xCenter) ? xCenter : 0;
            double yCenter = double.TryParse(drawEllipseWindow.YCenter.Text, out yCenter) ? yCenter : 0;
            double xSemiAxis = double.TryParse(drawEllipseWindow.XSemiAxis.Text, out xSemiAxis) ? xSemiAxis : 0;
            double ySemiAxis = double.TryParse(drawEllipseWindow.YSemiAxis.Text, out ySemiAxis) ? ySemiAxis : 0;

            double[] ellipseParams = [xCenter, yCenter, xSemiAxis, ySemiAxis];

            drawEllipseWindow.Close(ellipseParams);
        }
    }
}