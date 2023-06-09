﻿using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Core.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]

        public string Username { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]

        public string Password { get; set; } = null!;
    }
}
