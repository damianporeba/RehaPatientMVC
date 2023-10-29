using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public void AddNewAppUser(AppUser appUser)
        {
            _context.appUsers.Add(appUser);
            if(appUser != null )
            {
                _context.SaveChanges();
            }
        }

        public void DeleteAppUser(int id)
        {
            var userToRemove = _context.appUsers.FirstOrDefault(x => x.Id == id);
            if (userToRemove != null)
            {
                _context.appUsers.Remove(userToRemove);
                _context.SaveChanges();
            }
        }

        public IQueryable<AppUser> GetAllAppUser()
        {
            var users = _context.appUsers;
            return users; 
        }

        public AppUser GetAppUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAppUser(AppUser appUser)
        {
            throw new NotImplementedException();
        }
    }
}
