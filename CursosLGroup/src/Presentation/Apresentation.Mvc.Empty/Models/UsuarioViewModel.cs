using Acessos.Managers;
using Apresentation.Mvc.Empty.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apresentation.Mvc.Empty.Models
{
    public class UsuarioViewModel
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        [Required]
        [CpfValidation]
        public string Cpf { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public string PerfilSelecionado { get; set; }

        public IEnumerable<SelectListItem> Perfis
        {
            get
            {
                return new AppRoleManager()
                    .Roles
                    .Select(x => new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Name
                    });
            }
        }

    }
}