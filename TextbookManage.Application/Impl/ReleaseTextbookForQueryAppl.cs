using TextbookManage.IApplications;
using TextbookManage.ViewModels;
using TextbookManage.Infrastructure;
using System.Linq;
using TextbookManage.Infrastructure.TypeAdapter;
using System.Collections.Generic;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Domain.Models;

namespace TextbookManage.Applications.Impl
{
    public class ReleaseTextbookForQueryAppl : IReleaseTextbookForQueryAppl
    {
        #region 私有变量

        private readonly ITypeAdapter _adapter;// = ServiceLocator.Current.GetInstance<ITypeAdapter>();
        private readonly IStudentReleaseRecordRepository _recordRepo;
        private readonly ITeachingTaskRepository _taskRepo;
        private readonly IProfessionalClassRepository _classRepo;
        private readonly IStudentRepository _stuRepo;
        private readonly IBooksellerRepository _booksellerRepo;
        #endregion

        #region 构造函数
        public ReleaseTextbookForQueryAppl(ITypeAdapter adapter, IStudentReleaseRecordRepository recordRepo, ITeachingTaskRepository taskRepo, IProfessionalClassRepository classRepo, IStudentRepository stuRepo,IBooksellerRepository booksellerRepo)
        {
            _adapter = adapter;
            _recordRepo = recordRepo;
            _taskRepo = taskRepo;
            _classRepo = classRepo;
            _stuRepo = stuRepo;
            _booksellerRepo = booksellerRepo;
        }
        #endregion

        /// <summary>
        /// 获取学年学期
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TermView> GetTerm()
        {
            var terms = new TermAppl().GetAll();
            return _adapter.Adapt<TermView>(terms);
        }

        /// <summary>
        /// 根据登录名取学院
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public IEnumerable<SchoolView> GetSchoolByloginName(string loginName)
        {
            var schools = new SchoolAppl().GetSchoolOfUser(loginName);
            return _adapter.Adapt<SchoolView>(schools);
        }

        /// <summary>
        /// 取年级
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        public IEnumerable<string> GetGradeBySchoolId(string schoolId)
        {
            var id = schoolId.ConvertToGuid();
            return _classRepo.Find(t => t.School_Id == id).Select(t => t.Grade).Distinct();
        }

        /// <summary>
        /// 根据专业班级取课程
        /// </summary>
        /// <param name="term"></param>
        /// <param name="classNum"></param>
        /// <returns></returns>
        public IEnumerable<CourseView> GetCourseByClassNum(string classId)
        {
            var id = classId.ConvertToGuid();
            var task = _taskRepo.Find(t => t.ProfessionalClasses.FirstOrDefault(p => p.ProfessionalClassId == id).ProfessionalClassId == id);
            var courses = task.Select(t => t.Course);
            return _adapter.Adapt<CourseView>(courses);
        }

        /// <summary>
        /// 根据登录名取书商
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public IEnumerable<BooksellerView> GetBooksellerByloginName(string loginName)
        {
            //系统用户
            var user = new TbmisUserAppl(loginName).GetUser();

            //跟据书商员工Id取书商Id
            var booksellerStaffs = _booksellerRepo.GetAll().Select(bs => bs.BooksellerStaffs);

            IList<BooksellerView> list = new List<BooksellerView>();

            foreach (var staff in booksellerStaffs)
            {
                var bookseller = staff.SingleOrDefault(s => s.BooksellerStaffId == user.TbmisUserId);
                if (bookseller != null)
                {
                    var booksellers = new BooksellerView()
                    {
                        BooksellerId = bookseller.Bookseller_Id.ToString(),
                        Name = bookseller.Bookseller.Name
                    };
                    list.Add(booksellers);
                }
            }

            return list;
        }

        /// <summary>
        /// 根据学院，年级取专业班级
        /// </summary>
        /// <param name="schoolId"></param>
        /// <param name="grade"></param>
        /// <returns></returns>
        public IEnumerable<ProfessionalClassView> GetClassBySchoolIdAndGrade(string schoolId, string grade)
        {
            var id = schoolId.ConvertToGuid();
            var professionalClass = _classRepo.Find(c => c.School_Id == id && c.Grade == grade);

            return _adapter.Adapt<ProfessionalClassView>(professionalClass);
        }

