using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Example.Startup))]
namespace MVC_Example
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
