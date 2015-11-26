using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MYOB.PayRoll.Startup))]
namespace MYOB.PayRoll
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
