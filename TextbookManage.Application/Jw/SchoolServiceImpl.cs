using System.Collections.Generic;
using TextbookManage.Domain.IRepositories.Jw;
using TextbookManage.Domain.Models;
using TextbookManage.Infrastructure;
using TextbookManage.IServices.Jw;

namespace TextbookManage.Applications.Jw
{
    public class SchoolServiceImpl : ISchoolService
    {
        private readonly ISchoolRepository _repository;

        public SchoolServiceImpl(ISchoolRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<School> GetAll()
        {
            var schools = _repository.GetAll();
            return schools;
        }

        public School GetById(string schoolId)
        {
            var id = schoolId.ConvertToGuid();
            //var repo = ServiceLocator.Current.GetInstance<IRepository<School>>("Jw");
            return _repository.First(t => t.SchoolID == id);
        }
    }
}
