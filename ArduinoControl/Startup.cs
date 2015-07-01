using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArduinoControl.Startup))]
namespace ArduinoControl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
