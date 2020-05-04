using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NUnit.Framework;
using profile.api.Connectors.Profile;
using profile.api.EntityFramework;
using profile.data.Enums;
using profile.data.ProfileModels;

namespace profile.unit_tests.Connectors
{

    [TestFixture]
    public class ProfileConnectorTests {

        private IProfileApiDbContext _dbContext;
        private IProfileConnector _profileConnector;
        private DbSet<ProfileModel> _profilesSet;

        private List<ProfileModel> _profileData = new List<ProfileModel> {
            new ProfileModel {
                Id = 1,
                 Forename = "jimbo",
                Surname = "jones",
                EmailAddress = "jj@email.com,",
                ProfileVisibility = ProfileVisibilityEnum.everyone,
                Gender = GenderEnum.Male,
                DateOfBirth = new DateTime (1995, 05, 12),
                Age = 24,
                 ProfilePicture = new MediaModel (),
                 PhoneNumber = "+447513400102",
                 Languages = new List<string> {
                        "English",
                        "Dutch"
                 },
                Media = new List<MediaModel> (),
                Events = new List<EventsModel> (),
                Availability = new List<AvailabilityModel>(),
                Experience = new List<ExperienceModel> {
                    new ExperienceModel {
                            Id = 1,
                            Years = 2,
                            Instrument = InstrumentEnum.Bass
                        }
                    },
                    GearModels = new List<GearModel> {
                        new GearModel {
                            Id = 1,
                                Instrument = InstrumentEnum.Bass,
                                Info = "p bass"
                        }
                    }
            },
            new ProfileModel {
                Id = 2,
                    Forename = "nelson",
                    Surname = "munz",
                    EmailAddress = "nm@email.com,",
                    ProfileVisibility = ProfileVisibilityEnum.users,
                    Gender = GenderEnum.Male,
                    DateOfBirth = new DateTime (1995, 05, 12),
                    Age = 24,
                    ProfilePicture = new MediaModel (),
                    PhoneNumber = "+447513400102",
                    Languages = new List<string> {
                        "English",
                        "Dutch"
                    },
                    Media = new List<MediaModel> (),
                    Events = new List<EventsModel> (),
                    Availability = new List<AvailabilityModel>(),
                    Experience = new List<ExperienceModel> {
                        new ExperienceModel {
                            Id = 2,
                                Years = 1,
                                Instrument = InstrumentEnum.Drums
                        }
                    },
                    GearModels = new List<GearModel> {
                        new GearModel {
                            Id = 2,
                                Instrument = InstrumentEnum.Drums,
                                Info = "big dorty drum kit"
                        }
                    }
            }
        };

        [SetUp]
        public void Setup () {
            _profileConnector = Substitute.For<IProfileConnector> ();
            _profilesSet = _profileData.ToFakeDbSet();
            _dbContext = Substitute.For<IProfileApiDbContext>();
        }

    }
}