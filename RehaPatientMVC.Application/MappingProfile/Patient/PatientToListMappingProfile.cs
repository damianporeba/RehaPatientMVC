using AutoMapper;
using RehaPatientMVC.Application.ViewModels.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.MappingProfile
{
    public class PatientToListMappingProfile : Profile
    {
        public PatientToListMappingProfile()
        {
            CreateMap<RehaPatientMVC.Domain.Model.Patient, PatientForListVm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Pesel, opt => opt.MapFrom(src => src.Pesel));
        }
    }
}
