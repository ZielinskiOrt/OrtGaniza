using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OrtganizaPresentacion.Filters
{
    public class ModelValidationFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {

                Controller controller = context.Controller as Controller;

                object model = context.ActionArguments.Values.FirstOrDefault();

                if (controller != null && model != null)
                {
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
