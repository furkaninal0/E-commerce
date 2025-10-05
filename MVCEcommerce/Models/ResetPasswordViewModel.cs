using System.ComponentModel.DataAnnotations;

namespace MVCEcommerce.Models;

public class ResetPasswordViewModel
{
    [Display(Name = "E-Posta")]
    [Required(ErrorMessage = "{0} boş bırakılamaz")]
    public string? UserName { get; set; }
}
