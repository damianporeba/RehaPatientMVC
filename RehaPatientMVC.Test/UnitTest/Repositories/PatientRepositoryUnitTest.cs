using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RehaPatientMVC.Domain.Model;
using RehaPatientMVC.Infrastructure;
using RehaPatientMVC.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RehaPatientMVC.Test.UnitTest.Repositories
{
    public class PatientRepositoryUnitTest
    {
        [Fact]
        public void CheckReturnedIdAfterAddNewPatient()
        {
            //Arrange
            var patient = new Patient
            {
                Id = 10,
                Name = "Test",
                LastName = "Test",
                Pesel = "98989898989"
            };

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "RehaPatientMVC")
                .Options;

            //Act
            using (var context = new Context(options))
            {
                var patientRepository = new PatientRepository(context);
                var patientResult = patientRepository.AddPatient(patient);

                //Assert
                patientResult.Should().NotBe(null);
            }
        }

        [Fact]
        public void CheckIsPatientExistAfterRemove()
        {
            var patientToRemove = new Patient
            {
                Id = 11,
                Name = "Test",
                LastName = "Test",
                Pesel = "98989898989"
            };

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "RehaPatientMVC")
                .Options;

            //Act
            using (var context = new Context(options))
            {
                var patientRepository = new PatientRepository(context);
                patientRepository.DeletePatient(patientToRemove.Id);
                var patientDetails = patientRepository.GetPatientById(11);

                //Assert

                patientDetails.Should().BeNull();
            }
        }

        [Fact]
        public void CheckReturnedPatientList()
        {
            //Arrange
            var patient = new Patient
            {
                Id = 11,
                Name = "Test",
                LastName = "Test",
                Pesel = "98989898989"
            };

            var patient2 = new Patient
            {
                Id = 12,
                Name = "Test",
                LastName = "Test",
                Pesel = "98989898989"
            };

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "RehaPatientMVC")
                .Options;

            //Act
            using (var context = new Context(options))
            {
                var patientRepository = new PatientRepository(context);
                patientRepository.AddPatient(patient);
                patientRepository.AddPatient(patient2);
                var patientList = patientRepository.GetAllPatients();

                //Assert
                patientList.Should().NotBeNull();
                patientList.Should().HaveCount(2);
                patientList.Should().Contain(patient);
                patientList.Should().Contain(patient2);
            }
        }
    }
}
