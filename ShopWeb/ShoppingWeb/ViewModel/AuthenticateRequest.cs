﻿using System.ComponentModel.DataAnnotations;

namespace ShoppingWeb.ViewModel
{
    public class AuthenticateRequest
    {

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
