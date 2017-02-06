using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apresentation.Mvc.Empty.Models
{
    public class PerfilViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}