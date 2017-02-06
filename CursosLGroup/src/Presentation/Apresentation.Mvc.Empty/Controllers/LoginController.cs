using Acessos.Managers;
using Apresentation.Mvc.Empty.Models;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
//No modelo de autenticação do tipo Form, usamos o seguinte namespace
using System.Web.Security;

namespace Apresentation.Mvc.Empty.Controllers
{
    [AllowAnonymous] //Permite usuarios anomimos entrarem nesta controller
    public class LoginController : Controller
    {
        private IAuthenticationManager _autenticationManager;
        private AppSigninManager _appSigninManager;
        public LoginController()
        {
            //No pipeline do Owin, usamos o IAuthenticationManager para 
            //Fazer a autenticação do usuário
            //Este contém os métodos de signin e signout
            //Porém vamos usá-lo junto com o AspNet Identity
            _autenticationManager 
                = System.Web.HttpContext.Current.GetOwinContext().Authentication;

            _appSigninManager = new AppSigninManager(_autenticationManager);
        }
 
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(LoginViewModel loginVm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _appSigninManager
                    .UserManager
                    .FindAsync(loginVm.UserName, loginVm.Password);

                if (usuario != null)
                {   
                    //Logar, ou seja, preencher o objeto identity
                    //FormsAuthentication.SetAuthCookie(loginVm.UserName, loginVm.RemenberMe);
                    await _appSigninManager.SignInAsync(usuario, true, loginVm.RemenberMe);

                    if (string.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Home");
                    else
                    {
                        if (returnUrl == "/")
                            return RedirectToAction("Index", "Home");
                        else
                        {
                            return new RedirectResult(returnUrl);
                        }
                    }
                }
            }

            //Caso os dados forem invalidos
            //Terei que informar na tela o erro
            //Uma estrutura que permite este caso, é o viewBag
            ViewBag.erro = "Usuário inválido";
            
            return View();
        }

        //LogOff
        public ActionResult Logoff()
        {
            //FormsAuthentication.SignOut();
            _autenticationManager.SignOut();
            return RedirectToAction("Index");
        }
    }
}