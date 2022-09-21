namespace SEDC.Lamazon.Domain.Enitities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public Role Role { get; set; }
    }
}
