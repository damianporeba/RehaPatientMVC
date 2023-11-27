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
        public void CheckIsExistReturnedPatientList()
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

        [Fact]
        public void CheckReturnedPatientIdFromSearchByPesel()
        {
            var patient = new Patient
            {
                Id = 11,
                Name = "Test",
                LastName = "Test",
                Pesel = "12345678910"
            };

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "RehaPatientMVC")
                .Options;

            //Act
            using (var context = new Context(options))
            {
                var patientRepository = new PatientRepository(context);
                patientRepository.AddPatient(patient);
                var patientId = patientRepository.GetPatientIdByPesel(patient.Pesel);

                //act
                patientId.Should().Be(11);
            }
        }

        [Fact]
        public void CheckReturnedPatientsByTypeId()
        {
            //arrange
            var patient = new Patient
            {
                Id = 11,
                Name = "Test",
                LastName = "Test",
                Pesel = "98989898989"
            };

            var referral = new Referral
            {
                Id = 11,
                Code = "0000",
                PatientId = 11,
                ICD10 = "M54",
                Pesel = "98989898989",
                TypeReferral = "Ambulatory"
            };

            var options = new DbContextOptionsBuilder<Context>()
               .UseInMemoryDatabase(databaseName: "RehaPatientMVC")
               .Options;

            //act
            using (var context = new Context(options))
            {
                var patientRepository = new PatientRepository(context);
                var referralRepository = new ReferralRepository(context);

                patientRepository.AddPatient(patient);
                referralRepository.AddReferral(referral);

                var getPatientByType = patientRepository.GetPatientByType("Ambulatory");

                //Assert
                getPatientByType.Should().NotBeNull();
                getPatientByType.Should().Equal(patient);
            }
        }
    }
}
