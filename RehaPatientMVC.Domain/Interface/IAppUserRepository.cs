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
        IQueryable<AppUser> GetAllUsers();
        void AddNewUser (AppUser user);
        void DeleteUser (int id);
        AppUser GetUserById (int id);
        void EditUser (AppUser user);
    }
}
