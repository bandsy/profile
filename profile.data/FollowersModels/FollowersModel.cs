using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace profile.data.FollowersModels {
    public class FollowersModel {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int m_Id { get; set; }
        public int f_Id { get; set; }
    }
}