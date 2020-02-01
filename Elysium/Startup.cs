using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Elysium.Startup))]
namespace Elysium
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
