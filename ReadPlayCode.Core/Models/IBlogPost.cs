using System;
namespace ReadPlayCode.Models
{
    public interface IBlogPost : IIdentifiable
    {
        string Title { get; set; }
        string Text { get; set; }
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
        IUser Author { get; set; }
    }
}
