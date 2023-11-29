using Microsoft.EntityFrameworkCore;
using RehaPatientMVC.Domain.Model;
using RehaPatientMVC.Infrastructure.Repositories;
using RehaPatientMVC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace RehaPatientMVC.Test.UnitTest.Repositories
{
    public class AppUserRepositoryUnitTest
    {
        [Fact]
        public void CheckAppUserExistAfterAdd()
        {
            //Arrange
            var appUser = new AppUser
            {
                Id = 10,
                UserFirstName = "Test",
                UserLastName = "Test",
                City = "Tarnów"
            };

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "RehaPatientMVC")
                .Options;

            //Act
            using (var context = new Context(options))
            {
                var appUserRepository = new AppUserRepository(context);
                appUserRepository.AddNewAppUser(appUser);
                var result = appUserRepository.GetAppUserById(10);

                //Assert
                result.Should().Be(appUser);
            }
        }

        [Fact]
        public void CheckAppUserExistAfterRemove()
        {
            //Arrange
            var appUser = new AppUser
            {
                Id = 10,
                UserFirstName = "Test",
                UserLastName = "Test",
                City = "Tarnów"
            };

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "RehaPatientMVC")
                .Options;

            //Act
            using (var context = new Context(options))
            {
                var appUserRepository = new AppUserRepository(context);
                appUserRepository.AddNewAppUser(appUser);
                appUserRepository.DeleteAppUser(10);
                var result = appUserRepository.GetAppUserById(10);

                //Assert
                result.Should().BeNull();
            }
        }
    }
}
