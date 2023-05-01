using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class PasswordChangeViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Lürfen eski şifrenizi girin.")]
        [Display(Name = "Eski Şifre: ")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olmalıdır.")]
        public string PasswordOld { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Lürfen bir şifre belirleyin.")]
        [Display(Name = "Yeni Şifre: ")]
        [MinLength(6, ErrorMessage ="Şifreniz en az 6 karakter olmalıdır.")]
        public string PasswordNew { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(PasswordNew), ErrorMessage = "Şifre aynı değil.")]
        [Required(ErrorMessage = "Lütfen belirlediğiniz şifreyi girin.")]
        [Display(Name = "Yeni Şifre Tekrar: ")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olmalıdır.")]
        public string PasswordNewConfirm { get; set;}
    }
}
