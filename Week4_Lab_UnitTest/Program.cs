using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Week4_Lab.Repositories;
using FakeItEasy;
using Week4_Lab.Services;
using Week4_Lab.Data.Entities;

namespace Week4_Lab_UnitTest
{
    class Program
    {
        [TestFixture]
        public class PetServiceTests
        {
            private IPetRepo _petRespository;

            [SetUp]
            public void SetUp()
            {
                _petRespository = A.Fake<IPetRepo>();
            }

            [Test]
            public void ShouldNotIndicateCheckupAlert()
            {
                // Arrange
                A.CallTo(() => _petRespository.GetPet(A<int>.Ignored)).Returns(new Pet
                {
                    NextCheckup = DateTime.Now.AddDays(29)
                });

                // Act (SUT)
                var petService = new PetService(_petRespository);
                var petViewModel = petService.GetPet(1);

                // Assert
                Assert.IsFalse(petViewModel.NeedsCheckup);
            }

            [Test]
            public void ShouldIndicateCheckupAlert()
            {
                // Arrange
                A.CallTo(() => _petRespository.GetPet(A<int>.Ignored)).Returns(new Pet
                {
                    NextCheckup = DateTime.Now.AddDays(13)
                });

                // Act (SUT)
                var petService = new PetService(_petRespository);
                var petViewModel = petService.GetPet(1);

                // Assert
                Assert.IsTrue(petViewModel.NeedsCheckup);
            }
        }

        public class MainProgram
        {
            public static void Main(string[] args)
            {
            }
        }
    }
}
