using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace Apresentation.Mvc.Empty.ModelBinders
{
    public class UpperCaseModelBinder
        : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, 
            ModelBindingContext bindingContext)
        {
            //1 - tenho que pegar os dados que estão vindo
            var request = controllerContext.HttpContext.Request.Form;

            //2 - Montar o Objeto
            var tipo = bindingContext.ModelType;

            //Reflection - dei o new!!!!
            var objetoCriado = Activator.CreateInstance(tipo);

            //Vamos pegar os metadados do objeto (informações)
            var metadados = bindingContext.PropertyMetadata;

            foreach (var item in metadados)
            {
                object valor = request[item.Key];

                var property = objetoCriado.GetType().GetProperty(item.Key);

                if (valor == null)
                {
                    if (property.PropertyType == typeof(int))
                        valor = 0;
                    else
                        valor = "";
                }
                else
                {
                    valor = valor.ToString().ToUpper();
                }

                property.SetValue(objetoCriado, valor, null);
            }

            return objetoCriado;
        }
    }
}