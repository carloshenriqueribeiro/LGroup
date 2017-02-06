using Apresentation.Mvc.Empty.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apresentation.Mvc.Empty.Controllers
{
    public class ErrosGerenciadosController : Controller
    {
        // GET: ErrosGerenciados
        [CustomExceptionFilter] //A maioria dos filter são no formato atribute
        public ActionResult Index()
        {
            //Para testar vamos gerar um erro
            throw new Exception();

            return View();
        }

        //Como não temos atributos
        //Ele seguirá o filtro de Exceção Global
        public ActionResult Global()
        {
            throw new Exception();

            return View();
        }

        //Aqui podemos determinar qual tipo do erro
        //A view e a master que será redirecionada
        [HandleError(ExceptionType = typeof(NullReferenceException), View = "ErrorNullReference", 
            Master = "_Layout")]
        public ActionResult ErroEspecifico()
        {
            //Para testar, vamos gerar um erro especifico
            throw new NullReferenceException();

            return View();
        }
    }
}