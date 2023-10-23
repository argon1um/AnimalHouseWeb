using AnimalHouseRestAPI.ModelsDTO;
using Azure.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPost(string username, string password)
        {
            bool check;
            string address = "http://localhost:8080/";
            username = Request.Form["username"];
            password = Request.Form["password"];
            userforform = username;
            passwordforform = password;


            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password) )
            {
                ClientDTO clientDTO = new ClientDTO(username, password);
                var response = new HttpClient().PostAsJsonAsync(address + "clients/auth/log", clientDTO).Result;
                if (response.IsSuccessStatusCode)
                {
                   return RedirectToPage("About");
                }
                else
                {
                    var showerror = true;
                    if (showerror)
                    {
                        ViewData["showerror"] = "true";
                        ViewData["customerror"] = "Неверный логин или пароль!";
                        return Page();
                    }
                    return RedirectToPage("./Index");
                }
            }
            else
            {
                var showerror = true;
                if (showerror)
                {
                    ViewData["showerror"] = "true";
                    ViewData["customerror"] = "Заполните все поля!";
                    return Page();
                }

                return RedirectToPage("./Index");
            }

            
        }


    }
}