using BoardApp.Models;

namespace BoardApp.Messages
{
    class UserDataMessage : MyMessageBase<UserModel>
    {
        public UserDataMessage(UserModel userData) : base(userData)
        {

        }
    }
}
