using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.Areas.Admin.Models
{
    public class RoleUpdateViewModel
    {
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = "Lürfen bir Rol Adı girin.")]
        [Display(Name = "Rol Adı: ")] public string Name { get; set; } = null!;
    }
}
