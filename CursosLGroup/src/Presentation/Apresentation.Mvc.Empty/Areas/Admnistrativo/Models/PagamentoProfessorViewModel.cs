using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace Apresentation.Mvc.Empty.Areas.Admnistrativo.Models
{
    public class PagamentoProfessorViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int IdProfessor { get; set; }

        public IEnumerable<SelectListItem> Professores
        {
            get
            {
                //Simulando alguns valores fakes
                return new List<SelectListItem>(){
                    new SelectListItem() { Text = "Leonardo", Value = "1" },
                    new SelectListItem() { Text = "Fábio Fonseca", Value = "2", Selected = true },
                    new SelectListItem() { Text = "Jean", Value = "3"}
                };
            }
        }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode= true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Data { get; set; }
    }
}