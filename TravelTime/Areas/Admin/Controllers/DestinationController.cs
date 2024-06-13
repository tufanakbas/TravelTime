using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace TravelTime.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            _destinationService.TAdd(destination);
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
        }
        public IActionResult DeleteDestination(int id)
        {
            var destinationID= _destinationService.TGetByID(id);
            _destinationService.TDelete(destinationID);
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var destinationID = _destinationService.TGetByID(id);
            var model = new Destination()
            {
                DestinationID = destinationID.DestinationID,
                City = destinationID.City,
                DayNight = destinationID.DayNight,
                Price = destinationID.Price,
                Image = destinationID.Image,
                Description = destinationID.Description,
                Capacity = destinationID.Capacity,
                CoverImage = destinationID.CoverImage,
                Details1 = destinationID.Details1,
                Details2 = destinationID.Details2,
                Image2 = destinationID.Image2,
                Date = destinationID.Date,
                GuideID = destinationID.GuideID,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDestination(Destination destination, IFormFile file, IFormFile file2, IFormFile file3)
        {
            destination.Status = false;

            if (file != null)
            {
                destination.Image = await SaveFile(file);
            }
            if (file2 != null)
            {
                destination.CoverImage = await SaveFile(file2);
            }
            if (file3 != null)
            {
                destination.Image2 = await SaveFile(file3);
            }

            _destinationService.UpdateQ(destination);
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + Path.GetExtension(file.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UserImages", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public IActionResult PassiveDestination(int id)
        {
            var value= _destinationService.TGetByID(id);
            _destinationService.TDestinationIsPassive(value);
            return RedirectToAction("Index");
        }
        public IActionResult ActiveDestination(int id)
        {
            var value = _destinationService.TGetByID(id);
            _destinationService.TDestinationIsActive(value);
            return RedirectToAction("Index");
        }
    }
}
