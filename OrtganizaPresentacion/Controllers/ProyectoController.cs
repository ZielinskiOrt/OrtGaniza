using System.Runtime.Intrinsics.X86;
using AutoMapper;
using Business.CustomExceptions;
using Business.DTO;
using Business.Services;
using Business.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using OrtganizaPresentacion.Models;

namespace OrtganizaPresentacion.Controllers
{
    public class ProyectoController : Controller , IViewDataRecargable
    {
        private readonly Guid? _userId;
        private readonly ICookieService _cookieService;
        private readonly IUsuarioService _usuarioService;
        private readonly IProyectoService _proyectoService;
        private const string MSG_ERROR_GENERAL = "Hubo un Error inesperado";
        private const string MSG_ERROR_MIEMBROS = "No se cargaron miembros";
        private readonly IMapper _mapper;
        public ProyectoController(ICookieService cookieService, IUsuarioService usuarioService, IMapper mapper, IProyectoService proyectoService) { 
            this._cookieService = cookieService;
            this._usuarioService = usuarioService;
            this._userId = _cookieService.ObtenerUsuario();
            this._mapper = mapper;
            this._proyectoService = proyectoService;
        }

        public ActionResult Index(Guid UserId)
        {
            List<ProyectoModel> model = new List<ProyectoModel>();
            try
            {
                model = _mapper.Map<List<ProyectoModel>>(_proyectoService.GetByUserID(this._userId.Value));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, MSG_ERROR_GENERAL);
            }
            return View(model);

        }

        [HttpGet]
        public ActionResult CrearProyecto()
        {
            ProyectoModel model = new ProyectoModel();

            try
            {
                model.UserId = this._userId.Value;
                model.NombrePropietario = _usuarioService.Get(this._userId.Value).Nombre;
                ViewData["UsuariosDisponibles"] = _mapper.Map<List<UsuarioModel>>(_usuarioService.GetAll());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, MSG_ERROR_GENERAL);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult EditarProyecto(Guid proyectoId)
        {
            ProyectoEditarModel model = new ProyectoEditarModel();
            try
            {
                model = _mapper.Map<ProyectoEditarModel>(_proyectoService.Get(proyectoId));
                ViewData["UsuariosDisponibles"] = _mapper.Map<List<UsuarioModel>>(_usuarioService.GetAll());
                model.MiembrosIds = _proyectoService.GetMiembrosByProyectoId(proyectoId).Select(p => p.UserId).ToList();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, MSG_ERROR_GENERAL);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CrearProyecto(ProyectoModel proyectoModel)
        {
            try
            {
                if (proyectoModel.MiembrosIds.Count > 0)
                {
                    ProyectoDTO proyectoDTO = _mapper.Map<ProyectoDTO>(proyectoModel);
                    _proyectoService.CargarProyecto(proyectoDTO);
                }
                else 
                {
                    throw new ProyectoException(MSG_ERROR_MIEMBROS);
                }

            }
            catch (ProyectoException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, MSG_ERROR_GENERAL);
            }
            ViewData["UsuariosDisponibles"] = _mapper.Map<List<UsuarioModel>>(_usuarioService.GetAll());
            return View(proyectoModel);
        }
        public void CargarViewData()
        {
            ViewData["UsuariosDisponibles"] =
                _mapper.Map<List<UsuarioModel>>(_usuarioService.GetAll());
        }
    }
}
