using System.ComponentModel.DataAnnotations;

namespace TechFixBackend.DTOs
{
    public class UserUpdateDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "Username can't be longer than 100 characters.")]
        public string? Username { get; set; }

        [Required]
        public string? Role { get; set; }

        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters.")]
        public string? NewPassword { get; set; } 
    }
}
