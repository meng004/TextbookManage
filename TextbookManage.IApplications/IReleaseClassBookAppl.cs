using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.Infrastructure.Cache;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    /// <summary>
    /// 发放班级教材
    /// </summary>
    [ServiceContract]
    public interface IReleaseClassBookAppl
    {
        /// <summary>
        ///  根据登录名，取书商发放的学院
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<SchoolView> GetSchoolByLoginName(string loginName);
        /// <summary>
        /// 取年级
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<string> GetGradeBySchoolId(string schoolId);
        /// <summary>
        /// 根据学院Id、年级取专业班级
        /// </summary>
        /// <param name="schoolId"></param>
        /// <param name="grade"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<ProfessionalClassBaseView> GetClassBySchoolId(string schoolId, string grade);
        /// <summary>
        /// 根据登录名，取仓库
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<StorageView> GetStorages(string loginName);
        /// <summary>
        ///  由学号取姓名
        /// </summary>
        /// <param name="studentNum"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        ResponseView GetStudentNameByStudentNum(string studentNum);
        /// <summary>
        /// 根据班级ID和仓库Id,查询未发放的教材
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="storageId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<InventoryForReleaseClassView> GetInventoriesByClassId(string classId, string storageId);
        /// <summary>
        ///  根据班级Id，教材Id,获取未领书学生名单
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="textbookId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<StudentView> GetNotReleaseStudents(string classId, string textbookId);
        /// <summary>
        /// 发放班级教材
        /// </summary>
        /// <param name="views"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ResponseView SubmitReleaseClass(IEnumerable<InventoryForReleaseClassView> inventoryViews, ReleaseBookForClassView releaseView);

    }
}
