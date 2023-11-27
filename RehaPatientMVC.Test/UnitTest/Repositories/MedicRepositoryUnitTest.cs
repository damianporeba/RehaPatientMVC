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
    public class MedicRepositoryUnitTest
    {
        [Fact]
        public void CheckMedicExistAfterAdd()
        {
            //Arrange
            var medic = new Medic
            {
                Id = 10,
                Name = "Test",
                LastName = "Test",
                Degree = "Msc",
                Profession = "Physio",
            };

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "RehaPatientMVC")
                .Options;

            //Act
            using (var context = new Context(options))
            {
                var medicRepository = new MedicRepository(context);
                var medicResult = medicRepository.AddMedic(medic);

                //Assert
                medicResult.Should().Be(10);
            }
        }

        [Fact]
        public void CheckAreReturnedMedicListIsValidWithMedics() 
        {
            //Arrange
            var medic = new Medic
            {
                Id = 10,
                Name = "Test",
                LastName = "Test",
                Degree = "Msc",
                Profession = "Physio",
            };

            var medic2 = new Medic
            {
                Id = 11,
                Name = "Test",
                LastName = "Test",
                Degree = "Msc",
                Profession = "Physio",
            };

            var options = new DbContextOptionsBuilder<Context>()
               .UseInMemoryDatabase(databaseName: "RehaPatientMVC")
               .Options;

            //Act
            using (var context = new Context(options))
            {
                var medicRepository = new MedicRepository(context);
                var medicToAdd1= medicRepository.AddMedic(medic);
                var medicToAdd2 = medicRepository.AddMedic(medic2);
                var medicsList = medicRepository.GetAllMedics();

                //Assert
                medicsList.Should().NotBeEmpty();
                medicsList.Should().HaveCount(2);
                medicsList.Should().Contain(medic);
                medicsList.Should().Contain(medic2);
            }
        }

        [Fact]
        public void CheckValidMedicAfterGettingHimById()
        {
            //Arrange
            var medic = new Medic
            {
                Id = 10,
                Name = "Test",
                LastName = "Test",
                Degree = "Msc",
                Profession = "Physio",
            };

            var options = new DbContextOptionsBuilder<Context>()
               .UseInMemoryDatabase(databaseName: "RehaPatientMVC")
               .Options;

            //Act
            using (var context = new Context(options))
            {
                var medicRepository = new MedicRepository(context);
                var medicToAdd = medicRepository.AddMedic(medic);
                var medicToGet = medicRepository.GetMedicById(10);

                //Act
                medicToGet.Should().Be(medic);
            }
        }

    }
}
