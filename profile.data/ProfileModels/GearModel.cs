using profile.data.Enums;

namespace profile.data.ProfileModels {
    public class GearModel {
        public int Id { get; set; }
        public InstrumentEnum Instrument { get; set; }
        public string Info { get; set; }

    }
}