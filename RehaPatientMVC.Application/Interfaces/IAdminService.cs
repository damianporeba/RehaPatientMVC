using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.Interfaces
{
    public interface IAdminService
    {
        IQueryable<RoleVm> GetAllRoles();
        void RemoveRoleFromUser ()

    }
}
