namespace UserCompany.Model.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int RefreshTokenId { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
