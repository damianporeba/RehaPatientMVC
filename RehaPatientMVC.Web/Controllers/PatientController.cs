using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.Services;
using RehaPatientMVC.Application.ViewModels.ContactDetails;
using RehaPatientMVC.Application.ViewModels.Patients;

namespace RehaPatientMVC.Web.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {

        private readonly IPatientService _patientService;
        private readonly IContactDetailsService _contactDetailsService;
        public PatientController(IPatientService patientService, IContactDetailsService contactDetailsService)
        {
            _patientService = patientService;
            _contactDetailsService = contactDetailsService;
        }

        [HttpGet]
        public IActionResult Index() //podstawowa akcja, wyświetla listę wszystkich pacjentów
        {
            var model = _patientService.GetAllPatientsForList(3, 1, "");
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString) //podstawowa akcja, wyświetla listę wszystkich pacjentów
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }

            if (searchString is null)
            {
                searchString = string.Empty;
            }
            var model = _patientService.GetAllPatientsForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult EditPatient(int id)
        {
            var patient = _patientService.GetPatientForEdit(id);
            return View(patient);
        }

        [HttpPost]
        public IActionResult EditPatient(NewPatientVm model)
        {
            _patientService.UpdatePatient(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewPatient(int id)
        {
            var patientModel = _patientService.ViewPatientDetails(id);
            return View(patientModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _patientService.DeletePatient(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddNewContactDetails()
        {
            return View(new NewContactDetailsVm());
        }

        [HttpPost]
        public IActionResult AddNewContactDetails(NewContactDetailsVm model)
        {
            //zrobić listę wyboru konkretnego pacjenta z ViewBag

            var id = _contactDetailsService.AddContactDetails(model);
            return RedirectToAction("Index");
        }
    }
}
