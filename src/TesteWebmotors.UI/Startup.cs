using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TesteWebmotors.UI.Startup))]
namespace TesteWebmotors.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
