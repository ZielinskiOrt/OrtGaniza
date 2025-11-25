using AutoMapper;
using Business.DTO;
using Business.Validators;
using Entities.Entities;

namespace Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Proyecto, ProyectoDTO>().ReverseMap();
            CreateMap<Proyecto, ProyectoResponseDTO>().ReverseMap();
            CreateMap<MiembroProyecto, MiembroProyectoDTO>().ReverseMap();
        }
    }
}