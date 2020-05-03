using System;

namespace profile.data.ProfileModels.Profile {
    public class ProfileAvailabilityModel {
        public int Id { get; set; }
        public string Day { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}