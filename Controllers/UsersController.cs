using Microsoft.AspNetCore.Mvc;
using UserManagementWebApp.Models;

namespace UserManagementWebApp.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        
        public IActionResult List()
        {
            List<User> users = new List<User>();
            return View(users);
        }        
        public IActionResult Delete()
        {
            User user = new User();
            return View(user);
        }

        public IActionResult Edit()
        {
            User user = new User();
            return View(user);
        }
    }
}
