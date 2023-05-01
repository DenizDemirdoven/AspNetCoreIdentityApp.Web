using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class SignUpViewModel
    {
        public SignUpViewModel()
        {
            
        }
        public SignUpViewModel(string userName, string email, string phone, string password)
        {
            UserName = userName;
            Email = email;
            Phone = phone;
            Password = password;
        }
        [Required(ErrorMessage ="Lürfen bir kullanıcı adı girin.")]
        [Display(Name = "Kullanıcı Adı: ")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage ="Yanlış Email formatı.")]
        [Required(ErrorMessage = "Lürfen bir eposta girin.")]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
        //          ErrorMessage = "Yanlış telefon numarası formatı.")]
        [Required(ErrorMessage = "Lürfen bir telefon numarası girin.")]
        [Display(Name = "Telefon: ")]
        public string Phone { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Lürfen bir şifre belirleyin.")]
        [Display(Name = "Şifre: ")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olmalıdır.")]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Şifre aynı değil.")]
        [Required(ErrorMessage = "Lütfen belirlediğiniz şifreyi girin.")]
        [Display(Name = "Şifre Tekrar: ")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olmalıdır.")]
        public string PasswordConfirm { get; set; }
    }
}
