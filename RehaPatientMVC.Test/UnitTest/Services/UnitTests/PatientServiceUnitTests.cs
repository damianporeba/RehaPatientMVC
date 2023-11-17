using AutoMapper;
using FluentAssertions;
using FluentAssertions.Common;
using Moq;
using RehaPatientMVC.Application.MappingProfile.Patient;
using RehaPatientMVC.Application.Services;
using RehaPatientMVC.Application.ViewModels.Patients;
using RehaPatientMVC.Domain.Interface;
using RehaPatientMVC.Domain.Model;
using RehaPatientMVC.Web.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RehaPatientMVC.Test.UnitTest.Services.UnitTests
{
    public class PatientServiceUnitTests
    {
        [Fact]
        public void CheckPatientIdAfterAdd()
        {
            //Arrange

            NewPatientVm patientToAdd = new NewPatientVm()
            {
                Id = 10,
                Name = "Test",
                LastName = "Test",
                Pesel = "12341234123"
            };

            Patient patient = new Patient()
            {
                Id = 10,
                Name = "Test",
                LastName = "Test",
                Pesel = "12341234123"
            };

            var mock = new Mock<IPatientRepository>();
            mock.Setup(s=>s.AddPatient(patient)).Returns(patient.Id);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(s => s.Map<Patient>(It.IsAny<NewPatientVm>())).Returns(patient);

            var manager = new PatientService(mock.Object, mockMapper.Object);

            //Act
            var result = manager.AddPatient(patientToAdd);

            //Assert
            result.Should().Be(patient.Id);
        }

        [Fact]
        public void CheckPatientDetailsAreEqualLikeModel()
        {
            //Arrange
            Patient patient = new Patient()
            {
                Id = 10,
                Name = "Test",
                LastName = "Test",
                Pesel = "12312312312"
            };

            PatientDetailsVm patientVm = new PatientDetailsVm()
            {
                Id = 10,
                Name = "Test",
                LastName = "Test",
                Pesel = "12312312312"
            };

            var mock = new Mock<IPatientRepository>();
            mock.Setup(s => s.GetPatientById(10)).Returns(patient);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(s => s.Map<PatientDetailsVm>(It.IsAny<Patient>())).Returns(patientVm);

            var maganer = new PatientService(mock.Object, mockMapper.Object);
            //Act
            var patientDetails = maganer.ViewPatientDetails(10);

            //Assert
            patientDetails.Id.Should().Be(patient.Id);
            patientDetails.Name.Should().Be(patient.Name);
            patientDetails.LastName.Should().Be(patient.LastName);
            patientDetails.Pesel.Should().Be(patient.Pesel);
        }

        [Fact]
        public void CheckPatientForEditsAreEqualLikeModel()
        {
            //Arrange
            Patient patient = new Patient()
            {
                Id = 10,
                Name = "Test",
                LastName = "Test",
                Pesel = "12312312312"
            };

            NewPatientVm patientVm = new NewPatientVm()
            {
                Id = 10,
                Name = "Test",
                LastName = "Test",
                Pesel = "12312312312"
            };

            var mock = new Mock<IPatientRepository>();
            mock.Setup(s => s.GetPatientById(10)).Returns(patient);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(s => s.Map<NewPatientVm>(It.IsAny<Patient>())).Returns(patientVm);

            var maganer = new PatientService(mock.Object, mockMapper.Object);
            //Act
            var patientDetails = maganer.GetPatientForEdit(10);

            //Assert
            patientDetails.Id.Should().Be(patient.Id);
            patientDetails.Name.Should().Be(patient.Name);
            patientDetails.LastName.Should().Be(patient.LastName);
            patientDetails.Pesel.Should().Be(patient.Pesel);
        }

        [Fact]
        public void CheckPatientIdAreEqualWithPesel()
        {
            //Arrange
            Patient patient = new Patient()
            {
                Id = 10,
                Name = "Test",
                LastName = "Test",
                Pesel = "98082311272"
            };

            var mock = new Mock<IPatientRepository>();
            mock.Setup(s=>s.GetPatientIdByPesel("98082411272")).Returns(10);
            var mockMapper = new Mock<IMapper>();

            var manager = new PatientService(mock.Object, mockMapper.Object);

            //Act
            var patientId = manager.GetPatientIdByPesel("98082411272");

            //Assert
            patientId.Should().Be(patient.Id);
        }
    }
}
