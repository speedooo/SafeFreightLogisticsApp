using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SafeFreightLogisticsApp.Startup))]
namespace SafeFreightLogisticsApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
