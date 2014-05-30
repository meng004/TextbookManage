using System;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 实体
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// 获取当前领域实体类的全局唯一标识。
        /// </summary>
        Guid ID { get; }
    }
}
