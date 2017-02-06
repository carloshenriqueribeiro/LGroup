using Apresentation.Mvc.Empty.Areas.Admnistrativo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apresentation.Mvc.Empty.Areas.Admnistrativo.Controllers
{
    public class FinanceiroController : Controller
    {
        // GET: Admnistrativo/Financeiro
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PagarProfessor()
        {
            var pagamento = new PagamentoProfessorViewModel();

            return View(pagamento);
        }

        [HttpPost]
        //Iremos retornar um json porque não precisamos
        //Retornar a tela inteira
        //O processo será assincrono
        public JsonResult PagarProfessor(PagamentoProfessorViewModel pagamento)
        {
            if (ModelState.IsValid)
            {
                var result = new { mensagem = "Pagamento feito com sucesso", status = "OK" };
                //lá no javascript o objeto será transformado na seguinte forma    
                //result = {
                //      mensagem: 'Pagamento feito com sucesso',
                //      status: "OK"
                //}

                return Json(result);
            }
            else
            {
                var result = new { mensagem = "Erro ao efetuar o pagamento" };
                return Json(result);
            }
        }
    }
}