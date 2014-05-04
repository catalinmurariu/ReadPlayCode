namespace ReadPlayCode.Migrations
{
    using ReadPlayCode.DataLayer.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ReadPlayCode.DataLayer.Context.DefaultContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ReadPlayCode.DataLayer.Context.DefaultContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var defaultUser = new UserEntity{ Created = DateTime.Now, DisplayName = "Catalin", Email = "x@x.x", UserName="catalin", UserRole= new RoleEntity{ Created = DateTime.Now, Name="Writer"}};

            context.Users.AddOrUpdate(defaultUser);

            context.BlogPosts.AddOrUpdate(
                new BlogPostEntity { Title = "Test 1", Created = DateTime.Now, Text = "This is a blog entry test. Bla bla... <p>New paragraph...</p>", Author = defaultUser },
                new BlogPostEntity { Title = "Test 2", Created = DateTime.Now, Text = "This is a second blog entry test. Bla bla... second time <p>New paragraph...</p>", Author = defaultUser }
                );
        }
    }
}
