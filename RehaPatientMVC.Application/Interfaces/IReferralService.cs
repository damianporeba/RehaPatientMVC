using RehaPatientMVC.Application.ViewModels.Referral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.Interfaces
{
    public interface IReferralService
    {
        public ListReferralForListVm GetAllReferralsForList (int pageSize, int PageNo, string SearchString);
    }
}
