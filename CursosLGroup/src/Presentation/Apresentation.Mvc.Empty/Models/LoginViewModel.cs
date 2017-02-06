using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apresentation.Mvc.Empty.Models
{
    public class LoginViewModel
    {
        [Display(Name="Login")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Lembrar senha?")]
        public bool RemenberMe { get; set; }
    }
}