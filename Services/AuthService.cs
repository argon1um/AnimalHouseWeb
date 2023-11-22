using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ah4cClientApp.Services
{
    public  class AuthService
    {
        public  string AuthCheck(string username, string password)
        {
            if (string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                return "LoginCheckFault";
            }
            else if (string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(username))
            {
                return "PasswordCheckFault";
            }
            else if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty (password))
            {
                return "CheckFault";
            }
            else return "CheckComplete";
        }
    }
}
