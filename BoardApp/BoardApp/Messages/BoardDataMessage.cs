using BoardApp.Models;

namespace BoardApp.Messages
{
    public class BoardDataMessage : MyMessageBase<BoardModel>
    {
        public BoardDataMessage(BoardModel boardData) : base(boardData)
        {
            
        }
    }
}
