using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.IApplications;
using TextbookManage.ViewModels;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Infrastructure.TypeAdapter;
using TextbookManage.Domain.Models;
using TextbookManage.Domain.IRepositories.JiaoWu;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Applications.Impl
{
    public class DeclarationApprovalAppl : IDeclarationApprovalAppl
    {

        #region 私有变量

        private readonly ITypeAdapter _adapter;// = ServiceLocator.Current.GetInstance<ITypeAdapter>();
        private readonly IDeclarationRepository _declRepo;
        #endregion

        #region 构造函数

        public DeclarationApprovalAppl(ITypeAdapter adapter, IDeclarationRepository declRepo)
        {
            _adapter = adapter;
            _declRepo = declRepo;
        }
        #endregion

        #region 实现接口

        public IEnumerable<SchoolView> GetSchoolWithNotApproval(string loginName)
        {
            //系统用户
            var user = new TbmisUserAppl(loginName).GetUser();
            //最大学期
            var term = new TermAppl().GetMaxTerm().YearTerm;

            IList<School> schools = new List<School>();

            ////如果是教务处或教材科，取全部学院
            //if (user.IsInRole("教务处"))
            //{
            //    var school = _declRepo.Find(t =>
            //        t.Term == term &&
            //        t.ApprovalState == ApprovalState.教务处审核中
            //        ).Select(t =>
            //            t.TeachingTask.Department.School
            //            ).Distinct();
            //    schools = school.ToList();
            //}
            //else if (user.IsInRole("教材科"))
            //{
            //    var school = _declRepo.Find(t =>
            //        t.Term == term &&
            //        t.ApprovalState == ApprovalState.教材科审核中
            //        ).Select(t =>
            //            t.TeachingTask.Department.School
            //            ).Distinct();
            //    schools = school.ToList();
            //}
            ////如果是学院院长，返回所属学院
            //else if (user.IsInRole("学院院长") || user.IsInRole("教研室主任"))
            //{
            //    var school = new School { SchoolId = (Guid)user.SchoolId, Name = user.SchoolName };
            //    schools.Add(school);
            //}
            if (schools.Count > 0)
            {
                return _adapter.Adapt<SchoolView>(schools);
            }
            else
            {
                IEnumerable<SchoolView> school = new List<SchoolView>
                {
                    new SchoolView { SchoolId = string.Empty, Name = "没有需要审核的学院" }
                };
                return school;
            }
        }

        public IEnumerable<DeclarationForApprovalView> GetDeclarationWithNotApproval(string loginName, string schoolId)
        {
            //登录用户
            var webUser = new TbmisUserAppl(loginName).GetUser();
            //最大学期
            var term = new TermAppl().GetMaxTerm().YearTerm;
            var id = schoolId.ConvertToGuid();

            IEnumerable<Declaration> declarations = new List<Declaration>();

            ////如果是教务处或教材科，取全部
            //if (webUser.IsInRole("教务处"))
            //{
            //    declarations = _declRepo.Find(t =>
            //        t.Term == term &&
            //        t.ApprovalState == ApprovalState.教务处审核中 &&
            //        t.TeachingTask.Department.School_Id == id
            //        );
            //}
            //else if (webUser.IsInRole("教材科"))
            //{
            //    declarations = _declRepo.Find(t =>
            //        t.Term == term &&
            //        t.ApprovalState == ApprovalState.教材科审核中 &&
            //        t.TeachingTask.Department.School_Id == id
            //        );
            //}
            ////如果是学院院长，返回所属学院
            //else if (webUser.IsInRole("学院院长"))
            //{
            //    declarations = _declRepo.Find(t =>
            //        t.Term == term &&
            //        t.ApprovalState == ApprovalState.学院审核中 &&
            //        t.TeachingTask.Department.School_Id == id
            //        );
            //}
            ////如果是教研室主任，返回所属系教研室未审核记录
            //else if (webUser.IsInRole("教研室主任"))
            //{
            //    //取登录用户所属教研室ID
            //    var ids = new DepartmentAppl().GetDepartmentBySchoolId(loginName, id).Select(t => t.DepartmentId);
            //    //取上述教研室申报的未审核用书
            //    declarations = _declRepo.Find(t =>
            //        t.Term == term &&
            //        t.ApprovalState == ApprovalState.教研室审核中 &&
            //        ids.Contains(t.TeachingTask.Department.DepartmentId));
                    
            //}
            //结果处理
            if (declarations.Count() > 0)
            {
                return _adapter.Adapt<DeclarationForApprovalView>(declarations);
            }
            else
            {
                return new List<DeclarationForApprovalView>();
            }
        }

        public ResponseView SubmitDeclarationApproval(IEnumerable<DeclarationForApprovalView> declarations, string loginName, string suggestion, string remark)
        {
            //数据类型转换
            var sugg = suggestion.ConvertToBool();
            //审核人姓名与学院
            var user = new TbmisUserAppl(loginName).GetUser();
            var division = user.SchoolName;
            var auditor = user.TbmisUserName;

            //CUD仓储
            var repo = ServiceLocator.Current.GetInstance<IDeclarationRepository>();
            //操作响应类
            var result = new ResponseView();

            //处理审核记录
            //foreach (var item in declarations)
            //{
            //    var id = item.DeclarationId.ConvertToInt();
            //    var declaration = repo.First(t => t.DeclarationId == id);
            //    Domain.ApprovalService.CreateApproval<DeclarationApproval>(declaration, division, auditor, sugg, remark);
            //}
            //保存到db
            try
            {
                repo.Context.Commit();
                return result;
            }
            catch (Exception)
            {
                result.IsSuccess = false;
                result.Message = "提交审核失败";
                return result;
            }

        }

        public string GetAuditor(string loginName)
        {
            var name = new TbmisUserAppl(loginName).GetUser().TbmisUserName;
            return name;
        }

        #endregion

    }
}
