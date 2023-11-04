using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.ViewModels.UserApp;
using RehaPatientMVC.Domain.Model;

namespace RehaPatientMVC.Web.Controllers
{
    public class AppUserController : Controller
    {
        private readonly IAppUserService _userService;
        
        public AppUserController(IAppUserService appUserService)
        {
            _userService = appUserService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _userService.GetAllAppUserForList(3, 1,"");
            return View(list);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if(!pageNo.HasValue)
            {
                pageNo = 1;
            }

            if(searchString is null)
            {
                searchString = string.Empty;
            }
            var model = _userService.GetAllAppUserForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddNewAppUser()
        {
            return View(new NewAppUserVm());
        }

        [HttpPost]
        public IActionResult AddNewAppUser(NewAppUserVm newAppUserVm) 
        {
            _userService.AddAppUser(newAppUserVm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAppUser(int id)
        {
            var model = _userService.GetAppUserForEdit(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditAppUser(NewAppUserVm model)
        {
            _userService.UpdateAppUser(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AppUserDetails(int id)
        {
            var user = _userService.ViewAppUserDetails(id);
            return View(user);
        }

        [HttpGet]
        public IActionResult Delete (int id)
        {
            _userService.DeleteAppUser(id);
            return RedirectToAction("Index");
        }
    }

}
