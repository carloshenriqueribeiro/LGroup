using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Tudo gira em torno deste namespace
//Autenticação e Autorização
using System.Security;
using System.Security.Claims;
using System.Threading;

namespace Presentation.UIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 - Preciso dizer quem eu sou
            //Claim => Declarações
            Claim meuNome = new Claim(ClaimTypes.Name, "Fábio Fonseca");
            Claim idade = new Claim("idade", "30");

            //Declarando o meu papel no ambiente, minhas permissões
            Claim papel = new Claim(ClaimTypes.Role, "Administrador");

            //Monstando a minha identidade
            var declaracoes = new List<Claim>(){ meuNome, idade, papel };
            ClaimsIdentity identity = new ClaimsIdentity(declaracoes, "Minha Autenticação");

            //2 - Preciso definir o ambiante
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
 
            //3 - Dizer quem eu no ambiente
            //Crieu uma identidade, um local e adicionei no ambiente do console (context do console)
            Thread.CurrentPrincipal = principal;

            //Vou verificar se estou autenticado
            Console.WriteLine("Estou autenticado?" + Thread.CurrentPrincipal.Identity.IsAuthenticated);

            //Vou verificar meu tipo de autenticação
            Console.WriteLine("Meu tipo de Autenticação é: " + Thread.CurrentPrincipal.Identity.AuthenticationType);

            //Vou verificar se sou administrador
            Console.WriteLine("Sou Admin? " + Thread.CurrentPrincipal.IsInRole("Administrador"));

            Console.ReadKey();
        }
    }
}
