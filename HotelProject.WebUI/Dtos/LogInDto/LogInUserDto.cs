using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LogInDto
{
    public class LogInUserDto
    {

        [Required(ErrorMessage = "Kullanıcı Adını giriniz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifreyi giriniz.")]
        public string Password { get; set; }
    }
}
