using profile.data.Enums;

namespace profile.data.ProfileModels {
    public class ExperienceModel {
        public int Id { get; set; }
        public int Years { get; set; }
        public InstrumentEnum Instrument { get; set; }
    }
}