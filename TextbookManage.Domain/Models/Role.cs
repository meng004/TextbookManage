using System;
using System.Collections.Generic;


namespace TextbookManage.Domain.Models
{
    public class Role : AggregateRoot
    {

        public Role()
        {
            Users = new List<TbmisUser>();
        }

        /// <summary>
        /// 角色ID
        /// </summary>
        public Guid RoleId { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 用户集合
        /// </summary>
        public virtual ICollection<TbmisUser> Users { get; set; }
    }
}
