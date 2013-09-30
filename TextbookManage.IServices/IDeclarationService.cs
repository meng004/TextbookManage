using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.ViewModels;
using TextbookManage.Infrastructure.Cache;

namespace TextbookManage.IServices
{
    [ServiceContract]
    public interface IDeclarationService
    {
        /// <summary>
        /// 新建学生用书申报
        /// </summary>
        /// <param name="textbookId">教材</param>
        /// <param name="teachingTask">教学任务</param>
        /// <param name="teacherId">教师</param>
        /// <param name="declarationCount">申报数量</param>
        /// <param name="mobile">移动电话</param>
        /// <param name="telephone">固定电话</param>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        AddResponse AddStudentDeclaration(AddRequest studentDeclaration);


        /// <summary>
        /// 新建教师用书申报
        /// </summary>
        /// <param name="textbookId">教材</param>
        /// <param name="teachingTask">教学任务</param>
        /// <param name="teacherId">教师</param>
        /// <param name="declarationCount">申报数量</param>
        /// <param name="mobile">移动电话</param>
        /// <param name="telephone">固定电话</param>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        AddResponse AddTeacherDeclaration(AddRequest teacherDeclaration);

        /// <summary>
        /// 取待审学院
        /// 学院为开课学院
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        QueryCollectionResponse GetSchoolWithNotApproval(QueryRequest username);

        /// <summary>
        /// 取待审用书申报
        /// </summary>
        /// <param name="username"></param>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        QueryCollectionResponse GetWithNotApproval(QueryRequest schoolId);

        /// <summary>
        /// 保存审核信息
        /// </summary>
        /// <param name="declarationId"></param>
        /// <param name="division"></param>
        /// <param name="auditor"></param>
        /// <param name="suggestion"></param>
        /// <param name="remark"></param>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        AddResponse AddApproval(AddRequest approval);

        /// <summary>
        /// 取审核
        /// </summary>
        /// <param name="declarationId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        QueryCollectionResponse GetApproval(QueryRequest declarationId);

        /// <summary>
        /// 取申报
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        QueryCollectionResponse GetByCourseId(QueryRequest courseId);

        /// <summary>
        /// 删除申报
        /// </summary>
        /// <param name="declarationIds"></param>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        RemoveResponse Remove(RemoveRequest declarationIds);

        /// <summary>
        /// 修改申报
        /// </summary>
        /// <param name="declarationId"></param>
        /// <param name="textbookId"></param>
        /// <param name="mobile"></param>
        /// <param name="telephone"></param>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ModifyResponse Modify(ModifyRequest declaration);

    }
}
