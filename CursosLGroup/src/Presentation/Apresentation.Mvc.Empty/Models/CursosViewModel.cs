using Data.EF.Repositories;
using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apresentation.Mvc.Empty.Models
{
    //90% de tudo que esta na Presentation esta em:
    //System.web.Mvc
    public class CursosViewModel
    {
        //Para não ficar repetindo as mensagens do DataAnnotation
        //Vamos criar um arquivo de Resource para padronizar as Mensagens
        private CategoriaRepository _categRepository;
        public CursosViewModel()
        {
            _categRepository = new CategoriaRepository();
        }

        [Required(ErrorMessageResourceType= typeof(MensagensLGroup), ErrorMessageResourceName = "CampoNaoInformado")]
        public string Descricao { get; set; }

        [Required(ErrorMessageResourceType = typeof(MensagensLGroup), ErrorMessageResourceName = "CampoNaoInformado")]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceType = typeof(MensagensLGroup), ErrorMessageResourceName = "CampoNaoInformado")]
        public string Autor { get; set; }

        [Required(ErrorMessageResourceType = typeof(MensagensLGroup), ErrorMessageResourceName = "CampoNaoInformado")]
        [ScaffoldColumn(false)] //Não irá aparecer no Scaffold do MVC
        public int IdCategoria { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(MensagensLGroup), ErrorMessageResourceName = "CampoNaoInformado")]
        [DataType(DataType.Date, ErrorMessage = "Formato invalido")]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0:dd-MM-yyyy}")]
        public DateTime DataCriacao { get; set; }
        
        //O DropDownList recebe um SelectListItem
        //O DropDownList é um helper do MVC => um select do html
        public IEnumerable<SelectListItem> Categorias { 
            
            get {
                return _categRepository.GetAll()
                            .Select(x => new SelectListItem()
                            {
                                Text = x.Nome,
                                Value = x.Id.ToString()
                            });
            } 
        }
    }
}