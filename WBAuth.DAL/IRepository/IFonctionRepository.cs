﻿using WBAuth.DAL.Models;


namespace WBAuth.DAL.IRepository
{
    public interface IFonctionRepository
    {
        Task<IEnumerable<Fonction>> ChargerAll(int IdApplication);
        Task<IEnumerable<Fonction>> Recherche(string rech, int IdApplication);
        Task<Fonction> RechercheById(int Id);
        Task<int> Ajouter(Fonction oFonction, int IdApplication);
        Task<int> Modifier(Fonction oFonction, int IdApplication);
        Task<bool> Supprimer(int Id, int IdApplication);
    }
}
