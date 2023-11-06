using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.ViewModels;
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

        [HttpGet("Index")]
        public ActionResult<ListMedicForListVm> Index()
        {
            var model = _medicService.GetAllMedicsForList(3, 1, "");
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("Index")]
        public ActionResult Index([FromBody] SearchInListVm searchInListVm)
        {
            var pageNumber = searchInListVm.pageNumber;
            var searchString = searchInListVm.searchString;

            if (pageNumber == 0)
            {
                pageNumber = 1;
            }

            if (searchString == null)
            {
                searchString = string.Empty;
            }

            var model = _medicService.GetAllMedicsForList(searchInListVm.pageSize, pageNumber, searchString);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet("AddNewMedic")]
        public ActionResult<NewMedicVm> AddNewMedic()
        {
            var model = new NewMedicVm();
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
        [HttpPost("AddNewMedic")]
        public ActionResult AddNewMedic([FromBody] NewMedicVm medicModel)
        {
            var id = _medicService.AddMedic(medicModel);
            return RedirectToAction("Index");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMedic(int id)
        {
            _medicService.DeleteMedic(id);
            return RedirectToAction("Index");
        }

        [HttpGet("MedicDetails/{id}")]
        public ActionResult<MedicDetailsVm> MedicDetails(int id)
        {
            var model = _medicService.ViewMedicDetails(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPut("{id}")]
        public ActionResult<NewMedicVm> EditMedic(int id)
        {
            var model = _medicService.GetMedicForEdit(id);
            if(model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
        
        [HttpPost("EditMedic")]
        public ActionResult EditMedic([FromBody] NewMedicVm medicModel)
        {
            _medicService.UpdateMedic(medicModel);
            return RedirectToAction("Index");
        }
    }

}
