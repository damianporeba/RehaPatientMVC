using RehaPatientMVC.Domain.Interface;
using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Infrastructure.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;
        public AppUserRepository(Context context)
        {
            _context = context;
        }

        public void AddNewUser(AppUser user)
        {
            _context.Users.Add(user);
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public void EditUser(AppUser user)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AppUser> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public AppUser GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
