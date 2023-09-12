using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WBAuth.DAL.Models
{
    [Table("Journalisation")]
    public class Journalisation{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }



        [Column("AdresseIP", TypeName = "VARCHAR(50)")]
        public string? AdresseIP { get; set; }



        [Column("DateConnexion", TypeName = "datetime")]
        public DateTime DateConnexion { get; set; }



        [ForeignKey("Utilisateur")]
        public int IdUtilisateur { get; set; }
        public Utilisateur? Utilisateur { get; set; }
        public ICollection<Action>? Actions { get; set; }

    }
}


