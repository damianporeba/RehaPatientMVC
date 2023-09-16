using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Domain.Interface;
using System.ComponentModel.Design;
using System.Drawing.Printing;

namespace RehaPatientMVC.Web.Controllers
{
    public class ReferralController : Controller
    {
        private readonly IReferralService _referralService;

        public ReferralController(IReferralService referralService)
        {
            _referralService = referralService;
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

        public  IActionResult Delete (int id)
        {
            _referralService.DeleteReferral(id);
            return RedirectToAction("Index");
        }
    }
}
