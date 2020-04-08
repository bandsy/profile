using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using profile.data.Enums;

namespace profile.data.ProfileModels {
    public class ProfileModel {

        public int Id { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public ProfileVisibilityEnum ProfileVisibility { get; set; }

        public GenderEnum Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public MediaModel ProfilePicture { get; set; }

        public string Bio { get; set; }

        public string PhoneNumber { get; set; }

        public string TimezoneId { get; set; }

        public List<string> Languages { get; set; }

        public List<MediaModel> Media { get; set; }

        public List<EventsModel> Events { get; set; }

        public List<DateTime> Availability { get; set; }

        public List<ExperienceModel> Experience { get; set; }

        public List<GearModel> GearModels { get; set; }

    }
}