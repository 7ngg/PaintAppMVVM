using BoardApp.Models;
using BoardApp.Services.Interfaces;
using System.IO;
using System.Windows.Ink;

namespace BoardApp.Services.Classes
{
    public class BoardSerializationService : IBoardSerializationService
    {
        public BoardModel Deserialize(string fileName)
        {
            using FileStream stream = new(fileName, FileMode.Open);
            var strokes = new StrokeCollection(stream);

            return new BoardModel(fileName.Remove(fileName.Length - 5, 4), strokes);
        }

        public void Serialize(BoardModel board)
        {
            using FileStream stream = new(board.Name + ".xml", FileMode.Create);
            board.Strokes.Save(stream);
        }
    }
}
