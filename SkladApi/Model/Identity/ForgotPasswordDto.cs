﻿using System.ComponentModel.DataAnnotations;
namespace ShopApi.Model.Identity
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }=String.Empty;

        [Required]
        public string? ClientURI { get; set; }
    }
}
