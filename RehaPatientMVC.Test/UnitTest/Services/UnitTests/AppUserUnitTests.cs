using AutoMapper;
using Microsoft.CodeAnalysis.Differencing;
using Moq;
using RehaPatientMVC.Application.Services;
using RehaPatientMVC.Application.ViewModels.UserApp;
using RehaPatientMVC.Domain.Interface;
using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RehaPatientMVC.Test.UnitTest.Services.UnitTests
{
    public class AppUserUnitTests
    {
        [Fact]
        public void CheckAppUserIdAfterAdd()
        {
            AppUser appUser = new AppUser()
            {
                Id = 1,
                City = "Tarnów",
                UserLastName = "Test",
                UserFirstName = "Test"
            };

            NewAppUserVm newAppUserVm = new NewAppUserVm()
            {
                Id = 1,
                City = "Tarnów",
                UserLastName = "Test",
                UserFirstName = "Test"
            };

            var mockRepository = new Mock<IAppUserRepository>();
            mockRepository.Setup(x => x.AddNewAppUser(It.IsAny<AppUser>()));

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<AppUser>(It.IsAny<NewAppUserVm>())).Returns(appUser);

            var manager = new AppUserService(mockRepository.Object, mockMapper.Object);

            //Act
            manager.AddAppUser(newAppUserVm);

            //Assert
            mockRepository.Verify(x=>x.AddNewAppUser(appUser));
        }
    }
}
