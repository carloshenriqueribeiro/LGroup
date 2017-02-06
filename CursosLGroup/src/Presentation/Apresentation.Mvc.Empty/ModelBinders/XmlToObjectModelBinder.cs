using Apresentation.Mvc.Empty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Precisamos deste namespace
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Apresentation.Mvc.Empty.ModelBinders
{
    //Para que possamos sobrescrever um bind
    //Precisamos  herdar da interface IModelBinder
    public class XmlToObjectModelBinder
        : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            var modelo = bindingContext.ModelType;

            var vm = new XmlSerializer(modelo);
            var obj = vm.Deserialize(
                controllerContext.RequestContext.HttpContext.Request.InputStream);

            return obj;
        }
    }
    //Iremos colocar no Global.asax para que toda a aplicação possa enxergar
    public class XmlToObjectModelBinderProvider
        : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            var tipo = HttpContext.Current.Request.ContentType.ToLower();

            if (tipo == "text/xml")
            {
                return new XmlToObjectModelBinder();
            }

            return null;
        }
    }
}