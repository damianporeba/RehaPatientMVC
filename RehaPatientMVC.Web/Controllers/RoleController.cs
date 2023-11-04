using Microsoft.AspNetCore.Mvc;

namespace RehaPatientMVC.Web.Controllers
{
    public class AdminPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
