using RehaPatientMVC.Domain.Interface;
using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Infrastructure.Repositories
{
    public class ReferralRepository : IReferralRepository
    {
        private readonly Context _context;
        public ReferralRepository(Context context)
        {
            _context = context;
        }

        public int AddReferral(Referral referral)
        {
            _context.referrals.Add(referral);
            _context.SaveChanges();
            return referral.Id;
        }

        public void DeleteReferral(int referralId)
        {
            var referralRemove = _context.referrals.Find(referralId);
            if (referralRemove != null)
            {
                _context.referrals.Remove(referralRemove);
                _context.SaveChanges();
            }
        }

        

        public IQueryable<Referral> GetAllReferrals()
        {
            var referrals = _context.referrals;
            return referrals;
        }

        public int GetPatientIdByPesel(string pesel)
        {
            var patient = _context.patients.FirstOrDefault(p=>p.Pesel == pesel);
            return patient.Id;
        }
    }
}
