﻿using Microsoft.AspNetCore.Mvc;

namespace TravelTime.ViewComponents.MemberLayout
{
    public class _MemberLayoutFooter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
