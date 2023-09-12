using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.Interfaces;

namespace RehaPatientMVC.Web.Controllers
{
    public class MedicController : Controller
    {

        private readonly IMedicService _medicService;
        public MedicController(IMedicService medicService)
        {
            _medicService = medicService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
