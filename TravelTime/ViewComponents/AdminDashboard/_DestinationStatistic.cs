﻿using Microsoft.AspNetCore.Mvc;

namespace TravelTime.ViewComponents.AdminDashboard
{
    public class _DestinationStatistic:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
