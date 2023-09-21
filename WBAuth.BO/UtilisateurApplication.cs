﻿namespace WBAuth.BO
{
    public class UtilisateurApplication
    {
        public int Id { get; set; }
        public int IdRole { get; set; }
        public Role? Role { get; set; }
        public int IdUtilisateur { get; set; }
        public Utilisateur? Utilisateur { get; set; }
        public int IdApplication { get; set; }
        public Application? Application { get; set; }
        public bool Acces { get; set; } = true;


    }
}
