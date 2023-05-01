using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class ResetPasswordViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Lürfen bir şifre belirleyin.")]
        [Display(Name = "Yeni Şifre: ")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Şifre aynı değil.")]
        [Required(ErrorMessage = "Lütfen belirlediğiniz şifreyi girin.")]
        [Display(Name = "Yeni Şifre Tekrar: ")]
        public string PasswordConfirm { get; set; }
    }
}
