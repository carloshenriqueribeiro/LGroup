using Data.EF.Context;
using Domain.GerenciamentoCursosLGroup.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acessos.Managers
{
    //Esta classe é responsavel por Adicionar, deletar
    //Definir regras de login, etc
    public class AppUserManager
        : UserManager<UsuarioEntity>
    {
        //Assim como em uma arquitura 3 camadas
        //Precisa receber da camada de negocio a camanda de acesso a dados
        public AppUserManager()
            : base(new UserStore<UsuarioEntity>(new GerenciamentoCursoLGroupContext()))
        {

        }
    }
}


