using TextbookManage.Domain.Models.JiaoWu;
namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 学生用书申报班级
    /// </summary>
    public class DeclarationClass
    {
        /// <summary>
        /// 申报ID
        /// </summary>
        public int DeclarationId { get; set; }
        /// <summary>
        /// 学生班级ID
        /// </summary>
        public System.Guid ProfessionalClass_Id { get; set; }
        /// <summary>
        /// 申报数量
        /// </summary>
        public int DeclarationCount { get; set; }
        /// <summary>
        /// 学生班级
        /// </summary>
        public virtual ProfessionalClass ProfessionalClass { get; set; }
        /// <summary>
        /// 所属用书申报
        /// </summary>
        public virtual StudentDeclaration Declaration { get; set; }
    }
}
