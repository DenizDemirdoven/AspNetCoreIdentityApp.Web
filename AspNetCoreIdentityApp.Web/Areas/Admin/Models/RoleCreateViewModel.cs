using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.Areas.Admin.Models
{
    public class RoleCreateViewModel
    {
        [Required(ErrorMessage = "Lürfen bir Rol Adı girin.")]
        [Display(Name = "Rol Adı: ")]
        public string Name { get; set; }
    }
}
