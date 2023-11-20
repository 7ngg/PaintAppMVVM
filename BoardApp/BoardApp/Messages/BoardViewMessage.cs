using BoardApp.Models;

namespace BoardApp.Messages
{
    public class BoardViewMessage : MyMessageBase<BoardModel>
    {
        public BoardViewMessage(BoardModel boardData) : base(boardData)
        {
            
        }
    }
}
