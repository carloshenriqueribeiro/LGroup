using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Namamespace dos dataAnnotations
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.GerenciamentoCursosLGroup.Entities
{
    [Table("Categoria")]
    public class CategoriaEntity
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Favor adicionar um nome")]
        public string Nome { get; set; }
    }
}
