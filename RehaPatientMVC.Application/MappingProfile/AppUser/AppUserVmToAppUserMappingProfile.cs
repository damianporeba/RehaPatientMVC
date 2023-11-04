using AutoMapper;
using RehaPatientMVC.Application.ViewModels.UserApp;
using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.MappingProfile.AppUser
{
    public class AppUserVmToAppUserMappingProfile : Profile
    {
        public AppUserVmToAppUserMappingProfile()
        {
            CreateMap<NewAppUserVm, Domain.Model.AppUser>();
        }
    }
}
