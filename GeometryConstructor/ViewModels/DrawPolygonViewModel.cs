using Avalonia;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using ReactiveUI;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;

namespace GeometryConstructor.ViewModels
{
    internal class DrawPolygonViewModel : ViewModelBase
    {
        public ReactiveCommand<DrawPolygonWindow, Unit> CreatePolygonVerticeCommand { get; }
        public ReactiveCommand<DrawPolygonWindow, Unit> GetPolygonVerticesCommand { get; }
        public List<Point> Vertices { get; set; }

        public DrawPolygonViewModel()
        {
            Vertices = new List<Point>();
            CreatePolygonVerticeCommand = ReactiveCommand.Create<DrawPolygonWindow>(CreatePolygonVertice);
            GetPolygonVerticesCommand = ReactiveCommand.CreateFromTask<DrawPolygonWindow>(GetPolygonVerticesAsync);
        }

        void CreatePolygonVertice(DrawPolygonWindow drawPolygonWindow)
        {
            double xVertex = double.TryParse(drawPolygonWindow.XVertex.Text, out xVertex) ? xVertex : 0;
            double yVertex = double.TryParse(drawPolygonWindow.YVertex.Text, out yVertex) ? yVertex : 0;

            drawPolygonWindow.XVertex.Text = "";
            drawPolygonWindow.YVertex.Text = "";

            Vertices.Add(new Point(xVertex, yVertex));
        }

        async Task GetPolygonVerticesAsync(DrawPolygonWindow drawPolygonWindow)
        {
            if (Vertices.Count > 2)
            {
                drawPolygonWindow.Close(Vertices);
            }
            else
            {
                var box = MessageBoxManager
                    .GetMessageBoxStandard("Ошибка", "У многоугольника меньше трёх вершин",
                    ButtonEnum.Ok);

                await box.ShowAsync();
            }

        }
    }
}
