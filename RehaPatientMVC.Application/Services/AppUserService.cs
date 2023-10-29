using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.ViewModels.UserApp;
using RehaPatientMVC.Domain.Interface;
using RehaPatientMVC.Domain.Model;
using RehaPatientMVC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AppUserService(IAppUserRepository appUserRepository, IMapper mapper)
        {
            _userRepository = appUserRepository;
            _mapper = mapper;
        }

        public void AddAppUser(NewAppUserVm appUser)
        {
            var patient = _mapper.Map<AppUser>(appUser);
            _userRepository.AddNewAppUser(patient);
        }

        public void DeleteAppUser(int id)
        {
            _userRepository.DeleteAppUser(id);
        }

        public IQueryable<AppUser> GetAllAppUserForList()
        {
            var users = _userRepository.GetAllAppUser();
            return users;
        }

        public NewAppUserVm GetAppUserForEdit(int id)
        {
            var user = _userRepository.GetAppUserById(id);
            var userToEdit = _mapper.Map<NewAppUserVm>(user);
            return userToEdit;
        }

        public void UpdateAppUser(NewAppUserVm appUser)
        {
            throw new NotImplementedException();
        }

        public NewAppUserVm ViewAppUserDetails(int id)
        {
            var user = _userRepository.GetAppUserById(id);
            var userMap = _mapper.Map<NewAppUserVm>(user);
            return userMap;
        }
    }
}
