using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using profile.data.Enums;

namespace profile.data.ProfileModels {
    public class ExperienceModel {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Years { get; set; }
        public InstrumentEnum Instrument { get; set; }
    }
}