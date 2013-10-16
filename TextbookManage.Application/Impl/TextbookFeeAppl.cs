using TextbookManage.IApplications;
using TextbookManage.ViewModels;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure;
using TextbookManage.Infrastructure.TypeAdapter;
using TextbookManage.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TextbookManage.Applications.Impl
{
    public class TextbookFeeAppl : ITextbookFeeAppl
    {
        #region 私有变量

        private readonly ISchoolRepository _schoolRepo;// = ServiceLocator.Current.GetInstance<ISchoolRepository>();
        private readonly IStudentReleaseRecordRepository _studentRecordRepo;//= ServiceLocator.Current.GetInstance<IStudentReleaseRecordRepository>();
        private readonly ITypeAdapter _adapter;// = ServiceLocator.Current.GetInstance<ITypeAdapter>();
        private readonly IProfessionalClassRepository _classRepo;//= ServiceLocator.Current.GetInstance<IProfessionalClassRepository>();
        private readonly IStudentRepository _stuRepo;
        private readonly ITeachingTaskRepository _taskRepo;
        private readonly IBooksellerRepository _booksellerRepo;
        #endregion

        #region 构造函数
        public TextbookFeeAppl(ITypeAdapter adapter, ISchoolRepository schoolRepo, IStudentRepository stuRepo, IStudentReleaseRecordRepository stuReleaseRepo, IProfessionalClassRepository proClassRepo, ITeachingTaskRepository taskRepo, IBooksellerRepository booksellerRepo)
        {
            _adapter = adapter;
            _schoolRepo = schoolRepo;
            _classRepo = proClassRepo;
            _stuRepo = stuRepo;
            _studentRecordRepo = stuReleaseRepo;
            _taskRepo = taskRepo;
            _booksellerRepo = booksellerRepo;
        }

        public TextbookFeeAppl()
        {
            
        }

        #endregion

        #region 下拉列表数据
        /// <summary>
        /// 根据登录名取学院
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public IEnumerable<SchoolView> GetSchoolByloginName(string loginName)
        {
            //系统用户
            var user = new TbmisUserAppl(loginName).GetUser();

            //取当前登录用户的学院

            var schoolAppl = new SchoolAppl();
            var school = schoolAppl.GetSchoolOfUser(loginName);
            return _adapter.Adapt<SchoolView>(school);
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
        /// 根据专业班级取课程
        /// </summary>
        /// <param name="classNum"></param>
        /// <returns></returns>
        public IEnumerable<CourseView> GetCourseByClassId(string classId)
        {
            var id = classId.ConvertToGuid();
            var task = _taskRepo.Find(t => t.ProfessionalClasses.FirstOrDefault(p => p.ProfessionalClassId == id).ProfessionalClassId == id);
            var courses = task.Select(t => t.Course);
            return _adapter.Adapt<CourseView>(courses);
        }

        /// <summary>
        /// 根据班级取学生
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
        /// 取学年学期
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TermView> GetTerm()
        {
            var terms = new TermAppl().GetAll();
            return _adapter.Adapt<TermView>(terms);
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

            //IList<BooksellerView> list=new List<BooksellerView>();

            //var bookseller = new BooksellerAppl().GetOfUser(loginName);

            //if (bookseller!=null)              
            //{
            //    var booksellers = new BooksellerView()
            //    {
            //        BooksellerId = bookseller.BooksellerId.ToString(),
            //        Name = bookseller.Name
            //    };
            //    list.Add(booksellers);
            //    return list;
            //}
            //else
            //{
            //    IEnumerable<BooksellerView> booksellers = new List<BooksellerView>
            //    {
            //        new BooksellerView { BooksellerId = string.Empty, Name = "没有书商" }
            //    };
            //    return booksellers;
            //}

        }
        #endregion

        #region 查询教材费用
        /// <summary>
        /// 根据学年学期，专业班级取班级教材费用
        /// </summary>
        /// <param name="term"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IEnumerable<TextbookFeeForProfessionalClassView> GetProfessionalClassFee(string term, string classId)
        {
            var classid = classId.ConvertToGuid();

            var classFee = _studentRecordRepo.Find(t => t.Term == term && t.Class_Id == classid
               ).GroupBy(t => new
            {
                t.StudentNum,
                t.StudentName
            }).Select(d => new TextbookFeeForProfessionalClassView()
               {
                   StudentNum = d.Key.StudentNum,
                   StudentName = d.Key.StudentName,
                   TotalCount = d.Sum(t => t.ReleaseCount).ToString(),
                   TotalRetailPrice = d.Sum(t => t.Price).ToString(),
                   DiscountTotalPrice = d.Sum(t => t.DiscountPrice).ToString()
               });
            return classFee;
        }

        /// <summary>
        /// 根据学年学期，学生取学生个人教材费用
        /// </summary>
        /// <param name="term"></param>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public IEnumerable<TextbookFeeForStudentView> GetStudentFee(string term, string studentNum)
        {
            var studentFee = _studentRecordRepo.Find(t => t.Term == term && t.StudentNum == studentNum
                ).GroupBy(t => new
                    {
                        t.Textbook_Id,
                        t.Name,
                        t.Isbn,
                        t.Author,
                        t.Press,
                        t.Price,
                        t.Discount
                    }).Select(d => new TextbookFeeForStudentView()
                    {

                        TextbookId = d.Key.Textbook_Id.ToString(),
                        TextbookName = d.Key.Name,
                        Isbn = d.Key.Isbn,
                        Author = d.Key.Author,
                        Press = d.Key.Press,
                        RetailPrice = d.Key.Price.ToString(),
                        Discount = d.Key.Discount.ToString(),
                        ReleaseCount = d.Sum(t => t.ReleaseCount).ToString(),
                        DiscountPrice = d.Sum(t => t.DiscountPrice).ToString()
                    });
            return studentFee;
        }

        /// <summary>
        /// 根据学年学期，书商，专业班级取书商班级教材费用
        /// </summary>
        /// <param name="term"></param>
        /// <param name="booksellerId"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IEnumerable<TextbookFeeForBooksellerProfessionClassView> GetBooksellerProfessionalClassFee(string term, string booksellerId, string classId)
        {

            var booksellerid = booksellerId.ConvertToGuid();
            var classid = classId.ConvertToGuid();

            //var fee = from p in _studentRecordRepo.GetAll()
            //          where
            //              p.Bookseller_Id == booksellerId.ConvertToGuid() && p.Class_Id == classId.ConvertToGuid() &&
            //              p.Term == term
            //          group p by p.Textbook_Id
            //              into s
            //              select new
            //                  {
            //                      name = s.Key,
            //                      count = s.Sum(a => a.ReleaseCount)
            //                  };

            var booksellerFee = _studentRecordRepo.Find(t =>
                                              t.Term == term &&
                                              t.Bookseller_Id == booksellerid &&
                                              t.Class_Id == classid
                ).GroupBy(t => new
                    {
                        t.Textbook_Id,
                        t.Name,
                        t.Isbn,
                        t.Author,
                        t.Press,
                        t.Price,
                        t.Discount
                    }).Select(d => new TextbookFeeForBooksellerProfessionClassView
                                            {
                                                TextbookId = d.Key.Textbook_Id.ToString(),
                                                TextbookName = d.Key.Name,
                                                Isbn = d.Key.Isbn,
                                                Author = d.Key.Author,
                                                Press = d.Key.Press,
                                                RetailPrice = d.Key.Price.ToString(),
                                                Discount = d.Key.Discount.ToString(),
                                                ReleaseCount = d.Sum(t => t.ReleaseCount).ToString(),
                                                TotalRetailPrice = d.Sum(t => t.ReleaseCount * t.Price).ToString(),
                                                DiscountTotalPrice = d.Sum(t => t.Discount * t.Price).ToString()
                                            });
            return booksellerFee;
        }
        #endregion
    }
}
