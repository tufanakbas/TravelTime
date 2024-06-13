using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TravelTime.ViewComponents.AdminDashboard
{
    public class _DashboardBanner:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using (var context = new Context())
            {
                ViewBag.totalSubscribe = context.Newsletters.Count();
                ViewBag.totalMembers = context.Users.Count();
            }
            return View();
        }
    }
}
