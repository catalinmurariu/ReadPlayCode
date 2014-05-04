using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadPlayCode.DataLayer.Entities
{
    public class BlogPostEntity : Entity
    {
        public string Title { get; set; }
        public string Text { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime Updated { get; set; }

        public virtual UserEntity Author { get; set; }
    }
}
