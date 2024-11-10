using ReactiveUI;
using System.Reactive;

namespace GeometryConstructor.ViewModels
{
    internal class DrawQuadrangleViewModel : ViewModelBase
    {
        public ReactiveCommand<DrawQuadrangleWindow, Unit> GetQuadrangleVerticesCommand { get; }

        public DrawQuadrangleViewModel()
        {
            GetQuadrangleVerticesCommand = ReactiveCommand.Create<DrawQuadrangleWindow>(GetQuadrangleVertices);
        }

        void GetQuadrangleVertices(DrawQuadrangleWindow drawQuadrangleWindow)
        {
            double firstVertexX = double.TryParse(drawQuadrangleWindow.FirstVertexX.Text, out firstVertexX) ? firstVertexX : 0;
            double firstVertexY = double.TryParse(drawQuadrangleWindow.FirstVertexY.Text, out firstVertexY) ? firstVertexY : 0;

            double secondVertexX = double.TryParse(drawQuadrangleWindow.SecondVertexX.Text, out secondVertexX) ? secondVertexX : 0;
            double secondVertexY = double.TryParse(drawQuadrangleWindow.SecondVertexY.Text, out secondVertexY) ? secondVertexY : 0;

            double thirdVertexX = double.TryParse(drawQuadrangleWindow.ThirdVertexX.Text, out thirdVertexX) ? thirdVertexX : 0;
            double thirdVertexY = double.TryParse(drawQuadrangleWindow.ThirdVertexY.Text, out thirdVertexY) ? thirdVertexY : 0;

            double fourthVertexX = double.TryParse(drawQuadrangleWindow.FourthVertexX.Text, out fourthVertexX) ? fourthVertexX : 0;
            double fourthVertexY = double.TryParse(drawQuadrangleWindow.FourthVertexY.Text, out fourthVertexY) ? fourthVertexY : 0;

            double[] triangleVertices = [firstVertexX, firstVertexY, secondVertexX, secondVertexY, thirdVertexX, thirdVertexY, fourthVertexX, fourthVertexY];

            drawQuadrangleWindow.Close(triangleVertices);
        }
    }
}
