using System;

namespace BoardApp.Models
{
    class OTPModel : IData
    {
        public int OTP { get; set; }
        public DateTime Date { get; set; }

        public OTPModel(int otp)
        {
            OTP = otp;
            Date = DateTime.UtcNow;
        }

    }
}
