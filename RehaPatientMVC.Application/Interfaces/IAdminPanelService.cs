using Microsoft.AspNetCore.Identity;
using RehaPatientMVC.Application.ViewModels.AdminPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.Interfaces
{
    public interface IAdminPanelService
    {
        public ListUsersForListVm GetAllUsers();
        IQueryable<RoleVm> GetAllRoles();
        public Task<IdentityResult> SetRoleForUser(string id, string role);
        public Task<IdentityUser> GetUserDetails(string id);

    }
}
