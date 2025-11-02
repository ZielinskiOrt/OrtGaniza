using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTO;
using Entities.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // --- 1. Mapeo de Entidad a DTO (Lectura) ---
            // Cuando quieras mostrar datos a la vista/cliente
            CreateMap<Usuario, UsuarioDTO>()
                // Si los nombres de las propiedades son diferentes, usa .ForMember()
                // .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => $"{src.Nombre} {src.Apellido}"))
                .ReverseMap(); // Opcional: Define el mapeo inverso.

            // --- 2. Mapeo de DTO a Entidad (Escritura/Actualización) ---
            // Si no usas ReverseMap(), puedes definir el mapeo explícitamente:
            // CreateMap<UsuarioDTO, Usuario>(); 

            // Puedes añadir tantos mapeos como necesites aquí:
            // CreateMap<Producto, ProductoDTO>().ReverseMap();
            // CreateMap<Pedido, PedidoDTO>();
        }
    }
}
