using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Activation;
using Microsoft.Practices.Unity;
using System.ServiceModel;

namespace TextbookManage.Services.Unity
{
    public class UnityServiceHostFactory : ServiceHostFactory
    {
        private readonly IUnityContainer _container;

        public UnityServiceHostFactory()
        {
            _container = new UnityContainer();
            var bootstrapper = new UnityBootstrapper();
            bootstrapper.RegisterTypes(_container);            
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new UnityServiceHost(_container, serviceType, baseAddresses);
        }

    }
}