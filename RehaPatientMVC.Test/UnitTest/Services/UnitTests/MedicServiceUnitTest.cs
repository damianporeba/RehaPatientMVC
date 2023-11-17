﻿using AutoMapper;
using FluentAssertions;
using Moq;
using RehaPatientMVC.Application.Services;
using RehaPatientMVC.Application.ViewModels.Medics;
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
    public class MedicServiceUnitTest
    {
        [Fact]
        public void CheckMedicIdAfterAdd()
        {
            //Arrange
            Medic medic = new Medic()
            {
                Id = 10,
                Name = "Test",
                LastName = "Test",
                Degree = "Msc",
                Profession = "Physio"
            };

            NewMedicVm medicVm = new NewMedicVm()
            {
                Id = 10,
                Name = "Test",
                LastName = "Test",
                Degree = "Msc",
                Profession = "Physio"
            };

            var mockRepository = new Mock<IMedicRepository>();
            mockRepository.Setup(x => x.AddMedic(medic)).Returns(medic.Id);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Medic>(It.IsAny<NewMedicVm>())).Returns(medic);

            var manager = new MedicService(mockMapper.Object, mockRepository.Object);

            //Act
            var resultId = manager.AddMedic(medicVm);

            //Assert
            resultId.Should().Be(medic.Id);
        }
    }
}
