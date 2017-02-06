using Data.EF.Context;
using Domain.GerenciamentoCursosLGroup.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    public class CategoriaRepository
    {
        private GerenciamentoCursoLGroupContext _context;
        //Ctor => Construtor
        public CategoriaRepository()
        {
            _context = new GerenciamentoCursoLGroupContext();
        }

        public void Add(CategoriaEntity categoria)
        {
            _context.Categoria.Add(categoria); //Inseri em memória
            _context.SaveChanges(); //Dá um commit!!
        }

        //IEnumerable é um tipo de ILIst ou seja, uma coleção
        //IEnumerable é somente leitura
        //Não tem métodos como add, remove etc
        public IEnumerable<CategoriaEntity> GetAll()
        {
            return _context.Categoria.ToList(); //Pra selecionar temos que dar o 
            //ToList, caso contrário não irá vir nada!!!
            //Não precisa dar saveChanges!!
        }
    }
}
