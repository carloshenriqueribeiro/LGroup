using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GerenciamentoCursosLGroup.Entities
{
    //O IdentityUser é o nosso usuario fornecido pelo AspNet Identity
    //Para customiza-lo, basta criar uma classe que herde dele
    public class UsuarioEntity : IdentityUser
    {
        public string Cpf { get; set; }
        public bool Ativo { get; set; }
    }
}
