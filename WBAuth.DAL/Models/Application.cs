using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WBAuth.BO.Validators;


namespace WBAuth.DAL.Models
{
    [Table("Application")]
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }


        [Required]
        [Column("Nom", TypeName = "VARCHAR(50)")]
        public string? Nom { get; set; }



        [Column("Description", TypeName = "TEXT")]
        public string? Description { get; set; }



        [Column("Url", TypeName = "VARCHAR(50)")]
        public string? Url { get; set; }


        [JsonIgnore]
        [Column("Logo", TypeName = "varbinary(max)")]
        [AllowedImageExtensions(".png", ".jpg", ".jpeg", ".gif", ".bmp")]
        public byte[]? Logo { get; set; }
        public bool Auth2FA { get; set; } = false;
        public bool AuthGoogle { get; set; } = false;
        public bool AuthFacebook { get; set; } = false;
        public bool AuthLinkedIn { get; set; } = false;

        [JsonIgnore]
        public ICollection<UtilisateurApplication>? UtilisateurApplications { get; set; }

        [JsonIgnore]
        public ICollection<Fonction>? Fonctions { get; set; }

        [JsonIgnore]
        public ICollection<Role>? Roles { get; set; }



    }

}
