using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.ViewModels.AppUser;
using RehaPatientMVC.Application.ViewModels.UserApp;
using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.Interfaces
{
    public interface IAppUserService
    {
        ListAppUserForListVm GetAllAppUserForList(int pageSize, int PageNo, string SearchString);
        void AddAppUser (NewAppUserVm appUser);
        NewAppUserVm ViewAppUserDetails (int id);
        NewAppUserVm GetAppUserForEdit (int id);
        void DeleteAppUser (int id);
        void UpdateAppUser (NewAppUserVm appUser);
    }
}
