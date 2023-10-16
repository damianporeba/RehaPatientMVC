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

        [HttpGet("Index")]
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
        [AllowAnonymous]
        public ActionResult<ListPatientForListVm> Index([FromBody] SearchInListVm searchVm)
        {
            var pageNumber = searchVm.pageNumber;
            var searchString = searchVm.searchString; ;

            if (pageNumber == 0)
            {
                pageNumber = 1;
            }

            if (searchString == null)
            {
                searchString = string.Empty;
            }

            var model = _patientService.GetAllPatientsForList(searchVm.pageSize, pageNumber, searchString);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet("AddPatient")]
        public ActionResult<NewPatientVm> AddPatient()
        {
            var model = new NewPatientVm();
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("AddPatient")]
        public ActionResult AddPatient([FromBody] NewPatientVm newPatientVm)
        {
            var id = _patientService.AddPatient(newPatientVm);
            return RedirectToAction("Index");
        }

        [HttpPost("PatientDetails/{id}")]
        public ActionResult PatientDetails (int id)
        {
            var details = _patientService.ViewPatientDetails(id);
            return Ok(details);
        }

    }
}
