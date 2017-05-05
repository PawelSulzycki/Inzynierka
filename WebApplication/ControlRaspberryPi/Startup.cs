using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ControlRaspberryPi.Startup))]
namespace ControlRaspberryPi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
