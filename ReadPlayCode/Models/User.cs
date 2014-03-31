using ReadPlayCode.Models;

namespace ReadPlayCode.Web.Models
{
    public class User : IUser
    {
        public string UserName { get; set; }

        public string DisplayName { get; set; }
        
        public string Email { get; set; }
        
        public IRole Role 
        {
            get { return null; }
            set { /*do nothing*/ } 
        }

        public int Id { get; set; }
    }
}