using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;

namespace TextbookManage.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“TextbookService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 TextbookService.svc 或 TextbookService.svc.cs，然后开始调试。
    public class TextbookService : ITextbookAppl
    {
        private readonly ITextbookAppl _impl = ServiceLocator.Current.GetInstance<ITextbookAppl>();

        public IEnumerable<PressView> GetPresses()
        {
            return _impl.GetPresses();
        }

        public ResponseView Add(TextbookView textbook, string loginName)
        {
            return _impl.Add(textbook, loginName);
        }

        public ResponseView Modify(TextbookView textbook)
        {
            return _impl.Modify(textbook);
        }

        public ResponseView Remove(IEnumerable<TextbookForQueryView> textbooks)
        {
            return _impl.Remove(textbooks);
        }

        public TextbookView GetById(string textbookId)
        {
            return _impl.GetById(textbookId);
        }

        public IEnumerable<TextbookForQueryView> GetByName(string textbookName, string isbn)
        {
            return _impl.GetByName(textbookName, isbn);
        }


        public IEnumerable<TextbookForQueryView> GetByLoginName(string loginName)
        {
            return _impl.GetByLoginName(loginName);
        }


    }
}
