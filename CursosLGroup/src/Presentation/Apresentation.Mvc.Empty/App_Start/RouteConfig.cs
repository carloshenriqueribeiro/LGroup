using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Apresentation.Mvc.Empty
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Criando mais rotas
            //Toda vez que alguém digitar:
            //http://localhost:1234/cursos => iremos para a controller cursos
            //E action: Index
            routes.MapRoute(
                "Cursos", //Nome da rota
                "cursos/", //padrão da rota
                new {controller="Cursos", action = "Index"}
            );

            //Toda vez que alguém digitar 
            //http://localhost:1234/cursos/editar/1
            //será redirecionado para a controller abaixo
            routes.MapRoute(
                "Editar",
                "cursos/editar/{id}",
                new { controller = "Cursos", action = "Edite" });

            //Estamos mapeando uma rota
            routes.MapRoute(
                name: "Default", //O nome da rota
                url: "{controller}/{action}/{id}", //Padrão da Rota
                defaults: new { controller = "Home", action = "Index", 
                    id = UrlParameter.Optional }, // Caso não achar nehuma rota vai para a este roteamento
                namespaces: new[] { "Apresentation.Mvc.Empty.Controllers" }    
            );
        }
    }
}
