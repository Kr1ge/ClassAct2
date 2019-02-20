using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClassActivity2.Startup))]
namespace ClassActivity2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
