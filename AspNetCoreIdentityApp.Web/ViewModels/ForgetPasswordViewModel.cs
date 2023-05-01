using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [EmailAddress(ErrorMessage = "Yanlış Email formatı.")]
        [Required(ErrorMessage = "Lürfen bir eposta girin.")]
        [Display(Name = "Email: ")]
        public string Email { get; set; }
    }
}
