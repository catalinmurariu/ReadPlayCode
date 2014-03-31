using System;

namespace ReadPlayCode.DataLayer.Entities
{
    public class BlogPostEntity : Entity
    {
        public string Title { get; set; }
        string Text { get; set; }
        public DateTime Updated { get; set; }

        public UserEntity Author { get; set; }
    }
}
