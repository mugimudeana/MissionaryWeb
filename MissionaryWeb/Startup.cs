using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MissionaryWeb.Startup))]
namespace MissionaryWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
