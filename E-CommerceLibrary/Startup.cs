using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_CommerceLibrary.Startup))]
namespace E_CommerceLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
