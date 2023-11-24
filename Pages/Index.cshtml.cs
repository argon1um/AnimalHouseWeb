using ah4cClientApp.Services;
using AnimalHouseRestAPI.ModelsDTO;
using Azure.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using System.Net;
using System.Text;
using System.Web;

namespace ah4cClientApp.Pages
{
    public class IndexModel : PageModel
    {
        
        public static string userforform;
        public static string passwordforform;
        private readonly ILogger<IndexModel> _logger;

        AuthService auth = new AuthService();
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public  IActionResult OnPost(string username, string password)
        {
            
            bool check;
            string address = "http://localhost:8080/";
            username = Request.Form["username"];
            password = Request.Form["password"];
            userforform = username;
            passwordforform = password;
            string result = auth.AuthCheck(username, password);
            if (result == "LoginCheckFault")
            {
                var showerror = true;
                if (showerror)
                {
                    ViewData["showerror"] = "true";
                    ViewData["customerror"] = "Логин не может быть пустым!";
                    return Page();
                }
                return RedirectToPage("./Index");
            }
            else if (result == "PasswordCheckFault")
            {
                var showerror2 = true;
                if (showerror2)
                {
                    ViewData["showerror"] = "true";
                    ViewData["customerror"] = "Пароль не может быть пустым!";
                    return Page();
                }
                return RedirectToPage("./Index");
            }
            else if (result == "CheckFault")
            {
                var showerror3 = true;
                if (showerror3)
                {
                    ViewData["showerror"] = "true";
                    ViewData["customerror"] = "Заполните все поля!";
                    return Page();
                }
                return RedirectToPage("./Index");
            }
            else
            {

                ClientDTO clientDTO = new ClientDTO(username, password);
                var response = new HttpClient().PostAsJsonAsync(address + "clients/log", clientDTO).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("About");
                }
                else
                {
                    var showerror4 = true;
                    if (showerror4)
                    {
                        ViewData["showerror"] = "true";
                        ViewData["customerror"] = "Неверный логин или пароль!";
                        return Page();
                    }
                    return RedirectToPage("./Index");
                }
            }
        }
    }
}