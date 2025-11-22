using Business.Services;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OrtganizaPresentacion.Models;

namespace OrtganizaPresentacion.Controllers
{
    public class ProyectoController : Controller
    {
        private readonly Guid? _userId;
        private readonly ICookieService _cookieService;
        private readonly IUsuarioService _usuarioService;
        private const string MSG_ERROR_GENERAL = "Hubo un Error inesperado";
        public ProyectoController(ICookieService cookieService, IUsuarioService usuarioService) { 
            this._cookieService = cookieService;
            this._usuarioService = usuarioService;
            this._userId = _cookieService.ObtenerUsuario();
        }

        public ActionResult Index(Guid UserId)
        {
            return View();
        }

        public ActionResult CrearProyecto()
        {
            ProyectoCrearModel model = new ProyectoCrearModel
            {
                ProyectoModel = new ProyectoModel()
            };

            try
            {
                model.ProyectoModel.PropietarioUserId = this._userId.Value;
                model.ProyectoModel.PropietarioNombre = _usuarioService.Get(this._userId.Value).Nombre;
                model.UsuariosDisponibles = _usuarioService.Get();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, MSG_ERROR_GENERAL);
            }
            return View(model);
        }
    }
}
