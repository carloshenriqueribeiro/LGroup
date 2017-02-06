using Apresentation.Mvc.Empty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Apresentation.Mvc.Empty.Controllers
{
    public class FormularioController : Controller
    {

        //Metodos
        //Get => Usado para selecionar
        //Post => Usado para criar
        //Put => usuado para modificar
        //Delete => usado para deletar

        // GET: Formulario
        [HttpGet]
        public ActionResult Index(FormCollection formulario)
        {
            //1 - Podemos pegar os valores no request
            //2 - Podemos pegar os valores no formCollection
            //3 - Podemos pegar os valores via parametro, ou seja, via QueryString (se for Get)

            var nome = Request["nome"]; //Podemos resgatar o valor da view pelo name do controle
            var email = Request["email"];

            var nomeF = formulario["nome"];
            var emailF = formulario["email"];

            return View();
        }
        //Quando tiver algo como isso: 
        //http://localhost:121/formulario/ViaQueryString?nome=ffonseca&&email=ff@ig.com
        //altomaticamente o name=ffonseca e email=ff@ig.com
        public ActionResult ViaQueryString(string nome, string email)
        {
            string nomeQ = nome;
            string emailQ = email;

            return new RedirectResult("index");
        }

        [HttpPost]
        public ActionResult Post(string nome, string email)
        {
            string nomeQ = nome;
            string emailQ = email;

            return new RedirectResult("index");
        }
        //No MVC existe um processo que se chama modelBind, o qual, serializa
        //Todo o request em uma classe do modelo
        //Logo se o valor do request tiver o mesmo nome, então o modelo
        //será prenchido com este valor
        [HttpPost]
        public ActionResult PostComModel(FormularioModel formulario)
        {
            string nomeQ = formulario.Nome;
            string emailQ = formulario.Email;

            return new RedirectResult("index");
        }

        public string String()
        {
            return "Retornando uma string";
        }

        public ActionResult Nada()
        {
            return new EmptyResult();
        }

        public JsonResult RetornaJson()
        {
            var json = new {nome="Fabio", email = "ffonseca"};

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        //Os dos serão enviados da view para a controller
        //Quando a controller recebe algo da View ele pode retornar alguns itens
        //ViewResult (View) => Representa um Html
        //EmptyResult => Representa nenhum resultado
        //RedirectResult => Respresenta um redirecionamento
        //ContentResult => Respresenta uma string
        //JsonResult => Representa um Json
        //FileResult => Download de um arquivo
    }
}