using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace WBAuth.DAL.Models{
    [Table("Fonction")]
    public class Fonction{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdApplication")]
        public int IdFonction { get; set; }


        [Required]
        [Column("NomAction", TypeName = "VARCHAR(50)")]
        public string? NomAction { get; set; }


        [Column("Description", TypeName = "TEXT")]
        public string? Description { get; set; }


        public Permission? Permission { get; set; }


        [ForeignKey("Application")]
        public int IdApplication { get; set; }
        public Application? Application { get; set; }

    }
}
