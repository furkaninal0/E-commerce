﻿using System.ComponentModel.DataAnnotations;

namespace MVCEcommerce.Models;

public class LoginUserViewModel
{
    [Display(Name = "E-posta")]

    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
    public string? UserName { get; set; }

    [Display(Name = "Parola")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Bu alan boş bırakılamaz")] //runtime sırasında formda ilgili alanın boş gitmemesi için
    public string? Password { get; set; } //string? derleme sırasında hata almamak için

    public string? ReturnUrl { get; set; }
}
