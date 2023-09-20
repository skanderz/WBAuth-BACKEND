using WBAuth.BO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WBAuth.BLL.IManager
{
    public interface IFonctionManager
    {
        Task<IEnumerable<Fonction>> ChargerAll(int IdApplication);
        Task<Fonction> Recherche(int Id, int IdApplication);
        Task<int> Ajouter(Fonction oFonction, int IdApplication);
        Task<int> Modifier(Fonction oFonction, int IdApplication);
        Task<bool> Supprimer(int Id, int IdApplication);
    }



}


