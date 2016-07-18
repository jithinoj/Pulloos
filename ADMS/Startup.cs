using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADMS.Startup))]
namespace ADMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
