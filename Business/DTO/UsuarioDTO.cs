using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class UsuarioDTO
    {
        public Guid UserId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public Guid WebRoleId { get; set; }
    }
}
