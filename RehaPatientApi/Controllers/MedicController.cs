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

        [HttpGet]
        public ActionResult<ListMedicForListVm> Index()
        {
            var model = _medicService.GetAllMedicsForList(3, 1, "");
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost]
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

        [HttpGet]
        public ActionResult DeleteMedic(int id)
        {
            _medicService.DeleteMedic(id);
            return RedirectToAction("Index");
        }
    }

}
