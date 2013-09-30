using System.Collections.Generic;
using TextbookManage.Domain.IRepositories.Jw;
using TextbookManage.Domain.Models;
using TextbookManage.IServices.Jw;

namespace TextbookManage.Applications.Jw
{
    public class DataSignServiceImpl : IDataSignService
    {

        private readonly IDataSignRepository _repository;


        public DataSignServiceImpl(IDataSignRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<DataSign> GetAll()
        {
            return _repository.GetAll();
        }

        public DataSign GetById(string dataSignNum)
        {
            return _repository.First(t => t.Num == dataSignNum);
        }
    }
}
