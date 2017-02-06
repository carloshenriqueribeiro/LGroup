using System.Web;
using System.Web.Mvc;

namespace Apresentation.Mvc.ExemploTemplatePronto
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
