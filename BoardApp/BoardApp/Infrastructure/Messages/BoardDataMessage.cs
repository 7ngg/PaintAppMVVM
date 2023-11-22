using BoardApp.Infrastructure.Messages.Base;
using BoardApp.Models;

namespace BoardApp.Infrastructure.Messages
{
    public class BoardDataMessage : MyMessageBase<Board>
    {
        public BoardDataMessage(Board boardData) : base(boardData)
        {

        }
    }
}
