using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace RehaPatientMVC.Web.Controllers
{
    public class AdminController : Controller
    {

        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
