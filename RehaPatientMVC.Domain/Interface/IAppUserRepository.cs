using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Domain.Interface
{
    public interface IAppUserRepository
    {
        void AddNewAppUser(AppUser appUser);
        IQueryable<AppUser> GetAllAppUser();
        AppUser GetAppUserById(int id);
        void DeleteAppUser(int id);
        void UpdateAppUser(AppUser appUser);
    }
}
