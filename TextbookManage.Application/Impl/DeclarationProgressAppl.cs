using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.IApplications;
using TextbookManage.ViewModels;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure;
using TextbookManage.Infrastructure.TypeAdapter;

namespace TextbookManage.Applications.Impl
{
    public class DeclarationProgressAppl : IDeclarationProgressAppl
    {

        #region 私有变量

        private readonly ITypeAdapter _adapter;//= ServiceLocator.Current.GetInstance<ITypeAdapter>();
        private readonly ISchoolRepository _schoolRepo;//= ServiceLocator.Current.GetInstance<ITeachingTaskRepository>();
        private readonly IDepartmentRepository _departRepo;
        #endregion

        #region 构造函数

        public DeclarationProgressAppl(ITypeAdapter adapter, ISchoolRepository schoolRepo, IDepartmentRepository departRepo)
        {
            _adapter = adapter;
            _schoolRepo = schoolRepo;
            _departRepo = departRepo;
        }
        #endregion

        #region 实现接口

        public IEnumerable<DataSignView> GetDataSign()
        {
            var result = new DataSignAppl().GetAll();
            result = result.OrderByDescending(t => t.Name);
            return _adapter.Adapt<DataSignView>(result);
        }

        public IEnumerable<SchoolProgressView> GetSchoolProgress(string dataSignId)
        {
            var term = new TermAppl().GetMaxTerm();
            //取教学任务
            //因数据库中的学院或系教研室可能为空，所以入口为学院而不是教学任务
            var teachingTasks = _schoolRepo.GetAll()
                .SelectMany(t =>
                    t.Departments
                    ).SelectMany(t =>
                        t.TeachingTasks
                        ).Where(t =>
                            t.XNXQ.Year == term.SchoolYearTerm.Year &&
                            t.XNXQ.Term == term.SchoolYearTerm.Term &&
                            t.DataSign_Id == dataSignId
                            );

            //创建学院进度
            var result = Domain.DeclarationService.CreateSchoolProgress(teachingTasks);
            //按学院名称排序
            result = result.OrderByDescending(t => t.School.Name);

            return _adapter.Adapt<SchoolProgressView>(result);
        }


        public IEnumerable<DepartmentView> GetDepartments(string schoolId)
        {
            var id = schoolId.ConvertToGuid();
            //显示全部教研室
            var departments = new DepartmentAppl().GetDepartmentBySchoolId(id);
            //排序
            departments = departments.OrderBy(t => t.Name);
            return _adapter.Adapt<DepartmentView>(departments);
        }

        public IEnumerable<DepartmentProgressView> GetDepartmentProgress(string dataSignId, string departmentId)
        {
            //取最大学期
            var term = new TermAppl().GetMaxTerm();
            var id = departmentId.ConvertToGuid();
            //取教学任务
            //因数据库中的学院或系教研室可能为空，所以入口为学院而不是教学任务
            var teachingTasks = _departRepo.First(t =>
                t.DepartmentId == id
                ).TeachingTasks
                    .Where(t =>
                        t.XNXQ.Year == term.SchoolYearTerm.Year &&
                        t.XNXQ.Term == term.SchoolYearTerm.Term &&
                        t.DataSign_Id == dataSignId
                        );
            //创建系教研室进度
            var result = Domain.DeclarationService.CreateDepartmentProgress(teachingTasks);
            //按课程名称排序
            result = result.OrderBy(t => t.Course.Name);

            return _adapter.Adapt<DepartmentProgressView>(result);
        }
        #endregion

    }
}
