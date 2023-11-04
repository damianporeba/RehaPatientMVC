﻿using RehaPatientMVC.Application.ViewModels.UserApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.ViewModels.AppUser
{
    public class ListAppUserForListVm
    {
        public List<NewAppUserVm> AppUsers { get; set; }
        public int PageSize { get; set; }
        public int PageNo { get; set; }
        public int CurrentPage { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
