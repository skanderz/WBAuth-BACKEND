using AutoMapper;

namespace WBAuthBack.Mappers
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
        }
    }
}


