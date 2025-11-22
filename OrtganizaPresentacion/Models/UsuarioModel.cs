using System.ComponentModel.DataAnnotations;

namespace OrtganizaPresentacion.Models
{
    public class UsuarioModel
    {
        public Guid UserId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid WebRoleId { get; set; }
    }
}
