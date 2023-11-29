using Microsoft.CodeAnalysis.Differencing;
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
    public class ReferralRepositoryUnitTest
    {
        [Fact]
        public void CheckReferralExistAfterAdd()
        {
            Referral referral = new Referral
            {
                Id = 10,
                ICD10 = "M54",
                Code = "0000",
                Pesel = "00000000000",
                PatientId = 1,
                MedicId = 1,
                TypeReferral = "Ambulatory"
            };
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "RehaPatientMVC")
                .Options;

            //Act
            using (var context = new Context(options))
            {
                var refRepository = new ReferralRepository(context);
                var medicResult = refRepository.AddReferral(referral);

                //Assert
                medicResult.Should().Be(10);
            }
        }

        [Fact]
        public void CheckReferralExistAfterRemove()
        {
            Referral referral = new Referral
            {
                Id = 10,
                ICD10 = "M54",
                Code = "0000",
                Pesel = "00000000000",
                PatientId = 1,
                MedicId = 1,
                TypeReferral = "Ambulatory"
            };
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "RehaPatientMVC")
                .Options;

            //Act
            using (var context = new Context(options))
            {
                var refRepository = new ReferralRepository(context);
                var medicResult = refRepository.AddReferral(referral);
                refRepository.DeleteReferral(referral.Id);
                var result = refRepository.GetAllReferrals();

                //Assert
                result.Should().BeEmpty();
            }
        }

    }
}
