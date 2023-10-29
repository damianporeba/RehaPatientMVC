using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.ViewModels.UserApp;
using RehaPatientMVC.Domain.Model;
using RehaPatientMVC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly Context _context;

        public AdminService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IQueryable GetAllAppUsers()
        {
            var users = _userManager.Users;
            return users;
        } 

        public async void AddAppUser(User user)
        {
           
        }

        public void DeleteAppUser(int id)
        {
            throw new NotImplementedException();
        }

        public NewUserAppVm GetAppUserForEdit(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAppUser(NewUserAppVm model)
        {
            throw new NotImplementedException();
        }
    }
}
