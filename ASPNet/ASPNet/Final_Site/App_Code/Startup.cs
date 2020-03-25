using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Final_Site.Startup))]
namespace Final_Site
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
