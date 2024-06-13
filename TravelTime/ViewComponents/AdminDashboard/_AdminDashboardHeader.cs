using Microsoft.AspNetCore.Mvc;

namespace TravelTime.ViewComponents.AdminDashboard
{
    public class _AdminDashboardHeader:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
