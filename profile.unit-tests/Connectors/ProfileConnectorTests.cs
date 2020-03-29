using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NUnit.Framework;
using profile.api.Connectors.ProfileConnector;
using profile.api.EntityFramework;
using profile.data.ProfileModels;

namespace profile.unit_tests.Connectors {

    [TestFixture]
    public class ProfileConnectorTests {

        public ProfileApiDbContext _profileApiDbContext;
        public IProfileConnector _profileConnector;
        public DbSet<ProfileModel> _mockProfileSet;

        [SetUp]
        public void Setup () {
            _profileApiDbContext = Substitute.For<ProfileApiDbContext> ();
            _profileConnector = Substitute.For<ProfileConnector> ();

            _mockProfileSet = Substitute.For<DbSet<ProfileModel>> ();

        }

        [Test]
        public async void GetAllProfiles_AllOk_ReturnsList () {

            var profiles = new List<ProfileModel> {
                new ProfileModel {

                },
                new ProfileModel {

                }
            }.AsQueryable ();

            _profileApiDbContext.Profiles.Returns (profiles);

            var results = await _profileConnector.GetAllProfiles ();

            results.Should ().HaveCount (2)
                .And.AllBeOfType<ProfileModel> ();

            await _profileConnector.Received ().GetAllProfiles ();
            _profileApiDbContext.ReceivedCalls ();

        }
    }
}