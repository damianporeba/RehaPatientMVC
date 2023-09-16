using Microsoft.AspNetCore.Mvc;

namespace RehaPatientMVC.Web.Controllers
{
    public class ReferralController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
