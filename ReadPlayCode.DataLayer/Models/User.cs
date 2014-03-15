namespace ReadPlayCode.Models
{
    public class User : Entity
    {
        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public Role UserRole { get; set; }
    }
}
