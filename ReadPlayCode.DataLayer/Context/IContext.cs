using ReadPlayCode.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ReadPlayCode.DataLayer.Context
{
    public interface IContext
    {
        IDbSet<User> Users { get; }
        IDbSet<BlogPost> BlogPosts { get; }
        int SaveChanges();
        void SetModified(object entity);
    }
}
