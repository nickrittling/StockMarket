using Microsoft.Owin;
using Owin;
using Stock_Market.DB;

[assembly: OwinStartupAttribute(typeof(Stock_Market.Startup))]
namespace Stock_Market
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            SqlConnections sl = new SqlConnections();
            ConfigureAuth(app);
        }
    }
}
