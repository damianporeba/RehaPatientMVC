using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.MappingProfile.ContactDetails
{
    public class NewContactDetailsVmMappingProfile : Profile
    {
        public NewContactDetailsVmMappingProfile()
        {
            CreateMap<Domain.Model.ContactDetails, NewContactDetailsVmMappingProfile>();
        }
    }
}
