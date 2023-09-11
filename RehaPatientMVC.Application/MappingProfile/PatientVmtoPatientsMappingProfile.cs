using AutoMapper;
using RehaPatientMVC.Application.ViewModels.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.MappingProfile
{
    public class PatientVmtoPatientsMappingProfile : Profile
    {
        public PatientVmtoPatientsMappingProfile()
        {
            CreateMap<RehaPatientMVC.Domain.Model.Patient, NewPatientVm>();
        }
    }
}
