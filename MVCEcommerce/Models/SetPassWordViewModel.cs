using System.ComponentModel.DataAnnotations;

namespace MVCEcommerce.Models;

public class SetPassWordViewModel
{
    public Guid Id { get; set; }
    public string? Token {get; set; }
    [Display(Name = "Yeni parola")]
    [Required(ErrorMessage ="{0} boş bırakılamaz.")]
    [DataType(DataType.Password)]
    public string? Password  { get; set; }
    [Display(Name = "Yeni parola tekrarı")]
    [Required(ErrorMessage = "{0} boş bırakılamaz.")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "{0} ve {1} aynı olmalıdır.")]
    public string? PasswordCheck { get; set; }

}
