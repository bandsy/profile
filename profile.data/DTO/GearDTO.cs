using System.Collections.Generic;
using profile.data.ProfileModels;

namespace profile.data.DTO {
    public class GearDTO {
        public int m_ID { get; set; }
        public List<GearModel> Gear { get; set; }
    }
}