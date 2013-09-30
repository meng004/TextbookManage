namespace TextbookManage.Infrastructure.ServiceLocators
{

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using System.Configuration;

    public static class ServiceLocator
    {
        public static IServiceLocator Current
        {
            get
            {
                //配置Unity
                UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                var container = new UnityContainer();
                section.Configure(container);
                //使用ServiceLocatorAdapter配置ServiceLocator                
                return new UnityServiceLocator(container);
            }
        }
    }
}
