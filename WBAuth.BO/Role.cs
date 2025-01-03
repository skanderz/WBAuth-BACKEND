﻿using System.Text.Json.Serialization;

namespace WBAuth.BO
{
    public class Role
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public int? Niveau { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public ICollection<Permission>? Permissions { get; set; }
        [JsonIgnore]
        public ICollection<UtilisateurApplication>? UtilisateurApplications { get; set; }
        public int IdApplication { get; set; }
        [JsonIgnore]
        public Application? Application { get; set; }

    }


}
