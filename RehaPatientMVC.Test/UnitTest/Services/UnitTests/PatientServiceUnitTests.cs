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

            //MapperConfiguration mapperConfig = new MapperConfiguration(
            //cfg =>
            //{
            //    cfg.AddProfile(new AddNewPatientMappingProfile());
            //});

            //IMapper mapper = new Mapper(mapperConfig);
            //mapper.ConfigurationProvider.AssertConfigurationIsValid();

            var manager = new PatientService(mock.Object, mockMapper.Object);

            //Act
            var result = manager.AddPatient(patientToAdd);

            //Assert
            result.Should().Be(patient.Id);
        }
    }
}
