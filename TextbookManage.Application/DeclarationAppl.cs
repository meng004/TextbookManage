using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextbookManage.IApplications;
using TextbookManage.ViewModels;
using TextbookManage.IServices.Jw;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure.TypeAdapter;
using TextbookManage.Infrastructure;

namespace TextbookManage.Applications
{
    class DeclarationAppl : IDeclaration
    {

        private readonly ITeachingTaskService _teachingTaskImpl = ServiceLocator.Current.GetInstance<ITeachingTaskService>();
        private readonly IStudentClassService _stuClassImpl = ServiceLocator.Current.GetInstance<IStudentClassService>();
        private readonly IStudentDeclarationRepository _stuDeclRepo;
        private readonly ITeacherDeclarationRepository _teaDeclRepo;
        private readonly IDeclarationRepository _declRepo;
        private readonly ITermService _termImpl = ServiceLocator.Current.GetInstance<ITermService>();
        private readonly Infrastructure.TypeAdapter.ITypeAdapter _adapter = ServiceLocator.Current.GetInstance<ITypeAdapter>();

        public DeclarationAppl()
        {

        }

        public IEnumerable<TeachingTaskView> GetTeachingTasksByCourseIdAndDepartmentId(string courseId, string departmentId, string dataSignNum)
        {
            var term = _termImpl.GetCurrent();
            var result = _teachingTaskImpl.GetByCourseId(courseId, departmentId, dataSignNum, term);
            return _adapter.Adapt<TeachingTaskView>(result);
        }

        public IEnumerable<StudentClassView> GetProfessinalClassList(string teachingClassNum)
        {
            var result = _teachingTaskImpl.GetStudentClassById(teachingClassNum);
            return _adapter.Adapt<StudentClassView>(result);
        }

        public FeedbackView GetFeedbackByDeclarationId(string declarationId)
        {
            var id = declarationId.ConvertToInt();
            var result = _declRepo.GetFeedbackByDeclarationId(id);
            return _adapter.Adapt<FeedbackView>(result);
        }

        public IEnumerable<ApprovalView> GetApprovalDeclarationsByDeclarationId(string declarationId)
        {
            var id = declarationId.ConvertToInt();
            var result = _declRepo.First(t => t.DeclarationID == id).DeclarationApprovals;
            return _adapter.Adapt<ApprovalView>(result);
        }

        public IEnumerable<DeclarationView> GetDeclarationsByTeachingClassNum(string teachingClassNum)
        {
            var result = _declRepo.Find(t => t.TeachingTask_Num == teachingClassNum);
            return _adapter.Adapt<DeclarationView>(result);
        }

        public void SubmitDeclarationForStudent(IEnumerable<TeachingTaskView> teachingTaskViews, TextbookView textbookView, string homePhone, string mobile, string declarationCount, ref string message)
        {
            
        }

        public void SubmitDeclarationForTeacher(IEnumerable<TeachingTaskView> teachingTaskViews, TextbookView textbookView, string homePhone, string mobile, string declarationCount, ref string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RecipientTypeView> GetRecipientTypeList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DeclarationView> GetDeclarations(string term, string courseId, string departmentId, string recipientTypeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SchoolView> GetSchoolList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DepartmentView> GetDepartmentListBySchoolId(string schoolId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseView> GetCourseListByDepartmentId(string departmentId)
        {
            throw new NotImplementedException();
        }

        public TextbookView GetTextbookById(string textbookId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TextbookView> GetTextbooksByTextbookNameOrISBN(string textbookName, string isbn)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TermView> GetTermList()
        {
            throw new NotImplementedException();
        }

        public string Year
        {
            get { throw new NotImplementedException(); }
        }

        public string Term
        {
            get { throw new NotImplementedException(); }
        }

        public string CurrentYearTerm
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<DataSignView> GetDataSignList()
        {
            throw new NotImplementedException();
        }

        public DataSignView GetDataSignById(string dataSignId)
        {
            throw new NotImplementedException();
        }
    }
}
