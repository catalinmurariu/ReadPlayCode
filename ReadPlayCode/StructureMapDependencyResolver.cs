using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReadPlayCode.Web
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            try
            {
                return ObjectFactory.GetInstance(serviceType); 
            }
            catch (StructureMapConfigurationException e)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return ObjectFactory.GetAllInstances(serviceType).Cast<object>();
            }
            catch(StructureMapConfigurationException)
            {
                return null;
            }
        }
    }
}