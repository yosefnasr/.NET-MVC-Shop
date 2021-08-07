using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyShopUI.Startup))]
namespace MyShopUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
