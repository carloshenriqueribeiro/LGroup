using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Reflection;
//coloquem sempre o seguinte namespace
using System.Web.Mvc;

namespace Apresentation.Mvc.Empty.Filters
{
    public class CustomExceptionFilter :
        FilterAttribute, //Permite ser implentado como um atributo
        IExceptionFilter //É uma interface que permite gerenciar os erros do usuario
    {
        public void OnException(ExceptionContext filterContext)
        {
            //Vamos pergar todos os itens de uma exception, tratar e redirecionar 
            //para algum view
            //No ciclo de vida do MVC existe um objecto que se chama context
            //Nele há informação sobre o status da aplicação
            //Exemplo: controller atual, usuario atual, etc.


            filterContext.ExceptionHandled = true; //tem que estar como True para customizar a exception
            //vamos pegar no roteamento a controller atual
            //temos que converter para string, pois, os values, estão como object
            var controllerName = (string)filterContext.RouteData.Values["controller"];

            var actionName = (string)filterContext.RouteData.Values["action"];

            //Criando um modelo, de acordo, com a página
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

            //Vamos redirecionar o usuário para uma view
            filterContext.Result = new ViewResult()
            {
                ViewName = "~/Views/Shared/ErroGerenciado.cshtml",//Nome da view
                MasterName = "~/Views/Shared/_Layout.cshtml",//A master
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model) //Modelo
            };

            

            if (filterContext.Exception is TimeoutException)
            {
                //Faço um log
            }

            if (filterContext.Exception.GetType() == typeof(TimeoutException))
            {
                //Faço um log
            }
        }
    }
}