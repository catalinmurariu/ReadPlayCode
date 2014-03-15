using System;

namespace ReadPlayCode.Models
{
    public class BlogPost : Entity
    {
        public string Title { get; set; }
        string Text { get; set; }
        public DateTime Updated { get; set; }

        public User Author { get; set; }
    }
}
