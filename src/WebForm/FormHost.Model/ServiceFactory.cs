using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormHost.Model.Interfaces;

namespace FormHost.Model
{
    public class ServiceFactory
    {
        public static Dictionary<Type, Type> _serviceLocator;
        public static IInfoProvider InfoProvider { get; set; }

        static ServiceFactory()
        {
            _serviceLocator = new Dictionary<Type, Type>();
        }

        public static void RegisterService(Type intf, Type cls)
        {
            _serviceLocator.Add(intf, cls);
        }

        public static ITemplateService GetTemplateService()
        {
            return (ITemplateService)GetService(typeof(ITemplateService));
        }

        public static IFillService GetFillService()
        {
            return (IFillService)GetService(typeof(IFillService));
        }

        private static IFormHostService GetService(Type intf)
        {
            var sType = _serviceLocator[intf];

            return (IFormHostService)Activator.CreateInstance(sType, InfoProvider);
        }
    }
}
