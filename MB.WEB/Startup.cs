using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MB.WEB.Startup))]
namespace MB.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
