using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReadPlayCode.Web.Startup))]

namespace ReadPlayCode.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
