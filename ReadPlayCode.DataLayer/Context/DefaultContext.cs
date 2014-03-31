using ReadPlayCode.DataLayer.Entities;
using ReadPlayCode.Models;
using System.Data.Entity;

namespace ReadPlayCode.DataLayer.Context
{
    public class DefaultContext : DbContext, IContext
    {
        public DefaultContext() : base("DefaultConnection") {}

        public IDbSet<UserEntity> Users { get; set; }
        public IDbSet<BlogPostEntity> BlogPosts { get; set; }

        public void SetModified(object entity)
        {
            var entry = Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
