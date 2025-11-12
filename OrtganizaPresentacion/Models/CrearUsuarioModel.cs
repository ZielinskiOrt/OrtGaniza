using System.ComponentModel.DataAnnotations;

namespace OrtganizaPresentacion.Models
{
    public class CrearUsuarioModel
    {
        [Required(ErrorMessage = "El correo es requerido.")]
        [EmailAddress(ErrorMessage = "No es un formato de correo válido.")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debes confirmar tu correo.")]
        [Compare("Email", ErrorMessage = "Los correos no coinciden.")]
        [Display(Name = "Repetir Correo Electrónico")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido.")]
        [MinLength(8, ErrorMessage = "Debe tener al menos 8 caracteres.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).*$",
            ErrorMessage = "Debe contener al menos una mayúscula, una minúscula y un carácter especial.")]
        [Display(Name = "Nombre de Usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).*$",
            ErrorMessage = "La contraseña debe contener al menos una mayúscula, una minúscula y un carácter especial.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debes confirmar tu contraseña.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        [Display(Name = "Repetir Contraseña")]
        public string ConfirmPassword { get; set; }
    }
}