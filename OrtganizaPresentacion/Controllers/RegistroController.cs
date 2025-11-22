using Business.CustomExceptions;
using Business.DTO;
using Business.Services.Interfaces;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrtganizaPresentacion.Models;

namespace OrtganizaPresentacion.Controllers
{
    public class RegistroController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly string _keyErrorUsuario = "ERROR_USUARIO_BACK";
        private readonly string _error = "Error inesperado";
        private readonly ICookieService _cookieService;
        public RegistroController(IUsuarioService usuarioService, ICookieService cookieService) { 
            this._usuarioService = usuarioService;
            this._cookieService = cookieService;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegistroController/Create
        public ActionResult Crear()
        {
            return View();
        }

        // GET: RegistroController/Create
        [HttpPost]
        public ActionResult Crear(CrearUsuarioModel crearUsuarioModel)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO
            {
                Nombre = crearUsuarioModel.Nombre,
                Apellido = crearUsuarioModel.Apellido,
                UserName = crearUsuarioModel.Username,
                PassWord = crearUsuarioModel.Password,
                Email = crearUsuarioModel.Email,
            };
            try
            {
                Guid id = _usuarioService.CargarUsuario(usuarioDTO);
                _cookieService.GuardarUsuario(id);
                return RedirectToAction("index","Proyecto");
            }
            catch (UserException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError(string.Empty, _error);
            }
            return View(crearUsuarioModel);

        }

      
    }
}
