using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using profile.data.Enums;
using profile.data.ProfileModels;

namespace profile.data.DTO {
    public class ProfileDTO {
        [JsonProperty ("id")]
        public int Id { get; set; }

        [JsonProperty ("forename")]
        public string Forename { get; set; }

        [JsonProperty ("surname")]
        public string Surname { get; set; }

        [EmailAddress]
        [JsonProperty ("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty ("profileVisibility")]
        public ProfileVisibilityEnum ProfileVisibility { get; set; }

        [JsonProperty ("gender")]
        public GenderEnum Gender { get; set; }

        [JsonProperty ("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty ("age")]
        public int Age { get; set; }

        //TODO profile pic
        //[JsonProperty("profilePicture")]
        //public MediaModel ProfilePicture { get; set; }

        [JsonProperty ("bio")]
        public string Bio { get; set; }

        [Phone]
        [JsonProperty ("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty ("currentDateTime")]
        public DateTime CurentDateTime { get; set; }

        [JsonProperty ("languages")]
        public List<string> Languages { get; set; }

        //TODO media 
        //[JsonProperty("media")]
        //public List<MediaModel> Media { get; set; }

        [JsonProperty ("events")]
        public List<EventsModel> Events { get; set; }

        [JsonProperty ("availability")]
        public List<DateTime> Availability { get; set; }

        [JsonProperty ("experience")]
        public List<ExperienceModel> Experience { get; set; }

        [JsonProperty ("gear")]
        public List<GearModel> GearModels { get; set; }
    }
}