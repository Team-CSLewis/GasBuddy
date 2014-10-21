using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GassBuddy.Web.Startup))]
namespace GassBuddy.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
