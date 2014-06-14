using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Infrastructure.TypeAdapter;
using TextbookManage.ViewModels;

namespace TextbookManage.Applications.Impl
{
    public class StorageAppl : IStorageAppl
    {

        #region 私有变量

        private readonly ITypeAdapter _adapter;
        private readonly IStorageRepository _repo;
        #endregion

        #region 构造函数

        public StorageAppl(ITypeAdapter adapter, IStorageRepository repo)
        {
            _adapter = adapter;
            _repo = repo;
        }
        #endregion

        #region 实现接口

        public IEnumerable<StorageView> GetByBookSellerId(string booksellerId)
        {
            var id = booksellerId.ConvertToGuid();

            var storages = _repo.Find(t =>
                t.Bookseller_Id == id
                );

            return _adapter.Adapt<StorageView>(storages);
        }

        public IEnumerable<StorageView> GetByLoginName(string loginName)
        {
            var booksellerId = new TbmisUserAppl(loginName).GetUser().SchoolId;
            var storages = _repo.Find(t => t.Bookseller_Id == booksellerId);
            return _adapter.Adapt<StorageView>(storages);
        }

        public StorageView GetById(string storageId)
        {
            var id = storageId.ConvertToGuid();

            var storage = _repo.First(t => t.ID == id);

            return _adapter.Adapt<StorageView>(storage);
        }

        public ResponseView Add(StorageView storage)
        {
            var model = _adapter.Adapt<Storage>(storage);

            var repo = ServiceLocator.Current.GetInstance<IStorageRepository>();

            var result = new ResponseView();

            try
            {
                repo.Add(model);
                repo.Context.Commit();
                return result;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = "添加仓库失败";
                return result;
            }
        }

        public ResponseView Modify(StorageView storage)
        {
            var model = _adapter.Adapt<Storage>(storage);

            var repo = ServiceLocator.Current.GetInstance<IStorageRepository>();

            var stor = repo.First(t => t.ID == model.ID);

            stor.Name = model.Name;
            stor.Address = model.Address;

            var result = new ResponseView();

            try
            {
                repo.Context.Commit();
                return result;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = "修改仓库失败";
                return result;
            }
        }

        public ResponseView Remove(IEnumerable<StorageView> storages)
        {
            var models = _adapter.Adapt<Storage>(storages);

            var repo = ServiceLocator.Current.GetInstance<IStorageRepository>();

            var result = new ResponseView();

            try
            {
                foreach (var item in models)
                {
                    repo.Remove(item);
                }
                repo.Context.Commit();
                return result;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = "删除仓库失败";
                return result;
            }
        }
        #endregion

    }
}
