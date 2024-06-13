using Microsoft.AspNetCore.Mvc;

namespace TravelTime.ViewComponents.MemberLayout
{
    public class _MemberLayoutHead : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
