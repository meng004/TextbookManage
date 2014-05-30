using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 按教材名称，设定折扣
    /// </summary>
    public class DiscountStrategyByName : IDiscountStrategy
    {
        readonly List<string> _keys = new List<string> { "作业本", "英语作业本", "英语本", "实验报告本", "试验报告本", "马克思", "思想道德", "中国近现代史", "毛泽东" };

        public decimal GetDiscount(Textbook textbook)
        {
            if (IsNoDiscount(textbook.Name))
            {
                return 1.0m;
            }
            else
            {
                return 0.9M;                
            }
        }


        /// <summary>
        /// 根据教材名称，判断是否没有折扣
        /// </summary>
        /// <param name="textbookName"></param>
        /// <returns></returns>
        private bool IsNoDiscount(string textbookName)
        {
            bool result = false;

            foreach (var item in _keys)
            {
                if (textbookName.Contains(item))
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
