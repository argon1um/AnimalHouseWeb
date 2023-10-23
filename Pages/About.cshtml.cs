using AnimalHouseRestAPI.Models;
using AnimalHouseRestAPI.ModelsDTO;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ah4cClientApp.Pages;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Azure.Messaging;
using Vereyon.Web;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ah4cClientApp.Pages
{
    [IgnoreAntiforgeryToken]
    public class AboutModel : PageModel 
    {
        public static List<Order> OrderList = new List<Order>();
        private static JsonSerializerSettings mainsettings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
        public static string address = "http://localhost:8080/";

        public void OnPost()
        {
            string strClientid = Request.Form["clientid"];
            string strOrderid = Request.Form["orderid"];
            string strStatusid = Request.Form["statusid"];
            string strOrderidoutput = Request.Form["orderidoutput"];
            string strOrderiddelete = Request.Form["orderiddelete"];
            if (string.IsNullOrWhiteSpace(strStatusid) && string.IsNullOrWhiteSpace(strOrderid) && string.IsNullOrWhiteSpace(strClientid) && string.IsNullOrEmpty(strOrderiddelete) && string.IsNullOrEmpty(strOrderidoutput))
            {
                var showerror = true;
                if (showerror)
                {
                    ViewData["showerror"] = "true";
                    ViewData["customerror"] = "Выберите действие";
                    Page();
                }
            }
            else if (string.IsNullOrEmpty(strClientid) && string.IsNullOrEmpty(strOrderiddelete) && string.IsNullOrEmpty(strOrderidoutput))
            {
                if (!int.TryParse(strOrderid, out int orderid) || !int.TryParse(strStatusid, out int statusid))
                {
                    var showerror = true;
                    if (showerror)
                    {
                        ViewData["showerror"] = "true";
                        ViewData["customerror"] = "ID заявки должен быть числом";
                        Page();
                    }
                    return;
                }

                var response = new HttpClient().PutAsJsonAsync(address + $"orders/statuschange/{orderid}/{statusid}", new StringContent(string.Empty)).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var showsuccess = true;
                    if (showsuccess)
                    {
                        ViewData["showsuccess"] = "true";
                        ViewData["customsuccess"] = "Статус изменен";
                    }
                }
                else
                {
                    var showerror = true;
                    if (showerror)
                    {
                        ViewData["showerror"] = "true";
                        ViewData["customerror"] = "Заявка не найдена";
                    }
                }
            }
            else if (!string.IsNullOrEmpty(strClientid) && string.IsNullOrEmpty(strStatusid) && string.IsNullOrEmpty(strOrderid) && string.IsNullOrEmpty(strOrderiddelete) && string.IsNullOrEmpty(strOrderidoutput)) 
            {
                Client client = new Client();
                if (int.TryParse(strClientid, out int clientid))
                {
                    client.ClientId = clientid;
                    OrderGetterOnClient(clientid);
                }
                else
                {
                    var showerror = true;
                    if (showerror)
                    {
                        ViewData["showerror"] = "true";
                        ViewData["customerror"] = "ID Клиента может быть только числом";
                        Page();
                    }
                }
            }
            else if (!string.IsNullOrEmpty(strOrderidoutput) &&  string.IsNullOrEmpty(strClientid) && string.IsNullOrEmpty(strStatusid) && string.IsNullOrEmpty(strOrderiddelete) && string.IsNullOrEmpty(strOrderid))
            {
                Order order = new Order();
                if (int.TryParse(strOrderidoutput, out int orderid))
                {
                    order.OrderId = orderid;
                    OrderGetter(orderid);
                }
                else
                {
                    var showerror = true;
                    if (showerror)
                    {
                        ViewData["showerror"] = "true";
                        ViewData["customerror"] = "ID заявки может быть только числом";
                        Page();
                    }
                }
            }
            else
            {
                if (int.TryParse(strOrderiddelete, out int deleteorderid))
                {
                    var response = new HttpClient().DeleteAsync(address + $"orders/orderdelete/{deleteorderid}").Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var showsuccess = true;
                        if (showsuccess)
                        {
                            ViewData["showsuccess"] = "true";
                            ViewData["customsuccess"] = "Заявка(-и) удалена(-ы)";
                            Page();
                        }
                    }
                    else
                    {
                        var showerror = true;
                        if (showerror)
                        {
                            ViewData["showerror"] = "true";
                            ViewData["customerror"] = "Заявка не существует";
                            Page();
                        }
                    }
                }
            }
        }

        public static void OrderGetter(int orderid)
        {
            var response = new HttpClient().GetStringAsync(address + $"orders/{orderid}").Result;
            OrderList = JsonConvert.DeserializeObject<List<Order>>(response);
        }

        public static void OrderGetterOnClient(int clientid)
        {
            var response = new HttpClient().GetStringAsync(address + $"orders/orderslist/{clientid}").Result;
            OrderList = JsonConvert.DeserializeObject<List<Order>>(response);
        }
    }
}
