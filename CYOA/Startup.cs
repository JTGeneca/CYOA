using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CYOA.Startup))]
namespace CYOA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
