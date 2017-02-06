using System.Web.Mvc;

namespace Apresentation.Mvc.Empty.Areas.Admnistrativo
{
    public class AdmnistrativoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admnistrativo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admnistrativo_default",
                "Admnistrativo/{controller}/{action}/{id}",
                new { controller="home", action = "Index", id = UrlParameter.Optional },
                new[] {"Apresentation.Mvc.Empty.Areas.Admnistrativo.Controllers" }
                //Precisamos colocar o namespace, para que o MVC não dispare
                //um erro de multiplicidade
            );
        }
    }
}