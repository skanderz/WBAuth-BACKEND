using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WBAuth.DAL.Models
{
    [Table("Action")]
    public class Action
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }


        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }


        [Column("Description", TypeName = "TEXT")]
        public string? Description { get; set; }


        [ForeignKey("Journalisation")]
        public int IdJournalisation { get; set; }
        public Journalisation? Journalisation { get; set; }


    }
}