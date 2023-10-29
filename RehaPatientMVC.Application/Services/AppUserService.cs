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
    public class AppUserService : IAppUserService
    {
        public void AddAppUser(NewAppUserVm appUser)
        {
            throw new NotImplementedException();
        }

        public void DeleteAppUser(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AppUser> GetAllAppUserForList()
        {
            throw new NotImplementedException();
        }

        public NewAppUserVm GetAppUserForEdit(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAppUser(NewAppUserVm appUser)
        {
            throw new NotImplementedException();
        }

        public NewAppUserVm ViewAppUserDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
