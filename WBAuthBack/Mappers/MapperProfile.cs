using AutoMapper;
using WBAuth.BO;

namespace WBAuth.Back.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<WBAuth.DAL.Models.Application, WBAuth.BO.Application>(); 
            CreateMap<WBAuth.BO.Application,WBAuth.DAL.Models.Application>();
            CreateMap<WBAuth.DAO.Models.Application, WBAuth.BO.Application>();  
            CreateMap<WBAuth.BO.Application, WBAuth.DAO.Models.Application>();
            /*------------------------------------------------------------------------------------------------------------------------------*/
            CreateMap<WBAuth.DAL.Models.Action, WBAuth.BO.Action>();  
            CreateMap<WBAuth.BO.Action, WBAuth.DAL.Models.Action>();
            CreateMap<WBAuth.DAO.Models.Action, WBAuth.BO.Action>();  
            CreateMap<WBAuth.BO.Action, WBAuth.DAO.Models.Action>();
            /*------------------------------------------------------------------------------------------------------------------------------*/
            CreateMap<WBAuth.DAL.Models.Fonction, WBAuth.BO.Fonction>();  
            CreateMap<WBAuth.BO.Fonction, WBAuth.DAL.Models.Fonction>();
            CreateMap<WBAuth.DAO.Models.Fonction, WBAuth.BO.Fonction>();  
            CreateMap<WBAuth.BO.Fonction, WBAuth.DAO.Models.Fonction>();
            /*------------------------------------------------------------------------------------------------------------------------------*/
            CreateMap<WBAuth.DAL.Models.Journalisation, WBAuth.BO.Journalisation>(); 
            CreateMap<WBAuth.BO.Journalisation, WBAuth.DAL.Models.Journalisation>();
            CreateMap<WBAuth.DAO.Models.Journalisation, WBAuth.BO.Journalisation>();  
            CreateMap<WBAuth.BO.Journalisation, WBAuth.DAO.Models.Journalisation>();
            /*------------------------------------------------------------------------------------------------------------------------------*/
            CreateMap<WBAuth.DAL.Models.Permission, WBAuth.BO.Permission>();  
            CreateMap<WBAuth.BO.Permission, WBAuth.DAL.Models.Permission>();
            CreateMap<WBAuth.DAO.Models.Permission, WBAuth.BO.Permission>();  
            CreateMap<WBAuth.BO.Permission, WBAuth.DAO.Models.Permission>();
            /*------------------------------------------------------------------------------------------------------------------------------*/
            CreateMap<WBAuth.DAL.Models.Role, WBAuth.BO.Role>();  
            CreateMap<WBAuth.BO.Role, WBAuth.DAL.Models.Role>();
            CreateMap<WBAuth.DAO.Models.Role, WBAuth.BO.Role>();  
            CreateMap<WBAuth.BO.Role, WBAuth.DAO.Models.Role>();
            /*------------------------------------------------------------------------------------------------------------------------------*/
            CreateMap<WBAuth.DAL.Models.Utilisateur, WBAuth.BO.Utilisateur>();  
            CreateMap<WBAuth.BO.Utilisateur, WBAuth.DAL.Models.Utilisateur>();
            CreateMap<WBAuth.DAO.Models.Utilisateur, WBAuth.BO.Utilisateur>(); 
            CreateMap<WBAuth.BO.Utilisateur, WBAuth.DAO.Models.Utilisateur>();
            /*------------------------------------------------------------------------------------------------------------------------------*/
            CreateMap<WBAuth.DAL.Models.UtilisateurApplication, WBAuth.BO.UtilisateurApplication>();  
            CreateMap<WBAuth.BO.UtilisateurApplication, WBAuth.DAL.Models.UtilisateurApplication>();
            CreateMap<WBAuth.DAO.Models.UtilisateurApplication, WBAuth.BO.UtilisateurApplication>();  
            CreateMap<WBAuth.BO.UtilisateurApplication, WBAuth.DAO.Models.UtilisateurApplication>();

        }
    }
}


