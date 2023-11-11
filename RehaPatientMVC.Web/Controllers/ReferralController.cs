using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.ViewModels.Referral;
using RehaPatientMVC.Domain.Interface;
using RehaPatientMVC.Domain.Model;
using RehaPatientMVC.Infrastructure.Repositories;
using System.ComponentModel.Design;
using System.Drawing.Printing;

namespace RehaPatientMVC.Web.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class ReferralController : Controller
    {
        private readonly IReferralService _referralService;
        private readonly IMedicService _medicService;
        private readonly IPatientService _patientService;

        public ReferralController(IReferralService referralService, IMedicService medicService, IPatientService patientService)
        {
            _referralService = referralService;
            _medicService = medicService;
            _patientService = patientService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _referralService.GetAllReferralsForList(3, 1, "");
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }

            if (searchString is null)
            {
                searchString = string.Empty;
            }
            var model = _referralService.GetAllReferralsForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddReferral()
        {
            var medicList = _medicService.GetAllMedicsForDropDownList();
            ViewBag.MedicsList = new SelectList(medicList, "Id", "Name");
            var referral = new ReferralType();
            ViewBag.ReferralType = new SelectList(referral.ReferralTypes);
            return View(new NewReferralVm());
        }

        [HttpPost]
        public IActionResult AddReferral(NewReferralVm model)
        {
            var patientId = _patientService.GetPatientIdByPesel(model.Pesel);
            model.PatientId = patientId;
            var id = _referralService.AddReferral(model);
            
            return RedirectToAction("Index");
        }
        public  IActionResult Delete (int id)
        {
            _referralService.DeleteReferral(id);
            return RedirectToAction("Index");
        }
    }
}
