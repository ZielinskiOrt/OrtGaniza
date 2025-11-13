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

        public RegistroController(IUsuarioService usuarioService) { 
            this._usuarioService = usuarioService;
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

            _usuarioService.CargarUsuario(usuarioDTO);

            return RedirectToAction("Index");

        }

      
    }
}
