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
            return View();
        }        
        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
