using AutoMapper;
using RehaPatientMVC.Application.ViewModels.Referral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.MappingProfile.Referral
{
    public class ReferralToListMappingProfile : Profile
    {
        public ReferralToListMappingProfile()
        {
            CreateMap<RehaPatientMVC.Domain.Model.Referral, ReferralForListVm>();
        }
    }
}
