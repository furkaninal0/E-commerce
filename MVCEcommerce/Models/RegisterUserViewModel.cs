using MVCECommerceData;
using System.ComponentModel.DataAnnotations;

namespace MVCEcommerce.Models;

public class RegisterUserViewModel
{
    [Display(Name = "E-Posta Adres")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz ")]
    [DataType(DataType.EmailAddress)]

    public string? UserName { get; set; }

    [Display(Name = "Ad Soyad")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz ")]
    public string? GivenName { get; set; }

    [Display(Name = "Cinsiyet")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz ")]
    public Genders Gender { get; set; }

    [Display(Name = "Parola")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz ")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Display(Name = "Parola Tekrarı")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz ")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "{0} ile {1} alanlarında girdiğiniz parolalar uyuşmamaktadır.")]
    public string? PasswordCheck { get; set; }


}
