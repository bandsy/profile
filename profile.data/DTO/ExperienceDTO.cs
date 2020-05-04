using System.Collections.Generic;
using Newtonsoft.Json;
using profile.data.ProfileModels;

namespace profile.data.DTO {
    public class ExperienceDTO {

        [JsonProperty("m_ID")]
        public int m_ID { get; set; }

        [JsonProperty("experience")]
        public List<ExperienceModel> Experience { get; set; }
    }
}