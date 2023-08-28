using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.Services;

namespace RehaPatientMVC.Web.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index() //podstawowa akcja, wyświetla listę wszystkich pacjentów
        {
            //1. utworzyc widok dla tej akcji
            //2. tabela z pacjentami
            //3. panel z filtrowaniem pacjentów

            //musi serwis przygotować dane
            //serwis musi zwrócic dane w odpowiednim formacie - nie potrzebujemy obiektu pacjenta, tylko jego niektore właściwości 
            var patientService = new PatientService();
            var model = patientService.GetAllPatientsForList();

            return View(model);
        }

        [HttpGet]
        public IActionResult AddPatient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPatient(PatientModel model)
        {
            var patientService = new PatientService();

            var id = patientService.AddPatient(); //w nawiasie (model)
            return View();
        }
        public IActionResult ViewPatient (int patientId)
        {
            var patientService = new PatientService();

            var patientModel = patientService.ViewPatientDetails(patientId);
            return View(patientModel);
        }
    }
}
