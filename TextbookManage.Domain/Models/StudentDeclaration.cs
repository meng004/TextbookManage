namespace TextbookManage.Domain.Models
{
    using System.Collections.Generic;


    public class StudentDeclaration : Declaration
    {
        public StudentDeclaration()
        {
            RecipientType = RecipientType.学生;
            this.DeclarationClasses = new List<DeclarationClass>();
        }

        /// <summary>
        /// 学生班级
        /// </summary>
        public virtual ICollection<DeclarationClass> DeclarationClasses { get; set; }
    }
}
