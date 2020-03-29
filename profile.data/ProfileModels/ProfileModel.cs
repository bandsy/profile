using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using profile.data.Enums;

namespace profile.data.ProfileModels {
    public class ProfileModel {

        public int Id { get; set; }

        [Required]
        [JsonProperty ("forename")]
        public string Forename { get; set; }

        [Required]
        [JsonProperty ("surname")]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        [JsonProperty ("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty ("profileVisibility")]
        public ProfileVisibilityEnum ProfileVisibility { get; set; }

        [JsonProperty ("gender")]
        public GenderEnum Gender { get; set; }

        [Required]
        [JsonProperty ("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [JsonProperty ("age")]
        public int Age { get; set; }

        [JsonProperty ("profilePicture")]
        public MediaModel ProfilePicture { get; set; }

        [JsonProperty ("bio")]
        public string Bio { get; set; }

        [Phone]
        [JsonProperty ("phoneNumber")]
        public string PhoneNumber { get; set; }

        //uses TimeZoneInfo.Id to get the relevant details such as utc offset etc.
        [JsonProperty ("timezoneId")]
        public string TimezoneId { get; set; }

        //stores the two letter iso language code 
        [JsonProperty ("languages")]
        public List<string> Languages { get; set; }

        [JsonProperty ("media")]
        public List<MediaModel> Media { get; set; }

        [JsonProperty ("events")]
        public List<EventsModel> Events { get; set; }

        [JsonProperty ("Availability")]
        public List<DateTime> Availability { get; set; }

        [JsonProperty ("experience")]
        public List<ExperienceModel> Experience { get; set; }

        [JsonProperty ("gear")]
        public List<GearModel> GearModels { get; set; }

    }
}