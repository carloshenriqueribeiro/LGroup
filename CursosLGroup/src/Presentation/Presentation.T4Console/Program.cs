using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.T4Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var teste = new Test0();
            teste.Id = 1;
            teste.Nome = "Fábio";

            Console.WriteLine(teste.Nome + "  " + teste.Id);
            Console.ReadKey();

        }
    }
}
