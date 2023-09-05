using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.Services;

namespace RehaPatientMVC.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService) 
        {
            _patientService = patientService;
        }

        [HttpGet]
        public IActionResult Index() //podstawowa akcja, wyświetla listę wszystkich pacjentów
        {
            var model = _patientService.GetAllPatientsForList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int PageNo, string SearchString) //podstawowa akcja, wyświetla listę wszystkich pacjentów
        {
            var model = _patientService.GetAllPatientsForList();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddPatient()
        {
            return View();
        }

        [HttpPost]
        //public IActionResult AddPatient(PatientModel model)
        //{

        //    var id = _patientService.AddPatient(model); //w nawiasie (model)
        //    return View();
        //}

        [HttpGet]
        public IActionResult ViewPatient (int patientId) //Metoda dodana na "sztywno" do sprawdzenia. Do rozwinięcia. Do zmiany widok
        {
            var patientModel = _patientService.ViewPatientDetails(patientId);
            return View(patientModel);
        }
    }
}
