using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookShop.WebUI.Startup))]
namespace BookShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
