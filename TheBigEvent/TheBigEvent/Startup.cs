using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheBigEvent.Startup))]
namespace TheBigEvent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
