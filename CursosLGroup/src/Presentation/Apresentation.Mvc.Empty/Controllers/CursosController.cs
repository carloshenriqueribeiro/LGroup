using Apresentation.Mvc.Empty.Models;
using Data.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

using FastMapper;
using Domain.GerenciamentoCursosLGroup.Entities;

namespace Apresentation.Mvc.Empty.Controllers
{
    public class CursosController : Controller
    {
        private CursoRepository _cursoRepository;

        public CursosController()
        {
            //Para setar a localização do usuario manualmente basta fazer o código abaixo:
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            _cursoRepository = new CursoRepository();
        }

        // GET: Cursos
        public ActionResult Index()
        {
            //Selecionando uma entidade (lá no Domain)
            var entity = _cursoRepository.GetAll();
            
            //Mas a minha view precisa de um viewModel, logo precisa converter entity em viewModal
            var viewModel = TypeAdapter.Adapt<IEnumerable<CursoEntity>, IEnumerable<CursosViewModel>>(entity);

            //Retornando a viewModel
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //Estamos criando uma variavel do tipo curso
            //e enviamos para a view com a intenção de que o dropdown
            //não venha null
            var cursoViewModel = new CursosViewModel(); 

            return View(cursoViewModel);
        }

        [HttpPost]
        public ActionResult Create(CursosViewModel cursoViewModel)
        {
            if (ModelState.IsValid)
            {
                //Inserir o curso
                //Precisamos de uma entidade, mas temos apenas uma viewModel
                //Logo temos que converter a viewModel em entidade
                var entity = TypeAdapter.Adapt<CursosViewModel, CursoEntity>(cursoViewModel);

                _cursoRepository.Add(entity);
                
                //e redirecionar
                return RedirectToAction("Index");
            }
            return View(cursoViewModel);
        }
        public ActionResult Edite(int id)
        {
            return View();
        }
    }
}