using AspNetCoreIdentityApp.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Lürfen bir kullanıcı adı girin.")]
        [Display(Name = "Kullanıcı Adı: ")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Yanlış Email formatı.")]
        [Required(ErrorMessage = "Lürfen bir eposta girin.")]
        [Display(Name = "Email: ")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Lürfen bir telefon numarası girin.")]
        [Display(Name = "Telefon: ")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Doğum Tarihi: ")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Şehir: ")]
        public string? City { get; set; }

        [Display(Name = "Cinsiyet: ")]
        public Gender? Gender { get; set; }

        [Display(Name = "Profil Fotosu: ")]
        public IFormFile? Picture { get; set; }
    }
}
