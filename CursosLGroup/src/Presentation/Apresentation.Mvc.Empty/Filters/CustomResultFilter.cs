using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Apresentation.Mvc.Empty.Filters
{
    public class CustomResultFilter 
        : ActionFilterAttribute
    {
        //Durante a renderização do HTML
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            GerarLog("OnResultExecuting", filterContext.RouteData);
        }
        //Depois da Renderização do HTML
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            GerarLog("OnResultExecuted", filterContext.RouteData);
        }

        private void GerarLog(string metodo, RouteData route)
        {
            var controllerName = route.Values["controller"];
            var actionName = route.Values["action"];
            var mensagem = string.Format("Controller: {0}, Action {1}, Método {2}", controllerName, actionName
                ,metodo);

            Debug.WriteLine(mensagem);
        }
    }
}