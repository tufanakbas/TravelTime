using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TravelTime.Controllers
{
	[AllowAnonymous]
	public class DefaultController : Controller
	{
        private readonly IDestinationService _destinationService;

        public DefaultController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DestinationSearch(string city, DateTime date)
        {
            var valueID = _destinationService.TDestinationSearch(city, date);

            if (valueID == 0) // id 0 dönerse belirtilen kriterlere uygun rota yoktur.
            {
                return RedirectToAction("Index", "Destination");
            }

            return RedirectToAction("DestinationDetails", "Destination", new { id = valueID });
        }
    }
}
