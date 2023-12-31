﻿using Microsoft.EntityFrameworkCore;
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

        [Fact]
        public void CheckReturnedAppUserIsValidWithId()
        {
            //Arrange
            var appUser = new AppUser
            {
                Id = 10,
                UserFirstName = "Test",
                UserLastName = "Test",
                City = "Tarnów"
            };

            var appUser2 = new AppUser
            {
                Id = 11,
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
                appUserRepository.AddNewAppUser(appUser2);
                var result = appUserRepository.GetAppUserById(10);

                //Assert
                result.Should().NotBeNull();
                result.Should().NotBe(appUser2);
                result.Should().Be(appUser);
            }
        }

        [Fact]
        public void CheckReturnedListIsValidWithModels()
        {
            //Arrange
            var appUser = new AppUser
            {
                Id = 10,
                UserFirstName = "Test",
                UserLastName = "Test",
                City = "Tarnów"
            };

            var appUser2 = new AppUser
            {
                Id = 11,
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
                appUserRepository.AddNewAppUser(appUser2);
                var result = appUserRepository.GetAllAppUser();

                //Assert
                result.Should().NotBeNullOrEmpty();
                result.Should().HaveCount(2);
                result.Should().Contain(appUser2);
                result.Should().Contain(appUser);
            }
        }
    }
}
