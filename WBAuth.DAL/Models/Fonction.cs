using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;




namespace WBAuth.DAL.Models
{
    [Table("Fonction")]
    public class Fonction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }


        [Required]
        [Column("Nom", TypeName = "VARCHAR(MAX)")]
        public string? Nom { get; set; }


        [Required]
        [Column("Type", TypeName = "VARCHAR(50)")]
        public string? Type { get; set; }


        [Column("Description", TypeName = "TEXT")]
        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<Permission>? Permissions { get; set; }


        [ForeignKey("Application, DeleteBehavior = DeleteBehavior.Cascade")]
        public int IdApplication { get; set; }
        [JsonIgnore]
        public Application? Application { get; set; }

    }
}
