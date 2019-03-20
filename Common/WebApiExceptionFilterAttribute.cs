using Commission.Server.Exceptions;
using Commission.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MySql.Data.MySqlClient;
using System.Linq;
using Utils;

namespace Commission.Server
{
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        //重写基类的异常处理方法
        public override void OnException(ExceptionContext context)
        {
            var e = context.Exception;
            ReturnModel ret = null;

            AgentPrincipal principal = null;
            AgentIdentity identity = null;
            long agentid = 0;
            //系统级错误
            if (e is NoLoginException)
                ret = new ReturnModel(ECode.TOKEN_ERROR, "TOKEN错误");
            else if (e is RedisConnectException)
                ret = new ReturnModel(ECode.SYSTEM_ERROR, "系统异常", e.Message);
            else if (e is ParameterException)
                ret = new ReturnModel(ECode.PARAMETER_ERROR, "参数错误", e.Message);
            else if (e is MySqlException)
                ret = new ReturnModel(ECode.SYSTEM_ERROR, "系统异常", e.Message);
            else
            {
                //用户级错误
                principal = context.HttpContext.User as AgentPrincipal;
                identity = principal.Identity as AgentIdentity;
                agentid = identity.AgentId;

                if (e is NoPermissionException)
                {
                    var ex = e as NoPermissionException;
                    var msg = ex.Permissions.Select(f => f.ToString()).Aggregate((r, i) => $"{r} {i}");

                    ret = new ReturnModel(ECode.UNAUTHORIZED, "没有权限", ex.Message + msg);
                }
                else
                {
                    ret = new ReturnModel(ECode.Exception, "系统异常", string.Format("{0},{1}", e.Message, e.StackTrace));
                }
            }

            Log.Logger("Exception").Error(string.Format("{0}:{1}", ret.Msg, ret.Data));
            context.Result = new JsonResult(ret);
            base.OnException(context);
        }
    }
}

