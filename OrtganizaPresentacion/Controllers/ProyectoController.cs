using AutoMapper;
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
        private readonly IMapper _mapper;
        public ProyectoController(ICookieService cookieService, IUsuarioService usuarioService, IMapper mapper) { 
            this._cookieService = cookieService;
            this._usuarioService = usuarioService;
            this._userId = _cookieService.ObtenerUsuario();
            this._mapper = mapper;
        }

        public ActionResult Index(Guid UserId)
        {
            return View();
        }

        [HttpGet]
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
                model.UsuariosDisponibles = _mapper.Map<List<UsuarioModel>>(_usuarioService.GetAll());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, MSG_ERROR_GENERAL);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CrearProyecto(ProyectoCrearModel proyectoCrearModel)
        {
            ProyectoCrearModel model = new ProyectoCrearModel
            {
                ProyectoModel = new ProyectoModel()
            };

            try
            {
                model.ProyectoModel.PropietarioUserId = this._userId.Value;
                model.ProyectoModel.PropietarioNombre = _usuarioService.Get(this._userId.Value).Nombre;
                model.UsuariosDisponibles = _mapper.Map<List<UsuarioModel>>(_usuarioService.GetAll());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, MSG_ERROR_GENERAL);
            }
            return View(model);
        }

    }
}
