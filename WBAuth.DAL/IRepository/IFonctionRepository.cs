using WBAuth.DAL.Models;


namespace WBAuth.DAL.IRepository
{
    public interface IFonctionRepository
    {
        Task<IEnumerable<Fonction>> ChargerAll(int IdApplication);
        Task<Fonction> Recherche(int Id);
        Task<int> Ajouter(Fonction oFonction);
        Task<int> Modifier(Fonction oFonction);
        Task<bool> Suprimer(int Id);
       
    }
}
