using System.Windows.Ink;

namespace BoardApp.Models
{
    public class BoardModel : IData
    {
        public string Name { get; set; }
        public StrokeCollection Strokes { get; set; }

        public BoardModel()
        {
            Name = "untitled";
            Strokes = new();
        }

        public BoardModel(string name, StrokeCollection strokes)
        {
            Name = name;
            Strokes = strokes;
        }
    }
}
