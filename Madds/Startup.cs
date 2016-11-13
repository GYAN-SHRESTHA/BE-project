using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Madds.Startup))]
namespace Madds
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
