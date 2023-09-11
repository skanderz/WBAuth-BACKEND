using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WBAuth.DAL.Models {
 [Table("Action")]
 public class Action{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdAction")]
        public int IdAction { get; set; }


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