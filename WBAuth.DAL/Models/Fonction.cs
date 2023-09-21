using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



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
        [Column("NomAction", TypeName = "VARCHAR(50)")]
        public string? Nom { get; set; }


        [Required]
        [Column("Type", TypeName = "VARCHAR(50)")]
        public string? Type { get; set; }


        [Column("Description", TypeName = "TEXT")]
        public string? Description { get; set; }


        public Permission? Permission { get; set; }


        [ForeignKey("Application, DeleteBehavior = DeleteBehavior.NoAction")]
        public int IdApplication { get; set; }
        public Application? Application { get; set; }

    }
}
