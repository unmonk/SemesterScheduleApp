using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cheetah2.Startup))]
namespace Cheetah2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
