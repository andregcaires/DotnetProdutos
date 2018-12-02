using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Swfast.TEMP3.Startup))]
namespace Swfast.TEMP3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
