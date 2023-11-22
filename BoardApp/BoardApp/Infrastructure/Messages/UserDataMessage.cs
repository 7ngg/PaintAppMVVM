using BoardApp.Infrastructure.Messages.Base;
using BoardApp.Models;

namespace BoardApp.Infrastructure.Messages
{
    class UserDataMessage : MyMessageBase<UserModel>
    {
        public UserDataMessage(UserModel userData) : base(userData)
        {

        }
    }
}
