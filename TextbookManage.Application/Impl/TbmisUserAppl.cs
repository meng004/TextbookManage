using System.Linq;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Domain.Models;


namespace TextbookManage.Applications.Impl
{
    public class TbmisUserAppl
    {

        #region 私有变量

        private readonly ITbmisUserRepository _repo = ServiceLocator.Current.GetInstance<ITbmisUserRepository>();
        private readonly string _loginName;

        #endregion

        #region 构造函数

        public TbmisUserAppl(string loginName)
        {
            _loginName = loginName;
        }
        #endregion

        #region 共有方法

        /// <summary>
        /// 由用户登录名，取系统用户
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public TbmisUser GetUser()
        {
            var user = _repo.First(t => t.UserName == _loginName);
            return user;
        }

        #endregion

    }
}
