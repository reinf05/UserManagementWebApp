using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using UserManagementWebApp.Models;

//MVC Controller to controll the Users views (Create, List, Edit, Delete)
namespace UserManagementWebApp.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Create(int id)
        {

            return View();
        }
        
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            string baseUrl = Request.Scheme + "://" + Request.Host.ToString();
            var result = client.GetAsync($"{baseUrl}/api/UsersApi/{id}").Result;
            var user = result.Content.ReadFromJsonAsync<User>().Result;
            return View(user);
        }

        public IActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            string baseUrl = Request.Scheme + "://" + Request.Host.ToString();
            var result = client.GetAsync($"{baseUrl}/api/UsersApi/{id}").Result;
            var user = result.Content.ReadFromJsonAsync<User>().Result;
            return View(user);
        }
    }
}
