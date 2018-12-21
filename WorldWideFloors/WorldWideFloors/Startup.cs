using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorldWideFloors.Startup))]
namespace WorldWideFloors
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
