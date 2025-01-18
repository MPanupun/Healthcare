using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marco.Models
{
    [Table("healthcheck", Schema = "insurance_archive")]
    public class HealthCheckEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(true)]
        [Column("id")]
        public long id { get; set; }
        [Column("message")]
        public string message { get; set; }
    }
}
