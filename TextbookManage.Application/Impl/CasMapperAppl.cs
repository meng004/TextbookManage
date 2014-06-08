using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.IApplications;
using TextbookManage.Domain.IRepositories;
using TextbookManage.ViewModels;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Infrastructure.TypeAdapter;

namespace TextbookManage.Applications.Impl
{
    public class CasMapperAppl : ICasMapperAppl
    {

        #region 属性

        readonly ITypeAdapter _adapter;
        readonly ICasMapperRepository _casRepo;
        readonly ITbmisUserRepository _userRepo;
        #endregion

        #region 构造函数

        public CasMapperAppl(ITypeAdapter adapter, ICasMapperRepository casRepo, ITbmisUserRepository userRepo)
        {
            _adapter = adapter;
            _casRepo = casRepo;
            _userRepo = userRepo;
        }
        #endregion

        #region 实现接口

        public ResponseView Import(IEnumerable<CasMapperView> casMappers)
        {
            var repo = ServiceLocator.Current.GetInstance<ICasMapperRepository>();
            var result = new ResponseView();

            try
            {
                var models = _adapter.Adapt<CasMapper>(casMappers);
                foreach (var item in models)
                {
                    repo.Add(item);
                }
                repo.Context.Commit();
                return result;
            }
            catch (Exception e)
            {
                result.Fault();
                return result;
            }
        }

        public ResponseView Add(CasMapperView casMapper)
        {
            var repo = ServiceLocator.Current.GetInstance<ICasMapperRepository>();
            var result = new ResponseView();

            try
            {
                var model = _adapter.Adapt<CasMapper>(casMapper);
                repo.Add(model);
                repo.Context.Commit();
                return result;
            }
            catch (Exception e)
            {
                result.Fault();
                return result;
            }
        }

        public ResponseView Modify(CasMapperView casMapper)
        {
            var repo = ServiceLocator.Current.GetInstance<ICasMapperRepository>();
            var result = new ResponseView();

            try
            {
                var model = _adapter.Adapt<CasMapper>(casMapper);

                repo.Modify(model);

                repo.Context.Commit();
                return result;
            }
            catch (Exception e)
            {
                result.Fault();
                return result;
            }
        }

        public ResponseView Remove(CasMapperView casMapper)
        {
            var repo = ServiceLocator.Current.GetInstance<ICasMapperRepository>();
            var result = new ResponseView();

            try
            {
                var model = _adapter.Adapt<CasMapper>(casMapper);

                repo.Remove(model);

                repo.Context.Commit();
                return result;
            }
            catch (Exception e)
            {
                result.Fault();
                return result;
            }
        }

        public string GetUsernameByCasNetId(string casNetId)
        {
            //输入是否为空
            if (string.IsNullOrWhiteSpace(casNetId))
            {
                return string.Empty;
            }
            var casMapper = _casRepo.First(t => t.CasNetId == casNetId);
            if (casMapper == null)
            {
                return string.Empty;
            }
            else if (casMapper.User == null)//用户是否为空
            {
                //用身份证号，取用户的userid
                var user = _userRepo.First(t => t.IdCard == casMapper.IdCard);
                //是否为空
                if (user == null)
                {
                    return string.Empty;
                }
                else  //更新casMapper中的userid
                {
                    var repo = ServiceLocator.Current.GetInstance<ICasMapperRepository>();
                    var model = repo.First(t => t.CasNetId == casNetId);
                    model.UserId = user.ID;
                    try
                    {
                        repo.Modify(model);
                        repo.Context.Commit();
                        return model.User.UserName;
                    }
                    catch (Exception e)
                    {
                        return user.UserName;
                    }
                }
            }
            else
            {
                return casMapper.User.UserName;
            }
        }

        
        #endregion

    }
}
