using BoardApp.Models;

namespace BoardApp.Services.Interfaces
{
    interface IOTPService
    {
        public OTPModel SendOTP(string email);
    }
}
