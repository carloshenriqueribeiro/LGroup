using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity.Owin;
using Domain.GerenciamentoCursosLGroup.Entities;
using Microsoft.Owin.Security;

namespace Acessos.Managers
{
    //Classe responsavel por autenticar o usuario
    //Acoplando o framework aspnetIdentity
    public class AppSigninManager  
        : SignInManager<UsuarioEntity, string>
    {
        //Para integrar a autenticação owin com o aspnetIdentity
        //Precisamos passar o objeto de autenticação junto com o UserManager
        //(Objeto que gerencia o usuario no banco de dados)
        public AppSigninManager(IAuthenticationManager autenticationManager) 
            : base(new AppUserManager(), autenticationManager)
        {}
    }
}
