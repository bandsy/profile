using System.Collections.Generic;
using Newtonsoft.Json;
using profile.data.ProfileModels;

namespace profile.data.DTO {
    public class EventsDTO {

        [JsonProperty("m_ID")]
        public int m_ID { get; set; }

        [JsonProperty("events")]
        public List<EventsModel> Events { get; set; }
    }
}