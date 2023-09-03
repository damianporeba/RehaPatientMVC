using AutoMapper;
using RehaPatientMVC.Application.ViewModels.Patients;
using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.Maping
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientForListVm>();
        }
    }
}
