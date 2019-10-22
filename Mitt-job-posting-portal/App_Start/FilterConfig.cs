using System.Web;
using System.Web.Mvc;

namespace Mitt_job_posting_portal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
