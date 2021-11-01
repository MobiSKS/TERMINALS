using System.Web;
using System.Web.Mvc;

namespace HPCL_DP_Terminal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
