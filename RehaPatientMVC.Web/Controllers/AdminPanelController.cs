using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.Interfaces;

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

        public IActionResult AllRoles()
        {
            var roles = _adminPanelService.GetAllRoles();
            return View(roles);
        }

        public async Task<ActionResult> SetRoleForUser(string id, string role)
        {
            await _adminPanelService.SetRoleForUser(id, role);
            return RedirectToAction("Index");
        }

    }
}
