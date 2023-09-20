using AutoMapper;

namespace WBAuthBack.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<WBAuth.DAL.Models.Application, WBAuth.BO.Application>();  // DAL
            CreateMap<WBAuth.BO.Application,WBAuth.DAL.Models.Application>();
            CreateMap<WBAuth.DAO.Models.Application, WBAuth.BO.Application>();  // DAO
            CreateMap<WBAuth.BO.Application, WBAuth.DAO.Models.Application>();
            /*------------------------------------------------------------------------------------------------------------------------------*/
            CreateMap<WBAuth.DAL.Models.Action, WBAuth.BO.Action>();  // DAL
            CreateMap<WBAuth.BO.Action, WBAuth.DAL.Models.Action>();
            CreateMap<WBAuth.DAO.Models.Action, WBAuth.BO.Action>();  // DAO
            CreateMap<WBAuth.BO.Action, WBAuth.DAO.Models.Action>();
            /*------------------------------------------------------------------------------------------------------------------------------*/
            CreateMap<WBAuth.DAL.Models.Fonction, WBAuth.BO.Fonction>();  // DAL
            CreateMap<WBAuth.BO.Fonction, WBAuth.DAL.Models.Fonction>();
            CreateMap<WBAuth.DAO.Models.Fonction, WBAuth.BO.Fonction>();  // DAO
            CreateMap<WBAuth.BO.Fonction, WBAuth.DAO.Models.Fonction>();
            /*------------------------------------------------------------------------------------------------------------------------------*/
            CreateMap<WBAuth.DAL.Models.Journalisation, WBAuth.BO.Journalisation>();  // DAL
            CreateMap<WBAuth.BO.Journalisation, WBAuth.DAL.Models.Journalisation>();
            CreateMap<WBAuth.DAO.Models.Journalisation, WBAuth.BO.Journalisation>();  // DAO
            CreateMap<WBAuth.BO.Journalisation, WBAuth.DAO.Models.Journalisation>();
            /*------------------------------------------------------------------------------------------------------------------------------*/
            CreateMap<WBAuth.DAL.Models.Permission, WBAuth.BO.Permission>();  // DAL
            CreateMap<WBAuth.BO.Permission, WBAuth.DAL.Models.Permission>();
            CreateMap<WBAuth.DAO.Models.Permission, WBAuth.BO.Permission>();  // DAO
            CreateMap<WBAuth.BO.Permission, WBAuth.DAO.Models.Permission>();
            /*------------------------------------------------------------------------------------------------------------------------------*/
            CreateMap<WBAuth.DAL.Models.Role, WBAuth.BO.Role>();  // DAL
            CreateMap<WBAuth.BO.Role, WBAuth.DAL.Models.Role>();
            CreateMap<WBAuth.DAO.Models.Role, WBAuth.BO.Role>();  // DAO
            CreateMap<WBAuth.BO.Role, WBAuth.DAO.Models.Role>();
            /*------------------------------------------------------------------------------------------------------------------------------*/
            CreateMap<WBAuth.DAL.Models.Utilisateur, WBAuth.BO.Utilisateur>();  // DAL
            CreateMap<WBAuth.BO.Utilisateur, WBAuth.DAL.Models.Utilisateur>();
            CreateMap<WBAuth.DAO.Models.Utilisateur, WBAuth.BO.Utilisateur>();  // DAO
            CreateMap<WBAuth.BO.Utilisateur, WBAuth.DAO.Models.Utilisateur>();
            /*------------------------------------------------------------------------------------------------------------------------------*/
            CreateMap<WBAuth.DAL.Models.UtilisateurApplication, WBAuth.BO.UtilisateurApplication>();  // DAL
            CreateMap<WBAuth.BO.UtilisateurApplication, WBAuth.DAL.Models.UtilisateurApplication>();
            CreateMap<WBAuth.DAO.Models.UtilisateurApplication, WBAuth.BO.UtilisateurApplication>();  // DAO
            CreateMap<WBAuth.BO.UtilisateurApplication, WBAuth.DAO.Models.UtilisateurApplication>();

        }
    }
}


