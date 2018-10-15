using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GamesStore.Startup))]
namespace GamesStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
