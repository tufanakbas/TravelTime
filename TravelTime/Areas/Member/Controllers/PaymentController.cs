using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelTime.Areas.Member.Models;

namespace TravelTime.Areas.Member.Controllers
{
    public class PaymentController : Controller
    {
        [Area("Member")]
        [Route("Member/[controller]/[action]/{id?}")]
        [Authorize(Roles = "Admin,Member, Manager, Editor , Visitor")]
        public IActionResult Index()
        {
            return View(new PaymentViewModel());
        }

        [HttpPost]
        public IActionResult ProcessPayment(PaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Ödeme işlemleri burada gerçekleştirilir
                // Örneğin, bir ödeme API'sine istek yapılabilir veya veritabanına kaydedilebilir

                TempData["SuccessMessage"] = "Ödeme işlemi başarıyla tamamlandı!";
                return RedirectToAction("Index");
            }
            else
            {
                // Geçersiz model durumunda hata mesajlarıyla birlikte ödeme sayfasına geri dön
                return View("Index", model);
            }
        }
    }
}
