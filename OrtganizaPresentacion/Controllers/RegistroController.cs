using Business.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrtganizaPresentacion.Models;

namespace OrtganizaPresentacion.Controllers
{
    public class RegistroController : Controller
    {
        // GET: RegistroController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegistroController/Create
        public ActionResult Crear()
        {
            return View("Crear");
        }

        // GET: RegistroController/Create
        [HttpPost]
        public ActionResult Crear(CrearUsuarioModel crearRequestDTO)
        {
            return View();
        }

      
    }
}
