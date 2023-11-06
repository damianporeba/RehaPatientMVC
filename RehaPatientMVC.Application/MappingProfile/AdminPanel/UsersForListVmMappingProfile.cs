using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RehaPatientMVC.Application.ViewModels.AdminPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.MappingProfile.AdminPanel
{
    public class UsersForListVmMappingProfile : Profile
    {
        public UsersForListVmMappingProfile()
        {
            CreateMap<IdentityUser, UsersForListVM>();
        }
    }
}
