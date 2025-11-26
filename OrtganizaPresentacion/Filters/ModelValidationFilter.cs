using AutoMapper;
using Business.Services;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OrtganizaPresentacion.Controllers;
using OrtganizaPresentacion.Models;

namespace OrtganizaPresentacion.Filters
{
    public class ModelValidationFilter : ActionFilterAttribute
    {
        private readonly IProyectoService _proyectoService;
        private readonly IMapper _mapper;
        public ModelValidationFilter(IProyectoService proyectoService, IMapper mapper)
        {
            _mapper = mapper;
            _proyectoService = proyectoService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                Controller controller = context.Controller as Controller;
                object model = context.ActionArguments.Values.FirstOrDefault();

                if (controller != null && model != null)
                {
                    if (controller is TareaController && model is CrearTareaModel crearTareaModel)
                    {
                        Guid proyectoId = crearTareaModel.ProyectoId;

                        crearTareaModel.Usuarios = _mapper.Map<List<UsuarioModel>>(
                            _proyectoService.GetMiembrosByProyectoId(proyectoId)
                            .Select(m => m.Usuario).ToList());
                    }

                    if (controller is IViewDataRecargable recargable)
                    {
                        recargable.CargarViewData();
                    }

                    context.Result = controller.View(model);
                }
                else
                {
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
