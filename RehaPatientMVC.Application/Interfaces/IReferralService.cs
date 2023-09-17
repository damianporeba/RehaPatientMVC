using RehaPatientMVC.Application.ViewModels.Referral;
using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.Interfaces
{
    public interface IReferralService
    {
        void DeleteReferral(int id);
        ListReferralForListVm GetAllReferralsForList (int pageSize, int PageNo, string SearchString);
        int AddReferral (NewReferralVm refferal);
        List<Medic> GetAllMedicsForList();
        int GetPatientIdByPesel(string pesel);
    }
}
