using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Apresentation.Mvc.ExemploTemplatePronto.Startup))]
namespace Apresentation.Mvc.ExemploTemplatePronto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
