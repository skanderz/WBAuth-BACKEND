﻿using WBAuth.BO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WBAuth.BLL.IManager
{
    public interface IUtilisateurManager
    {
        Task<IEnumerable<Utilisateur>> ChargerAll();
        Task<Utilisateur> Recherche(int id);
        Task<int> Ajouter(Utilisateur oUtilisateur);
        Task<int> Modifier(Utilisateur oUtilisateur);
        Task<bool> Supprimer(int Id);
    }



}

