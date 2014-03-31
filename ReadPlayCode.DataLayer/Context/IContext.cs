using ReadPlayCode.DataLayer.Entities;
using ReadPlayCode.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ReadPlayCode.DataLayer.Context
{
    public interface IContext
    {
        IDbSet<UserEntity> Users { get; }
        IDbSet<BlogPostEntity> BlogPosts { get; }
        int SaveChanges();
        void SetModified(object entity);
    }
}
