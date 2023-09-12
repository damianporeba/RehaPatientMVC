using AutoMapper;
using RehaPatientMVC.Application.ViewModels.Medics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.MappingProfile.Medic
{
    public class AddNewMedicMappingProfile : Profile
    {
        public AddNewMedicMappingProfile()
        {
            CreateMap<RehaPatientMVC.Domain.Model.Medic, NewMedicVm>();
        }
    }
}
