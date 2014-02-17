using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IT_Recrutement_Link.Web.Startup))]
namespace IT_Recrutement_Link.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
