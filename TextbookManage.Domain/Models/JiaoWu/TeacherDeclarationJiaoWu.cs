using System.ComponentModel.DataAnnotations.Schema;
using TextbookManage.Infrastructure;

namespace TextbookManage.Domain.Models.JiaoWu
{
    /// <summary>
    /// 用于与教务的教师用书申报映射
    /// </summary>
    public class TeacherDeclarationJiaoWu : Declaration
    {
        /// <summary>
        /// 申报数量
        /// </summary>
        [NotMapped]
        public int DeclarationCount { get; set; }

        /// <summary>
        /// 教材的学生用书申报
        /// </summary>
        public virtual StudentDeclaration StudentDeclaration { get; set; }

        /// <summary>
        /// 教务系统的核定数量
        /// </summary>
        public string Hdsl
        {
            get { return hdsl; }
            set
            {
                DeclarationCount = value.ConvertToInt();
                hdsl = value;
            }
        }

        private string hdsl;
    }
}
