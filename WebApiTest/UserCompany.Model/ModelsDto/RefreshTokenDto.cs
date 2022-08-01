
using System.ComponentModel.DataAnnotations;

namespace UserCompany.Model.ModelsDto
{
    public class RefreshTokenDto
    {
        [Required]
        public string RefreshToken { get; set; }
        [Required]
        public string Login { get; set; }
    }
}
