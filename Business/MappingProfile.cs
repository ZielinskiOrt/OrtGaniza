using AutoMapper;
using Business.DTO;
using Entities.Entities;

namespace Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Proyecto, ProyectoDTO>().ReverseMap();

        }
    }
}