using System;
using System.Collections.Generic;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Infrastructure.TypeAdapter;
using TextbookManage.ViewModels;
using System.Linq;

namespace TextbookManage.Applications.Impl
{
   public class DropClassBookAppl:IDropClassBookAppl  
   {
       private readonly IStudentReleaseRecordRepository  _studentReleaseRecordRepo;
       
       private readonly ITypeAdapter _typeAdapter;
       private readonly IInventoryRepository _inventoryRepo;
       private readonly IInStockRecordRepository _inStockRecordRepo;
       private readonly ITypeAdapter _adapter;
       private readonly IProfessionalClassRepository _classRepository;
       public DropClassBookAppl(IInventoryRepository inventoryRepo, IStudentReleaseRecordRepository studentReleaseRecordRepo, ITypeAdapter typeAdapter, IInStockRecordRepository inStockRecordRepo, ITypeAdapter adapter, IProfessionalClassRepository classRepository)
       {
           _inventoryRepo = inventoryRepo;
           _studentReleaseRecordRepo = studentReleaseRecordRepo;
           _typeAdapter = typeAdapter;
           _inStockRecordRepo = inStockRecordRepo;
           _adapter = adapter;
           _classRepository = classRepository;
       }

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
       /// 根据班级Id，教材Id，取领用人名单
       /// </summary>
       /// <param name="classId"></param>
       /// <param name="textbookId"></param>
       /// <returns></returns>
       public IEnumerable<StudentForRecipientsView> GetRecipientsByTextbookId(string classId, string textbookId)
       {
           var cId = classId.ConvertToGuid();
           var tId = textbookId.ConvertToGuid();
           var recipients =_studentReleaseRecordRepo.Find(s => s.Class_Id == cId && s.Textbook_Id == tId)
                                        .Select(s => new StudentForRecipientsView {StudentId = s.Student_Id.ToString(), StudentNum = s.StudentNum,StudentName = s.StudentName });

           return _typeAdapter.Adapt<StudentForRecipientsView>(recipients);
       }   
        /// <summary>
        /// 根据班级Id，取班级待退回教材
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
       public IEnumerable<DorpBookForClassQueryView> GetClassDropBookByClassId(string classId)
       {
           var cId = classId.ConvertToGuid();

           var dropClassBook = _studentReleaseRecordRepo.Find(s => s.Class_Id == cId)
                                                          .Select(
                                                              s =>
                                                              new
                                                                  {
                                                                      s.Term,
                                                                      s.Name,
                                                                      s.Textbook_Id,
                                                                      s.ReleaseCount,
                                                                      s.Student,
                                                                      s.ReleaseRecordId  
                                                                  });
           return _typeAdapter.Adapt<DorpBookForClassQueryView>(dropClassBook);

       }
       /// <summary>
       /// 退还班级教材
       /// </summary>
       /// <param name="classId"></param>
       /// <param name="releaseRecordIds"></param>
       /// <returns></returns>
       public ResponseView DropClassBookSubmit(string classId, IEnumerable<string> releaseRecordIds)
       {
           //数据类型转换
           Guid cId = classId.ConvertToGuid();
           var term = new TermAppl().GetCurrentTerm().ToString();                                   
           //根据发放记录Id,当前学期，取该班级每本教材的退还数 
           var dorpBookCountForClass=new List<Domain.Models.StudentReleaseRecord>();
           foreach (string recordId in releaseRecordIds)
               {
               var rId = recordId.ConvertToGuid();
               var classRel = _studentReleaseRecordRepo.Find(s => s.Class_Id == cId && s.ReleaseRecordId==rId).GroupBy(s => new
               {
                   s.Textbook_Id,
                   s.ReleaseRecordId
               }).Select(d => new StudentReleaseRecord()
                   {
                   ReleaseRecordId = d.Key.ReleaseRecordId,
                   Textbook_Id = d.Key.Textbook_Id,
                   ReleaseCount = d.Sum(s => s.ReleaseCount)
                   });

               dorpBookCountForClass.AddRange(classRel);
           }
          
            //根据发放记录Id,取对应的库存变更记录Id
           var stockRecordIds = new List<Domain.Models.StudentReleaseRecord>();

           foreach (string releaseRecordId in releaseRecordIds)
           {
               var recordId = releaseRecordId.ConvertToGuid();
               var stockRecordId =_studentReleaseRecordRepo.First(s => s.ReleaseRecordId == recordId);
                                            
               stockRecordIds.Add(stockRecordId);
           }
           //根据库存变更记录Id，取库存Id
           var inventoryIds = new List<Domain.Models.InStockRecord>();
           foreach (StudentReleaseRecord id in stockRecordIds)
           {
               var inventoryId = _inStockRecordRepo.First(i =>i.StockRecordId==id.StockRecord_Id);

                inventoryIds.Add(inventoryId);
           }

           var result = new ResponseView();
           var message = string.Empty;
           var messageForResponse = string.Empty;
           var releaseRecordCount = 0;

           releaseRecordCount += releaseRecordIds.Count();
           var successCount = 0;
           
           //删除库存变记录
           foreach (Domain.Models.StudentReleaseRecord stockRecordId in stockRecordIds)
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
               var releaseCount = dorpBookCountForClass.First(d => d.StockRecord_Id == view.StockRecordId).ReleaseCount;
               var inventory = Domain.ReleaseBookService.CreatInventoryAtDrop(view.Inventory_Id,
                                                                       releaseCount);
               _inventoryRepo.Modify(inventory);
               _inventoryRepo.Context.Commit();
           }

           //删除班级发放记录
           foreach (string releaseRecordId in releaseRecordIds)
           {
                 var claID = classId.ConvertToGuid();
               var studentRecord =
                   Domain.ReleaseBookService.CreateClassDropReleaseRecord(
                       releaseRecordId.ConvertToGuid(), claID); 
                 _studentReleaseRecordRepo.Remove(studentRecord);
               
               _studentReleaseRecordRepo.Context.Commit();
               successCount++;
           }
          

           return result;                             
       }
    }
}
                                                    