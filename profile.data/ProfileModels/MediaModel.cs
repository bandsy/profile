using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace profile.data.ProfileModels {
    public class MediaModel {
        //TODO IMPLEMENT WHEN MORE BLOB DETAILS ARE KNOWN

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}