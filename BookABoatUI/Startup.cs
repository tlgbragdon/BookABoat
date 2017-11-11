using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookABoatUI.Startup))]
namespace BookABoatUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
