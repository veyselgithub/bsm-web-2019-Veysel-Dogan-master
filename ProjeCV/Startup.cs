using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjeCV.Startup))]
namespace ProjeCV
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
