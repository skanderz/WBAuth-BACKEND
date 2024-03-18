using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WBAuth.DAL.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Nom", TypeName = "VARCHAR(MAX)")]
        public string? Nom { get; set; }

        public int? Niveau { get; set; }

        [Column("Description", TypeName = "TEXT")]
        public string? Description { get; set; }

        public ICollection<Permission>? Permissions { get; set; }
        public ICollection<UtilisateurApplication>? UtilisateurApplications { get; set; }

        [ForeignKey("Application")]
        public int IdApplication { get; set; }
        public Application? Application { get; set; }


    }


}
