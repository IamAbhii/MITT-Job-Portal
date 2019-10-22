using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mitt_job_posting_portal.Startup))]
namespace Mitt_job_posting_portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
