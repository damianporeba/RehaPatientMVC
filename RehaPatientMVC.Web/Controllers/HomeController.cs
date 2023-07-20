using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Web.Models;
using System.Diagnostics;

namespace RehaPatientMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPatientService _patientService;

        public HomeController(ILogger<HomeController> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewListOfPatients()
        {
            ViewData["TemporaryData"] = "--";
            string imie = _patientService.Method();

            List<Patient> list = new List<Patient>();
            list.Add(new Patient() { Id = 1, Name = "Damian", Surname = "Poreba" });
            list.Add(new Patient() { Id = 2, Name = "Karol", Surname = "Sułkowski" });
            list.Add(new Patient() { Id = 3, Name = imie, Surname = "Kowalski" });
            
            return View(list);
        }
        public IActionResult ViewListOfPatients1()
        {
            List<Patient1> list = new List<Patient1>();
            list.Add(new Patient1(1));
            list.Add(new Patient1(2));
            return View(list);
        }

        public IActionResult ViewListOfPatients2()
        {
            List<Patient1> list = new List<Patient1>();
            list.Add(new Patient1(1));
            list.Add(new Patient1(2));
            return PartialView(list);
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