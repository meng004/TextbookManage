

using TextbookManage.Domain.Models.JiaoWu;
namespace TextbookManage.Domain.Models
{
    public class DepartmentProgress : SchoolProgress
    {
        /// <summary>
        /// 教研室
        /// </summary>
        public Department Department { get; set; }
        /// <summary>
        /// 数据标识
        /// </summary>
        public DataSign DataSign { get; set; }
        /// <summary>
        /// 课程
        /// </summary>
        public Course Course { get; set; }
    }
}
