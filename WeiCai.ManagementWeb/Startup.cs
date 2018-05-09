using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeiCai.ManagementWeb.Startup))]
namespace WeiCai.ManagementWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
