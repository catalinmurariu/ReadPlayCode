using ReadPlayCode.Models;

namespace ReadPlayCode.Web.Models
{
    public class User : IUser
    {
        public string UserName { get; set; }

        public string DisplayName { get; set; }
        
        public string Email { get; set; }
        
        IRole IUser.Role 
        {
            get { return Role; }
        }

        public Role Role { get; set; }

        public int Id { get; set; }
    }
}