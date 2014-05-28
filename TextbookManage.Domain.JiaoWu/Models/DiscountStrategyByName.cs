using System.Collections.Generic;

namespace TextbookManage.Domain.Models.JiaoWu
{
    /// <summary>
    /// 按教材名称，设定折扣
    /// </summary>
    public class DiscountStrategyByName : IDiscountStrategy
    {
        readonly List<string> _keys = new List<string> 
        { 
            "作业本", "英语作业本", "英语本", "实验报告本", 
            "试验报告本", "马克思", "思想道德", "中国近现代史", "毛泽东" 
        };

        public decimal GetDiscount(Textbook textbook)
        {
            if (IsDiscount(textbook.Name))
            {
                return 0.9m;
            }
            else
            {
                return 1.0M;
            }
        }


        /// <summary>
        /// 根据教材名称，判断是否有折扣
        /// </summary>
        /// <param name="textbookName"></param>
        /// <returns></returns>
        private bool IsDiscount(string textbookName)
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
