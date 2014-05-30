namespace TextbookManage.Domain.Models
{
    public interface IDiscountStrategy
    {
        /// <summary>
        /// 根据教材，采用折扣策略
        /// </summary>
        /// <param name="textbook"></param>
        /// <returns></returns>
        decimal GetDiscount(Textbook textbook);
    }
}
