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
            Mapper.CreateMap<UserEntity, User>();
            Mapper.CreateMap<User, UserEntity>();
            Mapper.CreateMap<BlogPostEntity, BlogPost>();
            Mapper.CreateMap<BlogPost, BlogPostEntity>();
        }
    }
}