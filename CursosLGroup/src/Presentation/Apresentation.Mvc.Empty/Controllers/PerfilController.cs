using Acessos.Managers;
using Apresentation.Mvc.Empty.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Apresentation.Mvc.Empty.Controllers
{
    public class PerfilController : Controller
    {
        private RoleManager<IdentityRole, string> _appRoleManager;

        public PerfilController()
        {
            _appRoleManager = new AppRoleManager();
        }

        // GET: Perfil
        public ActionResult Index()
        {
            var perfil = _appRoleManager.Roles.Select(x => new PerfilViewModel()
            {
                Id = x.Id,
                Nome = x.Name
            });

            return View(perfil);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public async Task<ActionResult> Create(PerfilViewModel perfil)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole(perfil.Nome);
                var result = await _appRoleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //Retornar os erros para o usuário
                    //Podemos colocar no ModelState os erros gerados na criação da role
                    foreach(var erro in result.Errors){
                        ModelState.AddModelError("", erro);
                    }
                }
            }
            return View();
        }

    }
}