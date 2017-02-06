using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Apresentation.Mvc.Empty.Filters
{
    public class CustomActionFilter 
        : ActionFilterAttribute //é uma classe que implementa todos os filtros (Action e ResultFilters)
    {
        //Como estes métodos já implementados na classe ActionFilterAttribute
        //Para mudarmos o comportamento deles, basta sobreescreve-los (override)

        //Durante e antes a execução da Action (Mas esta na controller)
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext); //comportamento padrão
            GerarLog("OnActionExecuting", filterContext.RouteData); //Gerando um log
        }

        //Quando a Action For Executada
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext); //Comportamento Padrão
            GerarLog("OnActionExecuted", filterContext.RouteData);//Gerando um log
        }

        private void GerarLog(string metodo, RouteData route)
        {
            var controllerName = route.Values["controller"];
            var actionName = route.Values["action"];
            var mensagem = string.Format("Controller: {0}, Action {1}, Método {2}", controllerName, actionName
                , metodo);

            Debug.WriteLine(mensagem);
        }
    }
}