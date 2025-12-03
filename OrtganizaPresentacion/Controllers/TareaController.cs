using AutoMapper;
using Business.CustomExceptions;
using Business.DTO;
using Business.Services;
using Business.Services.Interfaces;
using Entities.Entities;
using Entities.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrtganizaPresentacion.Models;

namespace OrtganizaPresentacion.Controllers
{
    public class TareaController : Controller, IViewDataRecargable
    {
        
        private readonly IMapper _mapper;
        private readonly IProyectoService _proyectoService;
        private readonly ITareaService _tareaService;
        private const string MSG_ERROR_GENERAL = "Hubo un Error inesperado";
        public TareaController(IMapper mapper, IProyectoService proyectoService,ITareaService tareaService) {

            _proyectoService = proyectoService;
            _tareaService = tareaService;
            _mapper = mapper;
        }
        
        // GET: TareaController
        public ActionResult CrearTarea(Guid proyectoId)
        {
            CrearTareaModel model = new CrearTareaModel();
            model.ProyectoId = proyectoId;
            model.FechaInicio = DateTime.Today;
            model.Usuarios = _mapper.Map<List<UsuarioModel>>(_proyectoService.GetMiembrosByProyectoId(proyectoId).Select(m => m.Usuario).ToList());
            return View(model);
        }

        [HttpPost]
        public ActionResult CrearTarea(CrearTareaModel model)
        {
            try
            {
                _tareaService.CargarTarea(_mapper.Map<TareaDTO>(model));
                return RedirectToAction("Index", new { ProyectoId = model.ProyectoId });
            }
            catch (TareaException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, MSG_ERROR_GENERAL);
            }
            model.Usuarios = _mapper.Map<List<UsuarioModel>>(_proyectoService.GetMiembrosByProyectoId(model.ProyectoId).Select(m => m.Usuario).ToList());
            return View(model);
        }
        public ActionResult Index(Guid proyectoId)
        {
            List<TareaModel> model = new List<TareaModel>();
            try
            {
                ViewBag.ProyectoId = proyectoId;
                model = _mapper.Map<List<TareaModel>>(_tareaService.GetTareasByProyectoId(proyectoId));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, MSG_ERROR_GENERAL);
            }
            return View(model);
        }


        [HttpPost]
        public IActionResult CambiarEstado(Guid tareaId, EstadoTarea nuevoEstado, Guid ProyectoId)
        {
            _tareaService.CambiarEstado(tareaId,nuevoEstado);
            return RedirectToAction("Index", new { ProyectoId = ProyectoId });
        }

        // GET: TareaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TareaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TareaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TareaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TareaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TareaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TareaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public void CargarViewData()
        {
        }
    }
}
