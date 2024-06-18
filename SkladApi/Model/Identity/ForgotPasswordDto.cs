using System.ComponentModel.DataAnnotations;
namespace X01.Model.Identity
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
