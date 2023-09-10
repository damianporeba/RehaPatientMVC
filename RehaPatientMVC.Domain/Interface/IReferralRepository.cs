using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Domain.Interface
{
    public interface IReferralRepository
    {
        void DeleteReferral(int referralId);
        int AddReferral(Referral referral);
    }
}
