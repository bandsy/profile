using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace profile.data.BlockingModels {
    public class BlockedModel {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int m_Id { get; set; }
        public int b_Id { get; set; }
    }
}