using ReadPlayCode.Models;
using System.Data.Entity;

namespace ReadPlayCode.DataLayer.Context
{
    public interface IContext
    {
        IDbSet<User> Users { get; }
        IDbSet<BlogPost> BlogPosts { get; }
    }
}
