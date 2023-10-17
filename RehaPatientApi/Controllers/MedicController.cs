using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.ViewModels.Medics;

namespace RehaPatientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class MedicController : ControllerBase
    {
        private readonly IMedicService _medicService;
        public MedicController(IMedicService medicService)
        {
            _medicService = medicService;
        }

        [HttpGet]
        public ActionResult<NewMedicVm> AddNewMedic()
        {
            var model = new NewMedicVm();
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
        [HttpPost]
        public ActionResult AddNewMedic([FromBody] NewMedicVm medicModel)
        {
            _medicService.AddMedic(medicModel);
            return RedirectToAction("Index");
        }
    }
}
