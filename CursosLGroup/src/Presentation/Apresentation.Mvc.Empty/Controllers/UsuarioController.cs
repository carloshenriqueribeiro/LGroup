using System;
using System.Collections.Generic;
using System.Linq; //Precisamos deste namespace para usuario exp Lambdas e linq
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Domain.GerenciamentoCursosLGroup.Entities;
using Acessos.Managers;
using Apresentation.Mvc.Empty.Models;
using System.Threading.Tasks;

namespace Apresentation.Mvc.Empty.Controllers
{
    //Esta classe será responsavel por criar os usuarios
    //Selecionar, Deletar, etc..
    
    [Authorize(Roles = "Administrador")]//Estamos obrigando somente 
    //usuários administradores acessarem esta classe
    //[Authorize(Roles = "role1, role2, role3")] => caso tenhamos mais de um perfil
    //Podemos restringir a classe usando vírgula
    public class UsuarioController : Controller
    {
        private UserManager<UsuarioEntity> _gerenciadorUsuario;

        public UsuarioController()
        {
            _gerenciadorUsuario = new AppUserManager();
        }

        public ActionResult Index()
        {
            //Para selecionar o usuario basta fazer o seguinte
            //Aqui estamos selecionando um usuarioEntity
            //Porém queremos selecionar um usuarioViewModel
            //Para este fim usuaremos expressões Lambda
            var usuarios = _gerenciadorUsuario.Users.Select(x=>new UsuarioViewModel(){
            
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email,
                Cpf = x.Cpf
            });

            if (TempData["sucesso"] != null)
            {
                //Variavel de sessão utilizada entre controller e view
                ViewBag.sucesso = TempData["sucesso"];
            }
            return View(usuarios);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var usuarioVm = new UsuarioViewModel();
            return View(usuarioVm);
        }

        //O AspNet identity funciona de forma assincrona
        //Logo tudo o que vier antes dele deverá ter um task
        [HttpPost]
        public async Task<ActionResult> Create(UsuarioViewModel usuario)
        {
            //1 - Verificar  se o modelo é valido
            if (ModelState.IsValid)
            {
                //2 - Criar um usuário 
                var usuarioEntity = new UsuarioEntity()
                {
                    UserName = usuario.UserName,
                    Cpf = usuario.Cpf,
                    Ativo = true,
                    Email = usuario.Email
                };

                //3 - Adicionar o usuario
                //Toda vez que usuamos async podemos colocar um await
                var resutado = await _gerenciadorUsuario
                    .CreateAsync(usuarioEntity, "123Trocar@@");

                if (resutado.Succeeded)
                {
                    //Quando criamos um usuario estamos adicinando o seu perfil
                    _gerenciadorUsuario.AddToRole(usuarioEntity.Id, 
                        usuario.PerfilSelecionado);

                    //TempData é uma variavel de sessão
                    //Nela podemos enviar um dado de uma controller para a outra
                    TempData["sucesso"] = "Usuário criado com sucesso";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}