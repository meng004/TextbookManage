using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace TextbookManage.Services.Unity
{
    public class UnityServiceHost : ServiceHost
    {
        public UnityServiceHost(IUnityContainer container, Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            foreach (var item in this.ImplementedContracts.Values)
            {
                item.ContractBehaviors.Add(new UnityInstanceProvider(container));
            }
        }
    }
}