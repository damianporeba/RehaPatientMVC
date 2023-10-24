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

        [HttpGet("Index")]
        public ActionResult<ListReferralForListVm> Index() 
        {
            var model = _referralService.GetAllReferralsForList(3, 1, "");
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("Index")]
        public ActionResult Index(SearchInListVm searchInList)
        {
            var searchString = searchInList.searchString;
            var pageNumber = searchInList.pageNumber;

            if (searchString == null)
            {
                searchString = string.Empty;
            }
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }

            var model = _referralService.GetAllReferralsForList(searchInList.pageSize, pageNumber, searchString);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet("AddReferral")]
        public ActionResult<NewReferralVm> AddNewReferral()
        {
            var model = new NewReferralVm();
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("AddReferral")]
        public ActionResult AddNewReferral([FromBody] NewReferralVm newReferralVm)
        {
            var id = _referralService.AddReferral(newReferralVm);
            return RedirectToAction("Index");
        }

        [HttpGet("DeleteReferral{Id}")]
        public ActionResult<NewReferralVm> DeleteReferral(int id)
        {
            _referralService.DeleteReferral(id); 
            return RedirectToAction("Index");
        }
    }
}
