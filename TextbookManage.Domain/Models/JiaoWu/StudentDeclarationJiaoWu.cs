
namespace TextbookManage.Domain.Models.JiaoWu
{
    /// <summary>
    /// 用于与教务的学生用书申报映射
    /// </summary>
    public class StudentDeclarationJiaoWu : Declaration
    {
        /// <summary>
        /// 申报数量
        /// 教务系统的征订数量
        /// </summary>
        public int DeclarationCount { get; set; }
    }
}
