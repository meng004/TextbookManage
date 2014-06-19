using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextbookManage.Infrastructure.ServiceLocators
{
public interface IUnityBootstraper
{
    void RegisterTypes(IUnityContainer container);
}
}
