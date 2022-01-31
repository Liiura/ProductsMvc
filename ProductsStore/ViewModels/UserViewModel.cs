using System.ComponentModel.DataAnnotations;

namespace ProductsStore.ViewModels
{
    public class UserViewModel
    {
        [Display(Name = "User name")]
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 4, ErrorMessage = "The user name must be have a minimum length of 4")]
        public string UserName { get; set; }
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "The user name must be have a minimum length of 4")]
        public string Password { get; set; }
    }
}
