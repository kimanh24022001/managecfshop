using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(managecfshop.Startup))]
namespace managecfshop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
