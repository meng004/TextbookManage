using System;
using System.Collections.Generic;
using TextbookManage.Domain;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Infrastructure.TypeAdapter;
using System.Linq;
using TextbookManage.ViewModels;
using TextbookManage.Domain.IRepositories.JiaoWu;

namespace TextbookManage.Applications.Impl
{
    public class ReleaseStudentBookAppl : IReleaseStudentBookAppl
    {
        public struct OperatStockInfo
            {
               public  int InventoryId;
               public  DateTime StockDate;
            };
        #region 私有变量

        private readonly IStudentDeclarationRepository _declarationRepository;
        private readonly IStudentRepository _stuRepo;
        private readonly ITeachingTaskRepository _teachingTaskRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IOutStockRecordRepository _outStockRecordRepository;
        private readonly IBooksellerRepository _booksellerRepository;
        private readonly IProfessionalClassRepository _classRepository;
        private readonly IReleaseRecordRepository _releaseRecordRepository;
        private readonly ITypeAdapter _adapter;
        public ReleaseStudentBookAppl(IStudentDeclarationRepository declarationRepository, ITypeAdapter adapter, IStudentReleaseRecordRepository studentReleaseRecordRepository, IStudentRepository studentRepository, ITeachingTaskRepository teachingTaskRepository, ITextbookRepository textbookRepository, IInventoryRepository inventoryRepository, IOutStockRecordRepository outStockRecordRepository, IBooksellerRepository booksellerRepository, IProfessionalClassRepository classRepository, IReleaseRecordRepository releaseRecordRepository, ITypeAdapter typeAdapter)
        {
            _declarationRepository = declarationRepository;
            _stuRepo = studentRepository;
            _teachingTaskRepository = teachingTaskRepository;
            _inventoryRepository = inventoryRepository;
            _outStockRecordRepository = outStockRecordRepository;
            _booksellerRepository = booksellerRepository;
            _classRepository = classRepository;
            _releaseRecordRepository = releaseRecordRepository;
            _adapter = typeAdapter;
        }

        #endregion  

        #region  取列表绑定数据
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
        /// 根据班级Id取学生
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IEnumerable<ViewModels.StudentView> GetStudentByClassId(string classId)
        {
            var id = classId.ConvertToGuid();
            var students = _stuRepo.Find(c => c.ProfessionalClass_Id == id);

            return _adapter.Adapt<StudentView>(students);
        }
        /// <summary>
        /// 根据书商Id取仓库
        /// </summary>
        /// <param name="booksellerId"></param>
        /// <returns></returns>
        public IEnumerable<ViewModels.StorageView> GetStorageByBooksellerId(string booksellerId)
        {
            //系统用户
            var storageRepository = ServiceLocator.Current.GetInstance<IStorageRepository>();
            var bId = booksellerId.ConvertToGuid();
            var storages = storageRepository.Find(s => s.Bookseller_Id == bId).Select(s => new StorageView()
            {
                StorageId = s.ID.ToString(),
                Name = s.Name
            });

            return _adapter.Adapt<StorageView>(storages);
        }
        #endregion

