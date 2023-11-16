using System.Text.RegularExpressions;

namespace BoardApp.Infrastructure.Regexes
{
    public static class UserModelRegex
    {
        public static readonly Regex UsernameRegex = new(@"^[a-zA-Z0-9]{4,16}$");
        public static readonly Regex PasswordRegex = new(@"^([a-zA-Z0-9*!.~?<>^@]{4,16})$");
        public static readonly Regex EmailRegex = new(@"^^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        public static readonly Regex FirstLastNameRegex = new(@"^[a-zA-Z]{1, 24}$");
    }
}
