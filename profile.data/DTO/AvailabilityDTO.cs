using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using profile.data.Enums;
using profile.data.ProfileModels;

namespace profile.data.DTO {
    public class AvailabilityDTO {

        [JsonProperty("m_ID")]
        public int m_ID { get; set; }

        [JsonProperty("availabilities")]
        public List<AvailabilityModel> Availabilities { get; set; }

    }
}