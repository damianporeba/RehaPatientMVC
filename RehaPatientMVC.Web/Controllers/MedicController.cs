using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.Services;

namespace RehaPatientMVC.Web.Controllers
{
    public class MedicController : Controller
    {
        private readonly IMedicService _medicService;
        public MedicController(IMedicService medicService)
        {
            _medicService = medicService;
        }

        [HttpGet]
        public IActionResult Index() //podstawowa akcja, wyświetla listę wszystkich pacjentów
        {
            var model = _medicService.GetAllMedicsForList(3, 1, "");
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
            var model = _medicService.GetAllMedicsForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult MedicDetails(int id)
        {
            var model = _medicService.ViewMedicDetails(id);
            return View(model);
        }

        
    }
}
