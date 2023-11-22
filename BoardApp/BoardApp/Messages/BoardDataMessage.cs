using BoardApp.Models;

namespace BoardApp.Messages
{
    public class BoardDataMessage : MyMessageBase<Board>
    {
        public BoardDataMessage(Board boardData) : base(boardData)
        {
            
        }
    }
}
