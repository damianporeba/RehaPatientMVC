using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.ViewModels.AppUser;
using RehaPatientMVC.Application.ViewModels.Medics;
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

        public ListAppUserForListVm GetAllAppUserForList(int pageSize, int pageNo, string searchString)
        {
            var appUsers = _userRepository.GetAllAppUser().Where(p => p.UserFirstName.StartsWith(searchString)).ProjectTo<NewAppUserVm>(_mapper.ConfigurationProvider).ToList();
            var appUserToShow = appUsers.Skip(pageSize * (pageNo-1)).Take(pageSize).ToList();
            var userList = new ListAppUserForListVm
            {
                PageNo = pageNo,
                PageSize = pageSize,
                AppUsers = appUserToShow,
                Count = appUserToShow.Count()
            };
            return userList;
        }

        public NewAppUserVm GetAppUserForEdit(int id)
        {
            var user = _userRepository.GetAppUserById(id);
            var userToEdit = _mapper.Map<NewAppUserVm>(user);
            return userToEdit;
        }

        public void UpdateAppUser(NewAppUserVm appUser)
        {
            var userToEdit = _mapper.Map<AppUser>(appUser);
            _userRepository.UpdateAppUser(userToEdit);
        }

        public NewAppUserVm ViewAppUserDetails(int id)
        {
            var user = _userRepository.GetAppUserById(id);
            var userMap = _mapper.Map<NewAppUserVm>(user);
            return userMap;
        }
    }
}
