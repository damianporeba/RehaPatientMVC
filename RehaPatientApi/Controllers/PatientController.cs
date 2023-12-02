using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.ViewModels;
using RehaPatientMVC.Application.ViewModels.Patients;

namespace RehaPatientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<ListPatientForListVm> Index()
        {
            var model = _patientService.GetAllPatientsForList(3, 1, "");
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost]
        public ActionResult AddPatient([FromBody] NewPatientVm newPatientVm)
        {
            var id = _patientService.AddPatient(newPatientVm);
            return RedirectToAction("Index");
        }

        [HttpGet("{id}")]
        public ActionResult PatientDetails (int id)
        {
            var details = _patientService.ViewPatientDetails(id);
            return Ok(details);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePatient(int id)
        {
            _patientService.DeletePatient(id);
            return RedirectToAction("Index");
        }

        [HttpPut]
        public ActionResult EditPatient([FromBody] NewPatientVm newPatientVm)
        {
            _patientService.UpdatePatient(newPatientVm);
            return RedirectToAction("Index");
        }
    }
}
