using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.ViewModels.UserApp;
using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.Interfaces
{
    public interface IAdminService
    {
        public IQueryable GetAllAppUsers();
        void AddAppUser(User user);
        NewUserAppVm GetAppUserForEdit(int id);
        void UpdateAppUser(NewUserAppVm model);
        void DeleteAppUser(int id);
    }
}
