using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TravelTime.ViewComponents.Default
{
    public class _Statistics:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var count = new Context();
            ViewBag.rota = count.Destinations.Count();
            ViewBag.turRehber = count.Guides.Count();
            ViewBag.mutluMusteri = count.Users.Count();
            return View();
        }
    }
}
