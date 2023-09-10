using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.Services;
using RehaPatientMVC.Application.ViewModels.Patients;

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
            var model = _patientService.GetAllPatientsForList(2, 1, "");
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString) //podstawowa akcja, wyświetla listę wszystkich pacjentów
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }

            if(searchString is null)
            {
                searchString = string.Empty;
            }
            var model = _patientService.GetAllPatientsForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddPatient()
        {
            return View(new NewPatientVm());
        }

        [HttpPost]
        public IActionResult AddPatient(NewPatientVm model)
        {
            var id = _patientService.AddPatient(model); 
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditPatient(int patientId)
        {
            var patient = _patientService.GetPatientForEdit(patientId);
            return View(patient);
        }

        [HttpPost]
        public IActionResult EditPatient(NewPatientVm model)
        {
            _patientService.UpdatePatient(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewPatient (int patientId) //Metoda dodana na "sztywno" do sprawdzenia. Do rozwinięcia. Do zmiany widok
        {
            var patientModel = _patientService.ViewPatientDetails(patientId);
            return View(patientModel);
        }
    }
}
