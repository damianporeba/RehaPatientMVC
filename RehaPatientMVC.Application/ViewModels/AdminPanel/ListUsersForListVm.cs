using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.ViewModels.AdminPanel
{
    public class ListUsersForListVm
    {
        public List<UsersForListVM> Users { get; set;}
        public int count { get; set;}
    }
}
