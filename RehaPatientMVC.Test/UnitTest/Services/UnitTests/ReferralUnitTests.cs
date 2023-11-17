using AutoMapper;
using FluentAssertions;
using Moq;
using RehaPatientMVC.Application.Services;
using RehaPatientMVC.Application.ViewModels.Referral;
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
    public class ReferralUnitTests
    {
        [Fact]
        public void CheckReferralIdAfterAdd()
        {
            //Arrange
            Referral referral = new Referral()
            {
                Id = 10,
                Code = "0000"
            };

            NewReferralVm referralVm = new NewReferralVm()
            {
                Id = 10,
                Code = "0000"
            };

            var mockRepository = new Mock<IReferralRepository>();
            mockRepository.Setup(x => x.AddReferral(referral)).Returns(referral.Id);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Referral>(It.IsAny<NewReferralVm>())).Returns(referral);

            var manager = new ReferralService(mockRepository.Object, mockMapper.Object);

            //Act
            var resultId = manager.AddReferral(referralVm);

            //Assert
            resultId.Should().Be(referral.Id);
        }
    }
}
