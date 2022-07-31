using System.ComponentModel.DataAnnotations;

namespace UserCompany.Model.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = String.Empty;
        [Required]
        public string Password { get; set; } = String.Empty;
        [Required]
        public string Name { get; set; } = String.Empty
    }
}