        /// <summary>
        /// 根据专业班级取学生
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IEnumerable<StudentView> GetStudentByProfessionalClassId(string classId)
        {
            var id = classId.ConvertToGuid();
            var students = _stuRepo.Find(c => c.ProfessionalClass_Id == id);

            return _adapter.Adapt<StudentView>(students);
        }

        /// <summary>
        /// 根据学年学期，学生查询学生实发教材
        /// </summary>
        /// <param name="term"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public IEnumerable<StudentReleaseDetailView> GetStudentReleaseDetail(string term, string studentId)
        {
            var studentid = studentId.ConvertToGuid();

            var studentRecord = _recordRepo.Find(t => t.Term == term && t.Student_Id == studentid).Select(p => new StudentReleaseDetailView()
                {
                    TextbookId = p.Textbook_Id.ToString(),
                    TextbookName = p.Name,
                    RetailPrice = p.Price.ToString(),
                    DiscountPrice = p.DiscountPrice.ToString(),
                    Term = p.Term,
                    SchoolName = p.SchoolName,
                    ClassName = p.ClassName,
                    StudentNum = p.StudentNum,
                    ReleaseCount = p.ReleaseCount.ToString(),
                    Recipient = p.Recipient1Name,
                    Telephone = p.Recipient1Phone,
                    RecipientDate = p.ReleaseDate.ToString()
                });
            return _adapter.Adapt<StudentReleaseDetailView>(studentRecord);
        }

        /// <summary>
        ///  根据学年学期，班级查询班级实发教材
        /// </summary>
        /// <param name="term"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IEnumerable<ClassReleaseDetailView> GetClassReleaseDetail(string term, string classId)
        {
            var classid = classId.ConvertToGuid();

            var classRecord = _recordRepo.Find(t => t.Term == term && t.Class_Id == classid
                ).GroupBy(t => new
                    {
                        t.Term,
                        t.SchoolName,
                        t.ClassName,
                        t.BooksellerName,
                        t.Textbook_Id,
                        t.Name,
                        t.Isbn,
                        t.Press
                    }
                ).Select(d => new ClassReleaseDetailView()
                    {
                        Term = d.Key.Term,
                        SchoolName = d.Key.SchoolName,
                        BooksellerName = d.Key.BooksellerName,
                        TextbookId = d.Key.Textbook_Id.ToString(),
                        TextbookName = d.Key.Name,
                        Isbn = d.Key.Isbn,
                        Press = d.Key.Press,
                        ReleaseCount = d.Sum(p => p.ReleaseCount).ToString()
                    }
                );
            return classRecord;
        }

        /// <summary>
        /// 根据学年学期，书商查询书商实发教材
        /// </summary>
        /// <param name="term"></param>
        /// <param name="booksellerId"></param>
        /// <returns></returns>
        public IEnumerable<BooksellerReleaseDetailView> GetBooksellerReleaseDetail(string term, string booksellerId)
        {
            var id = booksellerId.ConvertToGuid();

            var booksellerRecord = _recordRepo.Find(t => t.Term == term && t.Bookseller_Id == id).GroupBy(t => new
                {
                    t.SchoolName,
                    t.Name,
                    t.Isbn,
                    t.Author,
                    t.Press,
                    t.Price
                }).Select(d => new BooksellerReleaseDetailView()
                    {
                        SchoolName = d.Key.SchoolName,
                        TextbookName = d.Key.Name,
                        Isbn = d.Key.Isbn,
                        Author = d.Key.Author,
                        Press = d.Key.Press,
                        RetailPrice = d.Key.Price.ToString(),
                        TotalCount = d.Sum(p => p.ReleaseCount).ToString(),
                        TotalRetailCharge = d.Sum(p => p.Price * p.ReleaseCount).ToString(),
                        TotalDiscountCharge = d.Sum(p => p.Discount * p.Price * p.ReleaseCount).ToString()
                    });
            return booksellerRecord;
        }
    }
}
