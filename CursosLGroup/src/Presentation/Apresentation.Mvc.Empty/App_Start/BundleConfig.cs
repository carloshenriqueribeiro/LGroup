using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Precisa deste namespace
//Presente no pacote
//Microsoft.aspnet.web.optimization
using System.Web.Optimization;

namespace Apresentation.Mvc.Empty.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundle)
        {
            //1 - vamos colocar os scritps em um caminho virtual
            //vamos para os javascripts
            ScriptBundle scriptBase = new ScriptBundle("~/bundles/base");

            scriptBase.Include("~/Scripts/jquery-1.10.2.js", 
                               "~/Scripts/bootstrap.js");

            //Podemos definir uma ordem para a visualização do bundle
            scriptBase.Orderer = new CustomOrder();

            //Colocar na tabela de bundles
            bundle.Add(scriptBase);

            //Da mesma forma que fizemos para os scripts
            //Podemos fazer para o css
            StyleBundle styleBase = new StyleBundle("~/bundles/StyleBase");

            styleBase.Include("~/Content/Site.css", 
                "~/Content/bootstrap.css");

            bundle.Add(styleBase);

            //Pra funcionar precisamos habilitar
            BundleTable.EnableOptimizations = true;
        }
    }

    public class CustomOrder : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, 
            IEnumerable<BundleFile> files)
        {
            //Só por curiosidade podemos criar uma classe para order
            //A ordem do bundle
            //No caso vamos deixar o padrão
            return files;
        }
    }   
} 









