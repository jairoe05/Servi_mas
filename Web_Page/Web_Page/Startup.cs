using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_Page.Startup))]
namespace Web_Page
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