        /// <summary>
        /// 根据学生Id和仓库Id取学生发放计划
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="storageId"></param>
        /// <returns></returns>
        public IEnumerable<ViewModels.ReleaseBookForStudentQueryView> GetStudentBookByStudentId(string studentId, string storageId)
        {
            //类型转换
            var stId = studentId.ConvertToGuid();
            //根据学生Id取班级Id
            var classId = _stuRepo.First(s => s.ID == stId).ProfessionalClass_Id;
            const FeedbackState feedbackState = FeedbackState.征订成功;
            //取学生教材待发放信息信息
           //var releaseStudentBookPlans =
           //         _declarationRepository.Find(dt => dt.ProfessionalClass_Id == classId&&dt.Subscription.FeedbackState==feedbackState)
           //                               .Select(dt => new ReleaseBookForStudentQueryView()
           //                                   {
           //                                       YearTerm = dt.Term, //学年学期
           //                                       CourseName =
           //                                          _teachingTaskRepository.First(
           //                                              t => t.TeachingTaskNum == dt.TeachingTask_Num).Course.Name, //课程名称
           //                                       TextbookId = dt.Textbook_Id.ToString(), //教材Id
           //                                       TextbookName = dt.Textbook.Name,//教材名称
           //                                       PlanCount = dt.DeclarationCount.ToString(), //计划数
           //                                       ShelfNum = _inventoryRepository.First(i=>i.Textbook_Id==dt.Textbook_Id).ShelfNumber,//架位号
           //                                       InventoryId = _inventoryRepository.First(i=>i.Textbook_Id==dt.Textbook_Id).InventoryId.ToString(),//库存Id
           //                                       InventoryCount = _inventoryRepository.First(i=>i.Textbook_Id==dt.Textbook_Id).InventoryCount.ToString(),//库存数量
           //                                       StorageId =_inventoryRepository.First(
           //                                       i=>i.InventoryId==_inventoryRepository.First(s=>s.Textbook_Id==dt.Textbook_Id).InventoryId).Storage_Id.ToString(),//库存Id
           //                                       Students=_stuRepo.Find(s=>s.ProfessionalClass_Id==classId).Select(s=>new StudentView()
           //                                           {
           //                                               Id=s.StudentId.ToString()
           //                                           })
           //                                   }).Where(dt => dt.YearTerm==new TermAppl().GetCurrentTerm().ToString()&&dt.StorageId == storageId&&!string.IsNullOrEmpty(dt.Students.First(st=>st.Id==studentId).Id));
           // return releaseStudentBookPlans;
            return new List<ViewModels.ReleaseBookForStudentQueryView>();
        }
        /// <summary>
        /// 发放学生教材提交
        /// </summary>
        /// <param name="views"></param>
        /// <returns></returns>
        public ViewModels.ResponseView ReleaseStudentBookSubmit(IEnumerable<ViewModels.ReleaseBookSubmitForStudentView> views)
        {
//            int successCount = 0;
//            int planCount =views.Count();
//             //修改库存数量
//// ReSharper disable PossibleMultipleEnumeration
//            var releaseBookSubmitForStudentViews = views as IList<ReleaseBookSubmitForStudentView> ?? views.ToList();
//            foreach (var releaseBookSubmit in releaseBookSubmitForStudentViews)
//// ReSharper restore PossibleMultipleEnumeration
//            {
//                var inventory = Domain.ReleaseBookService.CreatInventoryAtDrop(Convert.ToInt32(releaseBookSubmit.InventoryId),
//                                                                        Convert.ToInt32(releaseBookSubmit.ReleaseCount));
//                _inventoryRepository.Modify(inventory);
//                _inventoryRepository.uow.Commit();   
//            }
//            //变更库存记录
//            var stockInos=new List<OperatStockInfo>();
//            foreach (var releaseBookSubmit in releaseBookSubmitForStudentViews)
//            {
//                var stockInfo = new OperatStockInfo();
//                stockInfo.InventoryId = releaseBookSubmit.InventoryId.ConvertToInt();
//                stockInfo.StockDate = DateTime.Now;
//                stockInos.Add(stockInfo);

//                var outStockRecord =
//                    ReleaseBookService.CreateOutStockRecord(releaseBookSubmit.InventoryId.ConvertToInt(),
//                                                            releaseBookSubmit.ReleaseCount.ConvertToInt(),
//                                                            stockInfo.StockDate,
//                                                            releaseBookSubmit.BooksellerStaffName);
//                _outStockRecordRepository.Add(outStockRecord);

//                _outStockRecordRepository.uow.Commit();
//            }
//            //取刚才产生的库存变更记录ID
//            var stockRecordIds=new List<string>();
//            foreach (var stockInfo in stockInos)
//            {
//                var stockRecordId =
//                    _outStockRecordRepository.First(o => o.Inventory_Id == stockInfo.InventoryId).StockRecordId.ToString();

//                stockRecordIds.Add(stockRecordId);
//            }
//            //添加发放记录
//            for (int i = 0; i < releaseBookSubmitForStudentViews.Count(); i++)
//            {
//                var inventoryId = releaseBookSubmitForStudentViews[i].InventoryId.ConvertToInt(); 
//                var textbookId =_inventoryRepository.First(ir => ir.InventoryId == inventoryId).Textbook_Id;
//                var recordId = new Guid();

//                //跟据书商员工姓名取书商Id
//                var booksellerStaffs = _booksellerRepository.GetAll().Select(bs => bs.BooksellerStaffs);
//                Guid booksellerId = Guid.Empty;
//                foreach (var staff in booksellerStaffs)
//                {
//                    booksellerId =
//                        staff.First(s => s.StaffName == releaseBookSubmitForStudentViews[i].BooksellerStaffName)
//                             .Bookseller_Id;
//                    if(booksellerId!=Guid.Empty)
//                         break;
//                }
//                //根据StudentId取学院和班级Id
//                var stId = releaseBookSubmitForStudentViews[i].StudentId.ConvertToGuid();
//                var classId = _stuRepo.First(st => st.StudentId== stId).ProfessionalClass_Id;
//                var schoolId = _classRepository.First(c => c.ProfessionalClassId == classId).School_Id;

//                //领书人信息
//                var stur = new Student
//                    {
//                        Name = releaseBookSubmitForStudentViews[i].RecipientName,
//                        Num = releaseBookSubmitForStudentViews[i].RecipientTelephone
//                    };

//                var record = ReleaseBookService.CreateReleaseRecord(recordId, Convert.ToInt32(stockRecordIds[i]),
//                                                                    textbookId, booksellerId, schoolId,
//                                                                    releaseBookSubmitForStudentViews[i].ReleaseCount.ConvertToInt(),
//                                                                    stId, classId, stur); 

//                _releaseRecordRepository.Add(record);
//                _releaseRecordRepository.uow.Commit();
//                successCount++;
//            }

            //var view = new ResponseView {Message = string.Format("共{0}条,成功{1}条！", planCount, successCount)};

            return new ResponseView();
        }
    }
}
