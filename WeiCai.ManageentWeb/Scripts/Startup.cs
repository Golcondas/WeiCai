using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeiCai.ManageentWeb.Startup))]
namespace WeiCai.ManageentWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
