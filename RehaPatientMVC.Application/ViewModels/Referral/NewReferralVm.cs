using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.ViewModels.Referral
{
    public class NewReferralVm
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Pesel { get; set; }
        public string ICD10 { get; set; }
        public string TypeReferral { get; set; }
        public int MedicId { get; set; }
        public int PatientId { get; set; }
    }

    public class NewReferralValidation : AbstractValidator<NewReferralVm>
    {
        public NewReferralValidation() 
        {
            RuleFor(x=>x.Code).NotNull();
            RuleFor(x => x.Pesel).Length(11);
            RuleFor(x => x.TypeReferral).NotNull();
            RuleFor(x => x.MedicId).NotNull();
        }
    }
}
