using System.ComponentModel.DataAnnotations;

namespace TravelTime.Areas.Member.Models
{
    public class PaymentViewModel
    {
        [Required(ErrorMessage = "Kart sahibi adı zorunludur.")]
        [Display(Name = "Kart Sahibi Adı")]
        public string CardHolderName { get; set; }

        [Required(ErrorMessage = "Kart numarası zorunludur.")]
        [Display(Name = "Kart Numarası")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Son kullanma tarihi zorunludur.")]
        [Display(Name = "Son Kullanma Tarihi")]
        public string ExpirationDate { get; set; }

        [Required(ErrorMessage = "CVV zorunludur.")]
        [Display(Name = "CVV")]
        public string CVV { get; set; }

        [Required(ErrorMessage = "Ödeme miktarı zorunludur.")]
        [Display(Name = "Ödeme Miktarı")]
        public decimal Amount { get; set; }
    }
}
