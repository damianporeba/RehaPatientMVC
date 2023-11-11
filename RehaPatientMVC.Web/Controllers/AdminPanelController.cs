using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.ViewModels.AdminPanel;
using RehaPatientMVC.Domain.Model;

namespace RehaPatientMVC.Web.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IAdminPanelService _adminPanelService;

        public AdminPanelController(IAdminPanelService adminPanelService)
        {
            _adminPanelService = adminPanelService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _adminPanelService.GetAllUsers();
            return View(model);
        }

        [HttpGet]
        public IActionResult AllRoles()
        {
            var roles = _adminPanelService.GetAllRoles();
            return View(roles);
        }

        [HttpGet]
        public IActionResult SetRoleForUser()
        {
            var rolesToChoice = new Roles();
            ViewBag.Roles = new SelectList(rolesToChoice.RolesList);
            var users = _adminPanelService.GetAllUsersForList();
            ViewBag.Users = new SelectList(users, "Email");
            return View(new RoleForUserVm());
        }

        [HttpPost]
        public async Task<ActionResult> SetRoleForUser(RoleForUserVm model)
        {
            var userRoles = _adminPanelService.GetRolesForUser(model.Email);
            await _adminPanelService.SetRoleForUser(model.Email, model.Role);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Delete (string email)
        {
            await _adminPanelService.DeleteUser(email);
            return RedirectToAction("Index");
        }
    }
}
