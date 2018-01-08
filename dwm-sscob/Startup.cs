using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dwm_sscob.Startup))]
namespace dwm_sscob
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
