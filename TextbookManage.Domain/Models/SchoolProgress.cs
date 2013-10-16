
namespace TextbookManage.Domain.Models
{
    public class SchoolProgress 
    {
        public SchoolProgress()
        {
            TotalCount = 0;
            FinishedCount = 0;
            RestCount = 0;
            Proportion = 0;
        }

        #region 属性

        /// <summary>
        /// 学院名称
        /// </summary>
        public School School { get; set; }
        /// <summary>
        /// 教学任务总数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 已完成数
        /// </summary>
        public int FinishedCount { get; set; }
        /// <summary>
        /// 剩余数
        /// </summary>
        public int RestCount { get; set; }
        /// <summary>
        /// 完成比例
        /// </summary>
        public float Proportion { get; set; }
        #endregion

    }
}
