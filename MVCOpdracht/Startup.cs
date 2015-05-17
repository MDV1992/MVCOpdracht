using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCOpdracht.Startup))]
namespace MVCOpdracht
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
