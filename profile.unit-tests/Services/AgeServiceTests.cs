using System;
using System.Reflection.Metadata;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using profile.api.Services.AgeService;

namespace profile.unit_tests.Services {
    [TestFixture]
    public class AgeServiceTests {
        private IAgeService _ageService;

        [SetUp]
        public void Setup() {
            _ageService = Substitute.For<IAgeService>();
        }

        [Test]
        public void CalculateAge_AllOk_ReturnsInt() {
            //arrange
            var age = 24;
            var birthDate = new DateTime(1995, 05, 12);
            _ageService.CalculateAge(Arg.Any<DateTime>()).Returns(age);

            //act
            var result = _ageService.CalculateAge(birthDate);

            //assert
            result.Should().BeOfType(typeof(int)).And.Be(24);
        }
    }
}