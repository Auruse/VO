using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TEF.Startup))]
namespace TEF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
