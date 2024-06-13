using Microsoft.AspNetCore.Mvc;

namespace TravelTime.ViewComponents.MemberLayout
{
    public class _MemberLayoutSearch : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
