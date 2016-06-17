using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DIValidationExample.Startup))]
namespace DIValidationExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
