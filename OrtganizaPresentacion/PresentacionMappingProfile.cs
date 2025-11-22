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
            CreateMap<ProyectoModel, ProyectoDTO>().ReverseMap();
            CreateMap<ProyectoModel, ProyectoResponseDTO>().ReverseMap();
            CreateMap<ProyectoEditarModel, ProyectoDTO>().ReverseMap();
        }
    }
}
