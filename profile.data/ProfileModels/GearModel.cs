using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using profile.data.Enums;

namespace profile.data.ProfileModels {
    public class GearModel {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public InstrumentEnum Instrument { get; set; }
        public string Info { get; set; }

    }
}