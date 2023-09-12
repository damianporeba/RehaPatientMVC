using AutoMapper;
using RehaPatientMVC.Application.ViewModels.Patients;
using RehaPatientMVC.Domain.MappingProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.MappingProfile.Patient
{
    public class AddNewPatientMappingProfile : Profile
    {
        public AddNewPatientMappingProfile()
        {
            CreateMap<NewPatientVm, Domain.Model.Patient>();
        }
    }
}
