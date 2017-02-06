using Apresentation.Mvc.Empty.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;

namespace Apresentation.Mvc.Empty.Controllers
{
    [CustomActionFilter]
    //[Authorize] //Só permite que eu entre nesta controller se o usuário estiver autenticado
    public class HomeController : Controller
    {
               // GET: Home
        //Para criar uma view, basta colocar o cursor do mouse na do Titulo
        //da ActionResult e clicar em Add view

        //"{controller}/{action}/{id}"
        //http://localhost:1234/home/index
        //ou
        //http://localhost:1234/home
        //Quando não coloco o nome da action o MVC subentende que a action é index
        public ActionResult Index()
        {
            System.Web.Security.FormsAuthentication.SetAuthCookie("FAbio", true);

            var princiapl = HttpContext.User;

            return View();
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}