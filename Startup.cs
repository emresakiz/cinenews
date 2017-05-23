using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SinemaBilgi.Startup))]
namespace SinemaBilgi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
