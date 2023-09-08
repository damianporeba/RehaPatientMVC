using AutoMapper;
using RehaPatientMVC.Application.ViewModels.Patients;
using RehaPatientMVC.Domain.MappingProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.MappingProfile
{
    public class AddNewPatientMappingProfile : Profile
    {
        public AddNewPatientMappingProfile()
        {
            CreateMap<NewPatientVm, RehaPatientMVC.Domain.Model.Patient>();
        }
    }
}
