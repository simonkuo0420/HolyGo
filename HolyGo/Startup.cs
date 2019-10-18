using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HolyGo.Startup))]
namespace HolyGo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
