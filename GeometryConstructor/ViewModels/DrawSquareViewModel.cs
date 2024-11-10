using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using ReactiveUI;
using System.Reactive;
using System.Threading.Tasks;

namespace GeometryConstructor.ViewModels
{
    internal class DrawSquareViewModel : ViewModelBase
    {
        public ReactiveCommand<DrawSquareWindow, Unit> GetSquareParamsCommand { get; }

        public DrawSquareViewModel()
        {
            GetSquareParamsCommand = ReactiveCommand.CreateFromTask<DrawSquareWindow>(GetSquareParamsAsync);
        }

        async Task GetSquareParamsAsync(DrawSquareWindow drawSquareWindow)
        {
            double xCenter = double.TryParse(drawSquareWindow.XCenter.Text, out xCenter) ? xCenter : 0;
            double yCenter = double.TryParse(drawSquareWindow.YCenter.Text, out yCenter) ? yCenter : 0;

            double sideLength = double.TryParse(drawSquareWindow.SideLength.Text, out sideLength) ? sideLength : 0;

            if (sideLength > 0)
            {
                double[] squareParams = [xCenter, yCenter, sideLength];

                drawSquareWindow.Close(squareParams);
            }
            else
            {
                var box = MessageBoxManager
                    .GetMessageBoxStandard("Ошибка", "Введено неверное значение стороны",
                    ButtonEnum.Ok);

                await box.ShowAsync();
            }
        }
    }
}
