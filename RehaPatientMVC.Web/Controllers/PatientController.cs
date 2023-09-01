using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.Services;

namespace RehaPatientMVC.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService) //dependency injection 
        {
            _patientService = patientService;
        }


        public IActionResult Index() //podstawowa akcja, wyświetla listę wszystkich pacjentów
        {
            //1. utworzyc widok dla tej akcji
            //2. tabela z pacjentami
            //3. panel z filtrowaniem pacjentów

            //musi serwis przygotować dane
            //serwis musi zwrócic dane w odpowiednim formacie - nie potrzebujemy obiektu pacjenta, tylko jego niektore właściwości 
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
        public IActionResult ViewPatient (int patientId)
        {
            var patientModel = _patientService.ViewPatientDetails(patientId);
            return View(patientModel);
        }
    }
}
