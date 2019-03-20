using Commission.Server.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Commission.Server
{
    public class ParamValidAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var erro = context.ModelState.Values.SelectMany(v => v.Errors);
                var msg = erro.Select(i => string.IsNullOrEmpty(i.ErrorMessage) ? i.Exception.Message: i.ErrorMessage).Aggregate((i, next) => $"{i},{next}");
                throw new ParameterException(msg);
            }
        }
    }
}

