using Apresentation.Mvc.Empty.Filters;
using Data.EF.Repositories;
using Domain.GerenciamentoCursosLGroup.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apresentation.Mvc.Empty.Controllers
{
    [CustomActionFilter]
    [Authorize]
    public class CategoriaController : Controller
    {
        
        private CategoriaRepository _categRepository;
        public CategoriaController()
        {
            //Estamos retornando um objecto (Repositorio) de categorias
            _categRepository = new CategoriaRepository();
        }

        // GET: Categoria

        //Selecionar as categorias
        public ActionResult Index()
        {
            //Listando as categorias no banco de dados
            var categorias = _categRepository.GetAll();

            //Enviar para a view
            return View(categorias);
        }
        
        //Cadastrar a categoria
        //Só mostra os campos html
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //Cadastrar de fato!!
        [HttpPost]
        public ActionResult Create(CategoriaEntity categoria)
        {
            if (ModelState.IsValid)
            {
                //Estamos adicionando uma categoria
                _categRepository.Add(categoria);

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}