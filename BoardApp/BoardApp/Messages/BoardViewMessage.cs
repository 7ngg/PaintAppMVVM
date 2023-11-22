using BoardApp.Models;

namespace BoardApp.Messages
{
    public class BoardViewMessage : MyMessageBase<Board>
    {
        public BoardViewMessage(Board boardData) : base(boardData)
        {
            
        }
    }
}
