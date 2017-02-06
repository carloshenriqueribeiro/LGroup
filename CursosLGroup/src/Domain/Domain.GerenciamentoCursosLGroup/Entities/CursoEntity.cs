using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GerenciamentoCursosLGroup.Entities
{
    //Entidade = negocio
    public class CursoEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public DateTime DataCriacao { get; set; }

        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        //Colocamos virtual a para facilitar o mapeamento e não vir null
        public virtual CategoriaEntity Categoria { get; set; }

        //Estamos dizendo que um curso tem uma coleção de alunos
        public virtual ICollection<AlunoEntity> Alunos { get; set; }
    }
}
