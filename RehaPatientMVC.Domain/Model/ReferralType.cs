using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Domain.Model
{
    public class ReferralType
    {
        public List<string> ReferralTypes = new List<string>()
        {
            "Ambulatory",
            "Home Referral",
            "Hospital",
        };
    }
}
