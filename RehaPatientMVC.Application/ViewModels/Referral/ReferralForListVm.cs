using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.ViewModels.Referral
{
    public class ReferralForListVm
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Pesel { get; set; }
        public string ICD10 { get; set; }
        public string TypeReferral { get; set; }
        public int MedicId { get; set; }
        public int PatientId { get; set; }
    }
}
