using ReadPlayCode.Web.DI;
using StructureMap;
using System.Web.Mvc;
namespace ReadPlayCode.Web
{
    public static class BootStrap
    {
        public static void Init()
        {
            ObjectFactory.Initialize(x => x.AddRegistry(new DependencyRegistry()));
            DependencyResolver.SetResolver(new StructureMapDependencyResolver());
        }
    }
}