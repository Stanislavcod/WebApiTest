

namespace UserCompany.Model.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public Guid Token { get ; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
    }
}
