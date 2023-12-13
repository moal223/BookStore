using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Emial Or Username")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name ="Rember me")]
        public bool RememberMe { get; set; }
    }
}
