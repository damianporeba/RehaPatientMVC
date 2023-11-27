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
    }
}
