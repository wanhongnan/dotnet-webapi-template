using Commission.Server.Models;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commission.Server
{
    public class JsonFormatAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var temp = context.Result as ObjectResult;
            var ret = new ReturnModel(ECode.SUCCESS, "ok", temp.Value);
            context.Result = new JsonResult(ret);
            base.OnResultExecuting(context);
        }
    }
}
