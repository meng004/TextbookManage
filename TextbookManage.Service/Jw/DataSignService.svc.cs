using System.Collections.Generic;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.IServices.Jw;

namespace TextbookManage.Services.Jw
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“DataSignService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 DataSignService.svc 或 DataSignService.svc.cs，然后开始调试。
    public class DataSignService : IDataSignService
    {
        private readonly IDataSignService _serviceImpl = ServiceLocator.Current.GetInstance<IDataSignService>();



        public IEnumerable<DataSign> GetAll()
        {
            return _serviceImpl.GetAll();
        }

        public DataSign GetById(string dataSignNum)
        {
            return _serviceImpl.GetById(dataSignNum);
        }
    }
}
