using BoardApp.Infrastructure.Messages.Base;
using BoardApp.Models;

namespace BoardApp.Infrastructure.Messages
{
    public class WindowPropertyMessage : MyMessageBase<WindowPropertyModel>
    {
        public WindowPropertyMessage(WindowPropertyModel windowProperty) : base(windowProperty)
        {
            
        }
    }
}
