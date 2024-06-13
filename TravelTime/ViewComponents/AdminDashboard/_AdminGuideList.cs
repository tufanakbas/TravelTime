using Microsoft.AspNetCore.Mvc;

namespace TravelTime.ViewComponents.AdminDashboard
{
    public class _AdminGuideList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
