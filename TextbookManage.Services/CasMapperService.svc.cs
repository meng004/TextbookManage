using System.Collections.Generic;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;

namespace TextbookManage.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“CasMapperService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 CasMapperService.svc 或 CasMapperService.svc.cs，然后开始调试。
    public class CasMapperService : ICasMapperAppl
    {
        private readonly ICasMapperAppl _impl = ServiceLocator.Current.GetInstance<ICasMapperAppl>();


        public ResponseView Import(IEnumerable<CasMapperView> casMappers)
        {
            return _impl.Import(casMappers);
        }

        public ResponseView Add(CasMapperView casMapper)
        {
            return _impl.Add(casMapper);
        }

        public ResponseView Modify(CasMapperView casMapper)
        {
            return _impl.Modify(casMapper);
        }

        public ResponseView Remove(CasMapperView casMapper)
        {
            return _impl.Remove(casMapper);
        }

        public string GetUsernameByCasNetId(string casNetId)
        {
            return _impl.GetUsernameByCasNetId(casNetId);
        }
    }
}
