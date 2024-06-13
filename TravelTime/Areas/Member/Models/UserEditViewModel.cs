using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TravelTime.Areas.Member.Models
{
	public class UserEditViewModel
	{
		public string name { get; set; }
		public string surname { get; set; }
        [Required(ErrorMessage = "Lütfen şifreyi giriniz")]
        public string password { get; set; }
        [Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz")]
        [Compare("password", ErrorMessage = "Şifreler uyumlu değil")]
        public string confirmpassword { get; set; }
		public string phonenumber { get; set; }
		public string mail { get; set; }
		public string imageurl { get; set; }
		public IFormFile Image { get; set; }
		
	}
}
