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
            return View();
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            return RedirectToAction("Index");
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
        public IActionResult EditAppUser()
        {
            return View(new NewAppUserVm());
        }

        [HttpPost]
        public IActionResult EditAppUser(NewAppUserVm newAppUserVm)
        {
            //var userToEdit = _userService.GetAppUserForEdit(newAppUserVm.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteAppUser(int id)
        {
            _userService.DeleteAppUser(id);
            return RedirectToAction("Index");
        }
    }

}
