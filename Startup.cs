using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mercer_Craigslist.Startup))]
namespace Mercer_Craigslist
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
