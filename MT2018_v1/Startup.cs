using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MT2018_v1.Startup))]
namespace MT2018_v1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
