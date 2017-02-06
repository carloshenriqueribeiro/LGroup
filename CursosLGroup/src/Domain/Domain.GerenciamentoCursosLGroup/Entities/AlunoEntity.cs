using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Os DataAnnotation são responsáveis por validar o nosso dominio no banco
//e é também responsável por validar a view (html, page..)
namespace Domain.GerenciamentoCursosLGroup.Entities
{
    [Table("Aluno")] //nome da tabela
    public class AlunoEntity
    {
        [Key] //chave primária
        [Column(Order = 0)] //Ordem da coluna na tabela
        public int Id { get; set; }

        [Required] //Defindo que é obrigatório
                   // Quando formos fazer o HTML iremos validar os inputs com dataannotation,
                   //Logo o usuario só será capaz de inserir um aluno se o nome estiver preenchido
        [Display(Name="Primeiro Nome")] //O item que será mostrado no HTML
        public string Nome { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

        //Estamos dizendo que um aluno tem uma coleção de cursos
        public virtual ICollection<CursoEntity> Cursos { get; set; }
    }
}
