using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Cada classe possui um lugar(namespace), este lugar identifica
//O local onde esta a classe
namespace Apresentation.Mvc.Empty.Areas.Admnistrativo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admnistrativo/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}