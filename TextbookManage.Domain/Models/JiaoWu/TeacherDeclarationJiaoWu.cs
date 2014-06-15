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

        /// <summary>
        /// 申报数量
        /// </summary>
        [NotMapped]
        public int DeclarationCount { get; set; }
    }
}
