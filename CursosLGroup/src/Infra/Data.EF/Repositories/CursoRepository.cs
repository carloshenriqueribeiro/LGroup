using Data.EF.Context;
using Domain.GerenciamentoCursosLGroup.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    public class CursoRepository
    {
        private GerenciamentoCursoLGroupContext _context;
        //Ctor => Construtor
        public CursoRepository()
        {
            _context = new GerenciamentoCursoLGroupContext();
        }

        public void Add(CursoEntity curso)
        {
            try
            {
                _context.Curso.Add(curso); //Inseri em memória
                _context.SaveChanges(); //Dá um commit!!
            }
            catch (Exception ex)
            {  
                throw;
            }
        }

        //IEnumerable é um tipo de ILIst ou seja, uma coleção
        //IEnumerable é somente leitura
        //Não tem métodos como add, remove etc
        public IEnumerable<CursoEntity> GetAll()
        {
            return _context.Curso.ToList(); //Pra selecionar temos que dar o 
            //ToList, caso contrário não irá vir nada!!!
            //Não precisa dar saveChanges!!
        }
    }
}
