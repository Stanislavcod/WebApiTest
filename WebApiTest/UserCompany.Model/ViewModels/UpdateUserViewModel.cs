using System.ComponentModel.DataAnnotations;

namespace UserCompany.Model.ViewModels
{
    public class UpdateUserViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty
        public string Password { get; set; } = string.Empty;
    }
}
