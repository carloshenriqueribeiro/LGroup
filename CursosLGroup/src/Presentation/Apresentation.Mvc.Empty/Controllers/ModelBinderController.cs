using Apresentation.Mvc.Empty.ModelBinders;
using Apresentation.Mvc.Empty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Apresentation.Mvc.Empty.Controllers
{
    public class ModelBinderController : Controller
    {
        // GET: ModelBinder
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ModelBinderViewModel modelBinder)
        {
            //No processo de modelBinder precisar saber o tipo
            //do conteúdo que esta vindo para serializar o objeto
            //O que é serializar??
            //Basicamente é transformar um tipo em outro
            //Exemplo: transformar um xml em um objeto
            //var contentType = HttpContext.Request.ContentType;

            //if (contentType.ToLower() == "text/xml")
            //{
            //    var vm = new XmlSerializer(typeof(ModelBinderViewModel));
            //    var obj = vm.Deserialize(HttpContext.Request.InputStream);
            //}


            return View();
        }

        [HttpGet]
        public ActionResult Index2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index2([ModelBinder(typeof(UpperCaseModelBinder))]
            ModelBinderViewModel modelBinder)
        {
            return View();
        }
    }
}