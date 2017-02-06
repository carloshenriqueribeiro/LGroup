using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

namespace Apresentation.Mvc.Empty
{
    //Quando instalamos o owin, automaticamente quando a aplicação é startada
    //é procurado uma classe Statup e executado o método Configuration

    //O Owin é um novo pipiline(ciclo de vida) do AspNet
    //Para trabalharmos com o Aspnet Identity precisamos instalar os seguintes pacotes:
    // 1 - Microsoft.Aspnet.Identity.EntityFramework => Possibilitar trabalhar com EF
    // 2 - Microsoft.AspNet.Identity.Owin => Classes bases do Owin
    // 3 - Microsoft.Owin.Security => Para trablhar com CookieAtentication
    // 4 - Microsoft.Owin.Host.SystemWeb => Para que o Owin trabalhe em conjunto com o IIS
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            //Agora criaremos o nosso proprio pipeline, e não dependeremos 
            //mais de eventos do httpApplication do Global.asax

            //como faremos isso?
            //Atravez do item app => é o que controle os middlewares
            //middlewares => são os caras que vão ser os novos "eventos"
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login"),
                ExpireTimeSpan = System.TimeSpan.FromHours(1)
            });
        }
    }
}
