using BoardApp.Infrastructure.Messages.Base;
using BoardApp.Models;

namespace BoardApp.Infrastructure.Messages
{
    class OTPMessage : MyMessageBase<OTPModel>
    {
        public OTPMessage(OTPModel userData) : base(userData)
        {
            
        }
    }
}
