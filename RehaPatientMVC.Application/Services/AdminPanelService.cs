using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.ViewModels.AdminPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.Services
{
    public class AdminPanelService : IAdminPanelService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public AdminPanelService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public ListUsersForListVm GetAllUsers()
        {
            var users = _userManager.Users.ProjectTo<UsersForListVM>(_mapper.ConfigurationProvider).ToList();
            var usersVm = new ListUsersForListVm()
            {
                Users = users,
                count = users.Count
            };
            return usersVm;
        }

        public IQueryable<RoleVm> GetAllRoles()
        {
            var roles = _roleManager.Roles;
            var roleVm = _mapper.ProjectTo<RoleVm>(roles);
            return roleVm;
        }

        public Task <IdentityUser> GetUserDetails(string id)
        {
            var user = _userManager.FindByIdAsync(id);

            //todo - zrobić mapowanie

            return user;

        }

        public async Task<IdentityResult> SetRoleForUser(string id, string role)
        {
            IdentityResult result;
            var user = await _userManager.FindByIdAsync(id);
            
            if (user == null)
            {
                return IdentityResult.Failed();
            }
            
            result = await _userManager.AddToRoleAsync(user, role);
            return result;
        }
    }

}
