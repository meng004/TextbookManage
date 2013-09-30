using System.Linq;
using System.Collections.Generic;
using TextbookManage.Domain.IRepositories.Jw;
using TextbookManage.IServices.Jw;

namespace TextbookManage.Applications.Jw
{
    public class TermServiceImpl : ITermService
    {

        private readonly ITermRepository _repository;


        public TermServiceImpl(ITermRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<string> GetAll()
        {
            var term = _repository.GetAll();
            
            return term.Select(t => t.Name).OrderByDescending(t => t).ToList();
        }

        public string GetCurrent()
        {
            var term = _repository.First(t => t.IsValid == "1");
            return term.Name;
        }
    }
}
