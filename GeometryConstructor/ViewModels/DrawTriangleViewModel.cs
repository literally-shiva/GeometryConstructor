using ReactiveUI;
using System.Reactive;

namespace GeometryConstructor.ViewModels
{
    internal class DrawTriangleViewModel : ViewModelBase
    {
        public ReactiveCommand<DrawTriangleWindow, Unit> GetTriangleVerticesCommand { get; }

        public DrawTriangleViewModel()
        {
            GetTriangleVerticesCommand = ReactiveCommand.Create<DrawTriangleWindow>(GetTriangleVertices);
        }

        void GetTriangleVertices(DrawTriangleWindow drawTriangleWindow)
        {
            double firstVertexX = double.TryParse(drawTriangleWindow.FirstVertexX.Text, out firstVertexX) ? firstVertexX : 0;
            double firstVertexY = double.TryParse(drawTriangleWindow.FirstVertexY.Text, out firstVertexY) ? firstVertexY : 0;

            double secondVertexX = double.TryParse(drawTriangleWindow.SecondVertexX.Text, out secondVertexX) ? secondVertexX : 0;
            double secondVertexY = double.TryParse(drawTriangleWindow.SecondVertexY.Text, out secondVertexY) ? secondVertexY : 0;

            double thirdVertexX = double.TryParse(drawTriangleWindow.ThirdVertexX.Text, out thirdVertexX) ? thirdVertexX : 0;
            double thirdVertexY = double.TryParse(drawTriangleWindow.ThirdVertexY.Text, out thirdVertexY) ? thirdVertexY : 0;

            double[] triangleVertices = [firstVertexX, firstVertexY, secondVertexX, secondVertexY, thirdVertexX, thirdVertexY];

            drawTriangleWindow.Close(triangleVertices);
        }
    }
}
