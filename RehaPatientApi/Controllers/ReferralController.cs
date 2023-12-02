using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.ViewModels;
using RehaPatientMVC.Application.ViewModels.Referral;

namespace RehaPatientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferralController : ControllerBase
    {
        private readonly IReferralService _referralService;

        public ReferralController(IReferralService referralService)
        {
            _referralService = referralService;
        }

        [HttpGet]
        public ActionResult<ListReferralForListVm> Index() 
        {
            var model = _referralService.GetAllReferralsForList(3, 1, "");
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        } 

        [HttpPost]
        public ActionResult AddNewReferral([FromBody] NewReferralVm newReferralVm)
        {
            var id = _referralService.AddReferral(newReferralVm);
            return RedirectToAction("Index");
        }

        [HttpDelete("{Id}")]
        public ActionResult<NewReferralVm> DeleteReferral(int id)
        {
            _referralService.DeleteReferral(id); 
            return RedirectToAction("Index");
        }
    }
}
