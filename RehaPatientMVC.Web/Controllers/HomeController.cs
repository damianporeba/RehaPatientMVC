using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Web.Models;
using System.Diagnostics;

namespace RehaPatientMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewListOfPatients()
        {
            List<Patient> list = new List<Patient>();
            list.Add(new Patient() { Id = 1, Name = "Damian", Surname = "Poreba" });
            list.Add(new Patient() { Id = 2, Name = "Karol", Surname = "Sułkowski" });
            list.Add(new Patient() { Id = 3, Name = "Piotr", Surname = "Kowalski" });


            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}