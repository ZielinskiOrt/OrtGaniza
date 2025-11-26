namespace OrtganizaPresentacion.Models
{ 
    using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
        [Required(ErrorMessage = "El usuario/email es requerido.")]
        [Display(Name = "Usuario o Email")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }
    }
}
