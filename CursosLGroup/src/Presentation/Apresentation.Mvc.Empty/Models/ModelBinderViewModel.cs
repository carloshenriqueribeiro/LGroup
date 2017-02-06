using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apresentation.Mvc.Empty.Models
{
    public class ModelBinderViewModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }
    }
}