using ReadPlayCode.Models;
using System;

namespace ReadPlayCode.Web.Models
{
    public class BlogPost : IBlogPost
    {
        public string Title { get; set; }
        
        public string Text { get;set; }
        
        public DateTime Created {get;set; }
        
        public DateTime Updated { get; set; }

        private User _author;

        IUser IBlogPost.Author 
        { 
            get { return Author; }
            set { Author = value as User; } 
        }

        public User Author { get; set; }
        
        public int Id { get; set; }
    }
}