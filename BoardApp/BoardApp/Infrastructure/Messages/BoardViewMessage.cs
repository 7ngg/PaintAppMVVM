using BoardApp.Infrastructure.Messages.Base;
using BoardApp.Models;

namespace BoardApp.Infrastructure.Messages
{
    public class BoardViewMessage : MyMessageBase<Board>
    {
        public BoardViewMessage(Board boardData) : base(boardData)
        {

        }
    }
}
