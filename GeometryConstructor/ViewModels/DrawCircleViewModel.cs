using ReactiveUI;
using System.Reactive;

namespace GeometryConstructor.ViewModels
{
    internal class DrawCircleViewModel : ViewModelBase
    {
        public ReactiveCommand<DrawCircleWindow, Unit> GetCircleParamsCommand { get; }

        public DrawCircleViewModel()
        {
            GetCircleParamsCommand = ReactiveCommand.Create<DrawCircleWindow>(GetCircleParams);
        }

        void GetCircleParams(DrawCircleWindow drawCircleWindow)
        {
            double xCenter = double.TryParse(drawCircleWindow.XCenter.Text, out xCenter) ? xCenter : 0;
            double yCenter = double.TryParse(drawCircleWindow.YCenter.Text, out yCenter) ? yCenter : 0;
            double radius = double.TryParse(drawCircleWindow.Radius.Text, out radius) ? radius : 0;

            double[] circleParams = [xCenter, yCenter, radius];

            drawCircleWindow.Close(circleParams);
        }
    }
}
