namespace WBAuth.DAO.Models
{
    public class Role
    {

        public int IdRole { get; set; }
        public string? Nom { get; set; }
        public int? Niveau { get; set; }
        public string? Description { get; set; }
        public ICollection<Permission>? Permissions { get; set; }
        public ICollection<UtilisateurApplication>? UtilisateurApplications { get; set; }
        public int IdApplication { get; set; }
        public Application? Application { get; set; }

    }


}

