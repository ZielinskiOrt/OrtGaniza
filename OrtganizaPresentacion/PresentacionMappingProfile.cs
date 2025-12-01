using AutoMapper;
using Business.DTO;
using OrtganizaPresentacion.Models;

namespace OrtganizaPresentacion
{
    public class PresentacionMappingProfile : Profile
    {
        public PresentacionMappingProfile()
        {
            CreateMap<UsuarioDTO, UsuarioModel>().ReverseMap();
            CreateMap<ProyectoDTO, ProyectoModel>().ReverseMap();
            CreateMap<ProyectoDTO, ProyectoEditarModel>().ReverseMap();
            CreateMap<ProyectoResponseDTO, ProyectoModel>().ReverseMap();
            CreateMap<TareaResponseDTO, TareaModel>().ReverseMap();
            CreateMap<TareaDTO, CrearTareaModel>().ReverseMap();
            CreateMap<LoginDTO, LoginModel>().ReverseMap();
        }
    }
}
