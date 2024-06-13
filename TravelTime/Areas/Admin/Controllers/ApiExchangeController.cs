using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using TravelTime.Areas.Admin.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TravelTime.Areas.Admin.Controllers
{
	public class ApiExchangeController : Controller
	{
		[Area("Admin")]
		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			List<BookingExchangeViewModel2> bookingExchangeViewModels = new List<BookingExchangeViewModel2>();
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?locale=en-gb&currency=TRY"),
				Headers =
	{
		{ "x-rapidapi-key", "02090e014fmsh221b660aee9eda3p1a51f0jsn2c61b8ac3c46" },
		{ "x-rapidapi-host", "booking-com.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<BookingExchangeViewModel2>(body);
				return View(values.exchange_rates);
			}
		}
	}
}
