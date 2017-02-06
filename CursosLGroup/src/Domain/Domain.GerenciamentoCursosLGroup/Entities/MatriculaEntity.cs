using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GerenciamentoCursosLGroup.Entities
{
    [Table("Matricula")]
    public class MatriculaEntity
    {
        [Key]
        [Column(Order=0)]
        public int Id { get; set; }

        //Vamos definir as composições
        public int IdCurso { get; set; }

        [ForeignKey("IdCurso")] //Que a propriedade IdCurso é a ForeignKey
        public virtual CursoEntity Curso { get; set; }

        public int IdAluno { get; set; }

        [ForeignKey("IdAluno")] // A propriedad IAluno é uma ForeignKey
        public virtual AlunoEntity Aluno { get; set; }

        [MaxLength(200)]
        public string Observacao { get; set; }
    }
}
