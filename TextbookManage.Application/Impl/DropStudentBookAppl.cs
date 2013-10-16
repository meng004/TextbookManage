using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure;
using TextbookManage.Infrastructure.TypeAdapter;
using TextbookManage.ViewModels;

namespace TextbookManage.Applications.Impl
{
    public class DropStudentBookAppl : IDropStudentBookAppl
    {
         private readonly IStudentReleaseRecordRepository  _studentReleaseRecordRepo;
       
       private readonly ITypeAdapter _typeAdapter;
       private readonly IInventoryRepository _inventoryRepo;
       private readonly IInStockRecordRepository _inStockRecordRepo;
        private readonly IBooksellerRepository _booksellerRepository;
        private readonly ITypeAdapter _adapter;
        private readonly IStudentRepository _stuRepo;
        private readonly IProfessionalClassRepository _classRepository;
       public DropStudentBookAppl(IInventoryRepository inventoryRepo, IStudentReleaseRecordRepository studentReleaseRecordRepo, ITypeAdapter typeAdapter, IInStockRecordRepository inStockRecordRepo, IBooksellerRepository booksellerRepository, ITypeAdapter adapter, IProfessionalClassRepository classRepository, IStudentRepository stuRepo)
       {
           _inventoryRepo = inventoryRepo;
           _studentReleaseRecordRepo = studentReleaseRecordRepo;
           _typeAdapter = typeAdapter;
           _inStockRecordRepo = inStockRecordRepo;
           _booksellerRepository = booksellerRepository;
           _adapter = adapter;
           _classRepository = classRepository;
           _stuRepo = stuRepo;
       }
       /// <summary>
       /// 根据登录名取学院
       /// </summary>
       /// <param name="loginName"></param>
       /// <returns></returns>
       public IEnumerable<SchoolView> GetSchoolByLoginName(string loginName)
       {
           //取学院
           var schools = new BooksellerAppl().GetSchoolByLoginName(loginName);

           return _adapter.Adapt<SchoolView>(schools);

       }
       /// <summary>
       /// 根据学院ID取年级
       /// </summary>
       /// <param name="schoolId"></param>
       /// <returns></returns>
       public IEnumerable<string> GetGradeBySchoolId(string schoolId)
       {
           var id = schoolId.ConvertToGuid();
           return _classRepository.Find(t => t.School_Id == id).Select(t => t.Grade).Distinct();
       }
       /// <summary>
       /// 根据学院，年级取专业班级
       /// </summary>
       /// <param name="schoolId"></param>
       /// <param name="grade"></param>
       /// <returns></returns>
       public IEnumerable<ProfessionalClassView> GetClassBySchoolId(string schoolId, string grade)
       {
           var classes = new ProfessionalClassAppl().GetBySchoolIdAndGrade(schoolId.ConvertToGuid(), grade);

           return _adapter.Adapt<ProfessionalClassView>(classes);
       }
        /// <summary>
        /// 根据班级ID，取学生
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IEnumerable<StudentView> GetStudentByClassId(string classId)
        {
            var id = classId.ConvertToGuid();
            var students = _stuRepo.Find(c => c.ProfessionalClass_Id == id);

            return _adapter.Adapt<StudentView>(students);
        }
        /// <summary>
        /// 根据学生ID，取学生可退还教材
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public IEnumerable<DropBookForStudentQueryView> GetStudentDropBookByStudentId(string studentId)
        {
            var sId = studentId.ConvertToGuid();
            var currentTerm = new TermAppl().GetCurrentTerm().ToString();
            var dropStudentBook = _studentReleaseRecordRepo.Find(s => s.Student_Id == sId && s.Term == currentTerm)
                                                           .Select(
                                                               s =>
                                                               new
                                                               {
                                                                   s.Term,
                                                                   s.Name,
                                                                   s.Textbook_Id,
                                                                   s.ReleaseCount,
                                                                   s.ReleaseDate,
                                                                   s.OutStockRecord.Operator,
                                                                   s.Recipient1Name,
                                                                   s.Recipient1Phone,
                                                                   s.ReleaseRecordId
                                                               });
            return _typeAdapter.Adapt<DropBookForStudentQueryView>(dropStudentBook);
        }
        /// <summary>
        /// 退还学生教材
        /// </summary>
        /// <param name="releaseRecordeIds"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public ResponseView DropStudenBookSubmit(IEnumerable<string> releaseRecordeIds, string studentId)
        {
            //数据类型转换
            Guid stID = studentId.ConvertToGuid();
            var term = new TermAppl().GetCurrentTerm().ToString();
            //根据学生Id,发放记录Id,取该生每本教材的退还数 
            var dorpBookCountForStudent = new List<StudentReleaseRecord>();
            foreach (string recordId in releaseRecordeIds)
            {
                var rId = recordId.ConvertToGuid();
                var studentRel =_studentReleaseRecordRepo.First(s => s.Student_Id == stID && s.ReleaseRecordId == rId);
                 dorpBookCountForStudent.Add(studentRel);
            }
           
            //根据发放记录Id,取对应的库存变更记录Id
            var stockRecordIds = new List<StudentReleaseRecord>();

            foreach (string recordId in releaseRecordeIds)
            {
                var rId = recordId.ConvertToGuid();
                var stockRecordId = _studentReleaseRecordRepo.First(s => s.ReleaseRecordId == rId);

                stockRecordIds.Add(stockRecordId);
            }
            //根据库存变更记录Id，取库存Id
            var inventoryIds = new List<Domain.Models.InStockRecord>();
            foreach (StudentReleaseRecord id in stockRecordIds)
            {
                var inventoryId = _inStockRecordRepo.First(i => i.StockRecordId == id.StockRecord_Id);

                inventoryIds.Add(inventoryId);
            }

            var result = new ResponseView();
            var message = string.Empty;
            var messageForResponse = string.Empty;
            var releaseRecordCount = 0;

            releaseRecordCount += dorpBookCountForStudent.Count();
            var successCount = 0;

            //删除库存变记录
            foreach (StudentReleaseRecord stockRecordId in stockRecordIds)
            {
                if (stockRecordId.StockRecord_Id != null)
                {
                    var stoockRecord = Domain.ReleaseBookService.CreateStockRecord((int) stockRecordId.StockRecord_Id);
                    _inStockRecordRepo.Remove(stoockRecord);
                    _inStockRecordRepo.Context.Commit();
                }
            }

            //修改库存数量
            foreach (InStockRecord view in inventoryIds)
            {
                var releaseCount = dorpBookCountForStudent.First(d => d.StockRecord_Id == view.StockRecordId).ReleaseCount;
                var inventory = Domain.ReleaseBookService.CreatInventoryAtDrop(view.Inventory_Id,
                                                                        releaseCount);
                _inventoryRepo.Modify(inventory);
                _inventoryRepo.Context.Commit();
            }

            //删除学生发放记录
            foreach (StudentReleaseRecord view in dorpBookCountForStudent)
            {
                var studentRecord =
                    Domain.ReleaseBookService.CreateStudentDropReleaseRecord(
                        view.ReleaseRecordId, stID);
                _studentReleaseRecordRepo.Remove(studentRecord);

                _studentReleaseRecordRepo.Context.Commit();
                successCount++;
            }


            return result;
        }
    }
}
