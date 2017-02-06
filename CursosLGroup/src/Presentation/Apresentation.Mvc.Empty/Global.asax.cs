using Apresentation.Mvc.Empty.App_Start;
using Apresentation.Mvc.Empty.Filters;
using Apresentation.Mvc.Empty.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

//Todos os template T4 estão em:
//C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\Extensions\Microsoft\Web\Mvc\Scaffolding\Templates

namespace Apresentation.Mvc.Empty
{
    //O arquivo global.asax contém inúmeros eventos
    //Exemplo1: evento de Erro
    //Exemplo2: evento de inicialização da aplicação, ou seja, quando
    //a aplicação for executada um evento de inicialização será disparado
    public class MvcApplication : System.Web.HttpApplication
    {
        //A principio teremos o evento start
        //será executado quando iniciar a aplicação
        protected void Application_Start()
        {
            //Registrar as areas
            AreaRegistration.RegisterAllAreas();

            //RouteConfig é um elemento Global do projeto
            //A partir dele iremos configurar as nossas rotas

            //RouteTable ou tabela de roteamente vem vazia inicialmente
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Configurando o Mapeamento
            MapConfig.Inicialize();

            //Configurar Filtros
            //Estou dizendo que todos os controller serão gerenciados
            //Globalmente
            //E mais, todos os erros serão redirecionado para a view Error.cshtml
            GlobalFilters.Filters.Add(new HandleErrorAttribute());
            GlobalFilters.Filters.Add(new CustomResultFilter());

            //Filtro de Autenticação
            //Este filtro obriga que todas as controllers sejam atenticadas
            //GlobalFilters.Filters.Add(new AuthorizeAttribute());

            //Precisamos configura o Bundle
            //Para isto, precisamos assim como nas rotas
            //Adicionar em uma tabela global de bundles os 
            //novos bundles
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinderProviders.BinderProviders.Insert(0, 
                new XmlToObjectModelBinderProvider());
        }

        //A classe MvcApplication herda de HttpApplication que contém inumeros
        //eventos, um dele é o PostAuthorizeRequest
        //Ou seja, no ciclo de vida da aplicação este evento será chamado.
        //No Forms authentication, devemos colocar a role no evento abaixo,
        //Caso contrario não funcionará
        //public void Application_PostAuthorizeRequest()
        //{
        //    ///var role = "Administrador";
        //    var role = "";

        //    //Para não ficar buscando toda hora a role do usuario, vamos colocar
        //    //no cache por um periodo de tempo
        //    if (HttpContext.Current.Cache["role"] == null)
        //    {
        //        //Busca no banco e preenche
        //        HttpContext.Current.Cache.Add("role", "Administrador",
        //            null,
        //            DateTime.Now.AddMinutes(1),
        //            TimeSpan.Zero,
        //            CacheItemPriority.NotRemovable,
        //            null);
        //    }

        //    role = HttpContext.Current.Cache["role"].ToString();

        //    //pegar o cookie do usuario
        //    var cookieName = FormsAuthentication.FormsCookieName;
        //    var cookie = Context.Request.Cookies[cookieName];

        //    if (cookie == null)
        //        return;

        //    //Como sabemos o Cookie vem criptografado
        //    //Logo temos que decriptografá-lo
        //    //O Cookie decriptgrafado iremos chamar de ticket
        //    var ticket = FormsAuthentication.Decrypt(cookie.Value);

        //    if (ticket == null)
        //        return;

        //    //Criei uma identidade, apartir do ticket
        //    var identity = new FormsIdentity(ticket);

        //    //gerar uma role a partir da minha identidade
        //    //Mas primeiro tenho que criar o meu principal
        //    //Foi escolhido o GenericPrincipal, pois, no Forms não aceita claimsPrincipal
        //    var principal= new GenericPrincipal(identity, new [] { role });
            
        //    //colocar no principal do context
        //    HttpContext.Current.User = principal;
        //}
    }
}
