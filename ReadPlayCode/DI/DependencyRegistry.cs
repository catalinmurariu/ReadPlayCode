using ReadPlayCode.DataLayer.Context;
using ReadPlayCode.DataLayer.Entities;
using ReadPlayCode.DataLayer.Repositories;
using ReadPlayCode.Mappers;
using ReadPlayCode.Models;
using ReadPlayCode.Repositories;
using ReadPlayCode.Web.Mappers;
using StructureMap.Configuration.DSL;
using System.Web.Mvc;
namespace ReadPlayCode.Web.DI
{
    public class DependencyRegistry : Registry
    {
        public DependencyRegistry()
        {
            For<IControllerActivator>().Use<StructureMapControllerActivator>();
            For<IRepository<IBlogPost>>().Use<BlogPostRepository>();
            For<IContext>().Use<DefaultContext>();
            For<IMapper<BlogPostEntity, IBlogPost>>().Use<BlogPostMapper>();

            Scan(x => 
            { 
                x.WithDefaultConventions();
                x.IncludeNamespace("ReadPlayCode.DataLayer.Repositories");
                x.IncludeNamespace("ReadPlayCode.DataLayer.Context");
                x.IncludeNamespace("ReadPlayCode.Web.Mappers");
            });
        }
    }
}