﻿using RehaPatientMVC.Application.ViewModels.ContactDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.Interfaces
{
    public interface IContactDetailsService
    {
        public int AddContactDetails(NewContactDetailsVm contactDetailsVm);
        public void DeleteContactDetails(int id);
    }
}
