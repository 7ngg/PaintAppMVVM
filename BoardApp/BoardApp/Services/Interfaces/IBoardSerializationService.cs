using BoardApp.Models;

namespace BoardApp.Services.Interfaces
{
    public interface IBoardSerializationService
    {
        public BoardModel Deserialize(string fileName);
        public void Serialize(BoardModel board);
    }
}
