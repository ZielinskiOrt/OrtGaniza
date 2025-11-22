using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class ProyectoDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Guid UserId { get; set; }
        public List<Guid> MiembrosIds { get; set; } = new List<Guid>();

    }
}
