using StructureMap;
using System.Web.Mvc;
namespace ReadPlayCode.Web.DI
{
    public class StructureMapControllerActivator : IControllerActivator
    {
        public IController Create(System.Web.Routing.RequestContext requestContext, System.Type controllerType)
        {
            return ObjectFactory.GetInstance(controllerType) as IController;
        }
    }
}