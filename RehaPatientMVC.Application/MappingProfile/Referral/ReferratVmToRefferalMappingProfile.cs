using AutoMapper;
using RehaPatientMVC.Application.ViewModels.Referral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.MappingProfile.Referral
{
    public class ReferratVmToRefferalMappingProfile : Profile
    {
        public ReferratVmToRefferalMappingProfile()
        {
            CreateMap<RehaPatientMVC.Domain.Model.Referral, NewReferralVm>();
        }
    }
}
