using AutoMapper;
using ReadPlayCode.DataLayer.Entities;
using ReadPlayCode.Models;
using ReadPlayCode.Web.Models;

namespace ReadPlayCode.Web.Mappers.Profiles
{
    public class DefaultMappingProfile
    {
        public static void Init()
        {
            Mapper.CreateMap<RoleEntity, Role>();
            Mapper.CreateMap<Role, RoleEntity>();
            Mapper.CreateMap<UserEntity, ReadPlayCode.Web.Models.User>();
            Mapper.CreateMap<ReadPlayCode.Web.Models.User, UserEntity>();
            Mapper.CreateMap<BlogPostEntity, BlogPost>();
            Mapper.CreateMap<BlogPost, BlogPostEntity>();
        }
    }
}