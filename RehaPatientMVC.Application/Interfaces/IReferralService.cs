using RehaPatientMVC.Application.ViewModels.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RehaPatientMVC.Application.Services.ReferralService;


namespace RehaPatientMVC.Application.Interfaces
{
    public interface IReferralService
    {
        public int AddReferral(NewRefferalVm referral);
    }
}
