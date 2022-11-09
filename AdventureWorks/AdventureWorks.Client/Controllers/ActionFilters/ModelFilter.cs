using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdventureWorks.Client.Controllers.ActionFilters
{
    public class ModelFilter : IActionFilter where T : IEntityViewModel
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var model = context.RouteData.Values.Values.FirstOrDefault(v => v is T);

            if (model == null || !context.ModelState.IsValid)
                context.Result = new BadRequestResult();
        }
    }
}
