using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? UserEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
    }
}
