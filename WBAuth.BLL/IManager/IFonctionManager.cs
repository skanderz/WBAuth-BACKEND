using WBAuth.BO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WBAuth.BLL.IManager
{
    public interface IFonctionManager
    {
        Task<IEnumerable<Fonction>> ChargerAll();
        Task<Fonction> Recherche(int Id);
        Task<int> Ajouter(Fonction oFonction);
        Task<int> Modifier(Fonction oFonction);
        Task<bool> Suprimer(int Id);
    }



}


