using Microsoft.AspNetCore.Mvc;
using UserManagementWebApp.Models;

//MVC Controller to controll the Users views (Create, List, Edit, Delete)
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
