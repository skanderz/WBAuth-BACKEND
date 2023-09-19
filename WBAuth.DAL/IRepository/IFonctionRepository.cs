using WBAuth.DAL.Models;


namespace WBAuth.DAL.IRepository
{
    public interface IFonctionRepository
    {
        Task<IEnumerable<Fonction>> ChargerAll(int IdApplication);
        Task<Fonction> Recherche(int Id ,int IdApplication);
        Task<int> Ajouter(Fonction oFonction ,int IdApplication);
        Task<int> Modifier(Fonction oFonction, int IdApplication);
        Task<bool> Suprimer(int Id ,int IdApplication);
    }
}
