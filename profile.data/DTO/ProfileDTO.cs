using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using profile.data.Enums;
using profile.data.ProfileModels;
using profile.data.ProfileModels.Profile;

namespace profile.data.DTO {
    public class ProfileDTO {
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty("m_ID")]
        public int m_ID { get; set; }

        [JsonProperty("forename")]
        public string Forename { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [EmailAddress]
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("profileVisibility")]
        public string ProfileVisibility { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        //TODO profile pic
        //[JsonProperty("profilePicture")]
        //public MediaModel ProfilePicture { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [Phone]
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("languages")]
        public List<string> Languages { get; set; }

        //TODO media 
        //[JsonProperty("media")]
        //public List<MediaModel> Media { get; set; }

        [JsonProperty("events")]
        public List<EventsModel> Events { get; set; }

        [JsonProperty("availability")]
        public List<DateTime> Availability { get; set; }

        [JsonProperty("experience")]
        public List<ProfileExperienceModel> Experience { get; set; }

        [JsonProperty("gear")]
        public List<ProfileGearModel> GearModels { get; set; }
    }
}