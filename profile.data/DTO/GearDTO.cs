using System.Collections.Generic;
using Newtonsoft.Json;
using profile.data.ProfileModels;

namespace profile.data.DTO {
    public class GearDTO {

        [JsonProperty("m_ID")]
        public int m_ID { get; set; }

        [JsonProperty("gear")]
        public List<GearModel> Gear { get; set; }
    }
}