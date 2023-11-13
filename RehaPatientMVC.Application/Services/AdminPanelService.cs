using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.ViewModels.AdminPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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

        public async Task <UserDetailsVm> GetUserDetails(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var userVm = _mapper.Map<UserDetailsVm>(user);
            return userVm;
        }

        public IQueryable<string> GetRolesForUser(string email)
        {
            var user = _userManager.FindByEmailAsync(email).Result;
            var roles = _userManager.GetRolesAsync(user).Result.AsQueryable();

            return roles;
        }

        public async Task<IdentityResult> SetRoleForUser(string email, string role)
        {
            IdentityResult result;
            var user = await _userManager.FindByEmailAsync(email);
            
            if (user == null)
            {
                return IdentityResult.Failed();
            }

            var userRoles = GetRolesForUser(email);

            if (userRoles != null)
            {
                await _userManager.RemoveFromRolesAsync(user, userRoles);
            }

            result = await _userManager.AddToRoleAsync(user, role);
            return result;
        }

        public List<IdentityUser> GetAllUsersForList()
        {
            var users = _userManager.Users.ToList();
            return users;
        }

        public async Task<IdentityResult> DeleteUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return await _userManager.DeleteAsync(user);
        }
    }
}
