using System.Collections.Generic;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;

namespace TextbookManage.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“BooksellerService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 BooksellerService.svc 或 BooksellerService.svc.cs，然后开始调试。
    public class BooksellerService : IBooksellerAppl
    {
        private readonly IBooksellerAppl _impl = ServiceLocator.Current.GetInstance<IBooksellerAppl>();
        public IEnumerable<BooksellerView> GetBooksellers()
        {
            return _impl.GetBooksellers();
        }

    }
}
