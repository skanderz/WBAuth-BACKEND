﻿using WBAuth.BO;


namespace WBAuth.BLL.IManager
{
    public interface IRoleManager
    {
        Task<IEnumerable<Role>> ChargerAll(int IdApplication);
        Task<Role> Recherche(int Id);
        Task<int> Ajouter(Role oRole);
        Task<int> Modifier(Role oRole);
        Task<bool> Supprimer(int Id);
    }



}


