using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.IRepositories.JiaoWu;
using TextbookManage.Domain.Models;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Infrastructure.TypeAdapter;
using TextbookManage.ViewModels;

namespace TextbookManage.Applications.Impl
{
    public class ReleaseClassBookAppl : IReleaseClassBookAppl
    {

        #region 私有变量

        private readonly ITypeAdapter _adapter;
        private readonly IProfessionalClassRepository _classRepo;
        private readonly ISubscriptionRepository _subscriptionRepo;
        private readonly IInventoryRepository _inventoryRepo;
        private readonly IStorageRepository _storageRepo;
        #endregion

        #region 构造函数

        public ReleaseClassBookAppl(ITypeAdapter adapter, IProfessionalClassRepository classRepo, ISubscriptionRepository subscriptionRepo, IInventoryRepository inventoryRepo, IStorageRepository storageRepo)
        {
            _adapter = adapter;
            _classRepo = classRepo;
            _subscriptionRepo = subscriptionRepo;
            _inventoryRepo = inventoryRepo;
            _storageRepo = storageRepo;
        }
        #endregion

        #region 实现接口

        /// <summary>
        /// 取书商发放的学院
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public IEnumerable<SchoolView> GetSchoolByLoginName(string loginName)
        {
            //学生学院
            var schools = new BooksellerAppl().GetSchoolByLoginName(loginName);
                    
            return _adapter.Adapt<SchoolView>(schools);
            
        }

        public IEnumerable<string> GetGradeBySchoolId(string schoolId)
        {
            var id = schoolId.ConvertToGuid();
            return new ProfessionalClassAppl().GetGradeBySchoolId(id);
        }

        public IEnumerable<ProfessionalClassBaseView> GetClassBySchoolId(string schoolId, string grade)
        {
            var id = schoolId.ConvertToGuid();
            var classes = new ProfessionalClassAppl().GetBySchoolIdAndGrade(id, grade);
            return _adapter.Adapt<ProfessionalClassBaseView>(classes);
        }

        public IEnumerable<StorageView> GetStorages(string loginName)
        {
            var storages = new StorageAppl(_adapter, _storageRepo).GetByLoginName(loginName);
            return _adapter.Adapt<StorageView>(storages);
        }

        public ResponseView GetStudentNameByStudentNum(string studentNum)
        {
            var name = new StudentAppl().GetNameByNum(studentNum);
            var result = new ResponseView();
            if (name.Contains("没有该学生"))
            {
                result.IsSuccess = false;
            }
            result.Message = name;
            return result;
        }

        public IEnumerable<InventoryForReleaseClassView> GetInventoriesByClassId(string classId, string storageId)
        {
            return new List<InventoryForReleaseClassView>();
            //var professionalClassId = classId.ConvertToGuid();
            //var storageid = storageId.ConvertToGuid();
            //var term = new TermAppl().GetMaxTerm().YearTerm;

            //var professionalClass = _classRepo.First(t => t.ID == professionalClassId);
            ////取班级教材与申报数量
            //var textbooks = professionalClass.DeclarationClasses.Select(t=>t.Declaration)
            //    .Where(t =>
            //        t.Term == term &&
            //        t.FeedbackState == FeedbackState.征订成功
            //        ).Select(t => new
            //        {
            //            TextbookId = t.Textbook_Id,
            //            DeclarationCount = t.DeclarationCount
            //        });
            ////教材ID
            //var ids = textbooks.Select(t => t.TextbookId);
            ////取库存中相应教材
            //var inventories = _inventoryRepo.Find(t =>
            //    t.Storage_Id == storageid &&
            //    ids.Contains(t.Textbook_Id)
            //    );

            //var views = _adapter.Adapt<InventoryForReleaseClassView>(inventories);

            ////添加发放数量，与未领书学生名单
            //foreach (var item in views)
            //{
            //    var textbookId = item.TextbookId.ConvertToGuid();
            //    ////发放数量 = 申报数量 - 已领取的教材数量
            //    //item.ReleaseCount = textbooks.First(t =>
            //    //    t.TextbookId == textbookId
            //    //    ).DeclarationCount -
            //    //    professionalClass.ReleaseCount(textbookId);

            //    //申报数量
            //    item.DeclarationCount = textbooks.First(t => t.TextbookId == textbookId).DeclarationCount;
            //    //未领书学生名单
            //    item.Students = GetNotReleaseStudents(classId, item.TextbookId);
            //    //人均数量
            //    var averageCount = (int)Math.Floor((decimal)item.DeclarationCount / item.Students.Count());
            //    //至少等于1
            //    item.AverageCount = (averageCount == 0 ? 1 : averageCount);
            //    //发放数 = 人均数 * 人数
            //    item.ReleaseCount = item.AverageCount * item.Students.Count();


            //    //根据库存数量是否满足发放要求，设置CheckFlag
            //    if (item.InventoryCount > item.ReleaseCount)
            //    {
            //        item.CheckFlag = true;
            //    }
            //}

            ////移除已发放完毕的教材
            //return views.Where(t => t.ReleaseCount > 0).OrderBy(t => t.Name);
        }

