using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrjClube.Startup))]
namespace PrjClube
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
