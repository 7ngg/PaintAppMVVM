using BoardApp.Services.Interfaces;
using System.Net.Mail;
using System.Net;
using System;
using BoardApp.Models;

namespace BoardApp.Services.Classes
{
    class OTPService : IOTPService
    {
        private readonly string _originEmail = "boardappmvvm@outlook.com";
        private readonly string _originPassword = "rQYqukWHAtbwVugVfFP7";

        public OTPModel SendOTP(string email)
        {
            Random random = new();
            OTPModel otp = new(random.Next(1000, 9999));
            
            string subject = $"Email confirmation";
            string body = $"Your confirmation code: {otp.OTP}. Time: {otp.Date} UTC";

            var smtp = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(_originEmail, _originPassword)
            };

            smtp.SendMailAsync(_originEmail, email, subject, body);

            return otp;
        }
    }
}