        public IEnumerable<StudentView> GetNotReleaseStudents(string classId, string textbookId)
        {
            return new List<StudentView>();
            //var professionalClassId = classId.ConvertToGuid();
            //var bookId = textbookId.ConvertToGuid();

            //var students = _classRepo.First(t =>
            //    t.ProfessionalClassId == professionalClassId
            //    ).Students
            //    .Where(t =>
            //        t.ReleaseCount(bookId) == 0    //发放数量为0，包含领取退还的情况
            //        );

            //var views = _adapter.Adapt<StudentView>(students);
            //foreach (var item in views)
            //{
            //    item.CheckFlag = true;
            //}

            //return views.OrderBy(t => t.Num);
        }

        public ResponseView SubmitReleaseClass(IEnumerable<InventoryForReleaseClassView> inventoryViews, ReleaseBookForClassView releaseView)
        {
            return new ResponseView();
            //var user = new TbmisUserAppl(releaseView.Operator).GetUser();
            //var person = user.TbmisUserName;
            //var term = new TermAppl().GetMaxTerm().YearTerm;

            //var result = new ResponseView();
            //var repo = ServiceLocator.Current.GetInstance<IInventoryRepository>();

            ////修改库存记录
            //foreach (var item in inventoryViews)
            //{
            //    //取库存
            //    var inventoryId = item.InventoryId.ConvertToInt();
            //    var inventory = repo.First(t => t.InventoryId == inventoryId);
            //    //取领书的学生
            //    var students = item.Students.Where(t => t.CheckFlag == true);
            //    //创建出库记录
            //    var stockRecord = InventoryService.CreateStockRecord<OutStockRecord>(inventory, person, 0);

            //    //创建学生发放记录
            //    //只处理选中的学生
            //    foreach (var record in students)
            //    {
            //        var studentId = record.StudentId.ConvertToGuid();
            //        var student = new StudentAppl().GetById(studentId);

            //        var studentRecord = new StudentReleaseRecord
            //        {
            //            ReleaseRecordId = Guid.NewGuid(),
            //            Author = item.Author,
            //            Bookseller_Id = (Guid)user.SchoolId,
            //            BooksellerName = user.SchoolName,
            //            Class_Id = student.ProfessionalClass_Id,
            //            ClassName = student.ProfessionalClass.Name,
            //            Edition = item.Edition.ConvertToInt(),
            //            Gender = record.Gender,
            //            Isbn = item.Isbn,
            //            IsSelfCompile = item.IsSelfCompile.ConvertToBool(),
            //            Num = item.Num.ConvertToInt(),
            //            Name = item.Name,
            //            PageCount = item.PageCount.ConvertToInt(),
            //            Press = item.Press,
            //            PressAddress = item.PressAddress,
            //            Price = item.Price,
            //            Discount = item.Discount,
            //            DiscountPrice = item.DiscountPrice,
            //            PrintCount = item.PrintCount.ConvertToInt(),
            //            PublishDate = item.PublishDate,
            //            Recipient1Name = releaseView.RecipientName,
            //            Recipient1Phone = releaseView.RecipientTelephone,
            //            Recipient2Name = releaseView.Recipient2Name,
            //            Recipient2Phone = releaseView.Recipient2Telephone,
            //            //ReleaseCount = (int)Math.Floor(releaseCount / students.Count()),//人均发放数量 = 应发总数 / 未领书人数，取地板
            //            ReleaseCount = item.AverageCount,
            //            ReleaseDate = DateTime.Now,
            //            School_Id = student.ProfessionalClass.School_Id,
            //            SchoolName = student.ProfessionalClass.School.Name,
            //            Student_Id = student.StudentId,
            //            StudentNum = student.Num,
            //            StudentName = student.Name,
            //            Textbook_Id = item.TextbookId.ConvertToGuid(),
            //            TextbookType = item.TextbookType,
            //            StockRecord_Id = stockRecord.StockRecordId,
            //            Term = term
            //        };
            //        //检查发放数量，避免为0，最少是1
            //        if (studentRecord.ReleaseCount == 0)
            //        {
            //            studentRecord.ReleaseCount = 1;
            //        }
            //        //添加发放记录
            //        stockRecord.ReleaseRecords.Add(studentRecord);
            //        //修改出入库数量
            //        stockRecord.StockCount += studentRecord.ReleaseCount;

            //    }
            //    //修改库存
            //    inventory.InventoryCount -= stockRecord.StockCount;
            //    //检查库存数量
            //    if (inventory.InventoryCount <= 0)
            //    {
            //        result.IsSuccess = false;
            //        result.Message = "库存数量不足，无法继续发放";
            //        return result;
            //    }
            //    //添加到仓储
            //    repo.Modify(inventory);
            //}

            //try
            //{
            //    repo.Context.Commit();
            //    return result;
            //}
            //catch (Exception e)
            //{
            //    result.IsSuccess = false;
            //    result.Message = "发放失败";
            //    return result;
            //}
        }

        #endregion

    }
}
