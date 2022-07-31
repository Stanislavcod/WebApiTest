
namespace UserCompany.Model.Models
{
    public class RefreshToken
    {
        public string Id { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
