using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(nine9.Startup))]
namespace nine9
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
