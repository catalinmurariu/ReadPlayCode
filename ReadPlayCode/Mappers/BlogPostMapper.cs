using AutoMapper;
using ReadPlayCode.DataLayer.Entities;
using ReadPlayCode.Mappers;
using ReadPlayCode.Models;
using ReadPlayCode.Web.Models;
namespace ReadPlayCode.Web.Mappers
{
    public class BlogPostMapper : IMapper<BlogPostEntity, IBlogPost>
    {
        public IBlogPost DataToModel(BlogPostEntity data)
        {
            return Mapper.Map<BlogPostEntity, BlogPost>(data);
        }

        public BlogPostEntity ModelToData(IBlogPost model)
        {
            return Mapper.Map<BlogPost, BlogPostEntity>(model as BlogPost);
        }
    }
}