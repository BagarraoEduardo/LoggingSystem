using AutoMapper;
using LoggingSystem.DTO;
using LoggingSystem.Models;

namespace LoggingSystem.Mapper
{
    public class PresentationMapper : Profile
    {
        public PresentationMapper()
        {
            CreateMap<BaseDTO, BaseResponse>().ReverseMap();
            CreateMap<LogMessageResponseDTO, LogMessageResponse>().ReverseMap();
        }

    }
}
