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

            var model = PatientService.GetAllPatientsForList();

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
            var id = PatientService.AddPatient(); //w nawiasie (model)
            return View();
        }
        public IActionResult ViewPatient (int patientId)
        {
            var patientModel = PatientService.GetPatientById(patientId);
            return View(patientModel);
        }
    }
}
