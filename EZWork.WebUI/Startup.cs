using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EZWork.WebUI.Startup))]
namespace EZWork.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
