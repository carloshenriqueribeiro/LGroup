using Data.EF.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acessos.Managers
{
    //Assim com o UserManager que cria usuarios
    //Precisamos do RoleManager para criar roles
    public class AppRoleManager 
        : RoleManager<IdentityRole, string>
    {
        public AppRoleManager() 
            : base(new RoleStore<IdentityRole>(new GerenciamentoCursoLGroupContext()))
        {

        }
    }
}
